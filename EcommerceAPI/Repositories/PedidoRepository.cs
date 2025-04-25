using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EcommerceAPI.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AquiCometerasLoucurasContext _context;

        public PedidoRepository(AquiCometerasLoucurasContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Pedido pedido)
        {
            Pedido PedidoEncontrado = _context.Pedidos.Find(id);

            if (PedidoEncontrado == null)
            {
                throw new ArgumentException();
            }

            PedidoEncontrado.IdCliente = pedido.IdCliente;
            PedidoEncontrado.DataPedido = pedido.DataPedido;
            PedidoEncontrado.Status = pedido.Status;
            PedidoEncontrado.ValorTotal = pedido.ValorTotal;

            _context.SaveChanges();
        }


        public Pedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(CadastrarPedidoDto dto)

        {
            // crio uma variavel pedido para armazenar os dados que vem de dentro da dto CadastrarPedidoDto
            var pedido = new Pedido
            {
                DataPedido = dto.DataPedido,
                IdCliente = dto.IdCliente,
                Status = dto.Status,
                ValorTotal = dto.ValorTotal,
            };


            // armazeno dentro do contexto e salvo
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            //  crio uma variavel que itera a lista de produtos do meu pedido e tras o id de cada um
            for (int i = 0; i < dto.Produto.Count; i++)
            {
                // crio uma variavel para armazenar o id de cada produo
                var produto = _context.Produtos.Find(dto.Produto[i]);

                // crio uma varialve que vai armazenar os dados do item pedido
                var itemPedido = new ItemDoPedido
                {
                    IdPedido = pedido.IdPedido,
                    IdProduto = produto.IdProduto,
                    Quantidade = 1
                };


                // mando as informacoes de item pedido para o banco e salvo
                _context.ItemDoPedidos.Add(itemPedido);
                _context.SaveChanges();
            }

        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pedido> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
