﻿using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly AquiCometerasLoucurasContext _context;

        public PagamentoRepository(AquiCometerasLoucurasContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Pagamento pagamento)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            pagamentoEncontrado.FormaPagamento = pagamento.FormaPagamento;
            pagamentoEncontrado.Status = pagamento.Status;
            pagamentoEncontrado.Data = pagamento.Data;

            _context.SaveChanges();
        }

        public Pagamento BuscarPorId(int id)
        {
            return _context.Pagamentos.FirstOrDefault(p => p.IdPagamento == id);
        }

        public void Cadastrar(CadastrarPagamentoDto dto)
        {
            Pagamento pagamento = new Pagamento
            {
                IdPedido = dto.IdPedido,
                FormaPagamento = dto.FormaPagamento,
                Status = dto.Status,
                Data = dto.Data,
            };

            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Pagamento pagamentoEncontrado = _context.Pagamentos.Find(id);

            if (pagamentoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Pagamentos.Remove(pagamentoEncontrado);
            _context.SaveChanges();
        }

        public List<Pagamento> ListarTodos()
        {
            return _context.Pagamentos.Include(p => p.IdPedidoNavigation).ToList();
        }
    }
}
