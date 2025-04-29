using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repositories
{
    public class ItemDoPedidoRepository : IItemDoPedidoRepository
    {

        private readonly AquiCometerasLoucurasContext _context;

        public ItemDoPedidoRepository(AquiCometerasLoucurasContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, ItemDoPedido ItemDoPedido)
        {
            ItemDoPedido ItemDoPedidoEncontrado = _context.ItemDoPedidos.Find(id);

            if (ItemDoPedidoEncontrado == null)
            {
                throw new Exception();
            }

            ItemDoPedidoEncontrado.IdPedido = ItemDoPedido.IdPedido;
            ItemDoPedidoEncontrado.IdProduto = ItemDoPedido.IdProduto;
            ItemDoPedidoEncontrado.Quantidade = ItemDoPedido.Quantidade;

            _context.SaveChanges();
        }

        public ItemDoPedido BuscarPorId(int id)
        {
            return _context.ItemDoPedidos.FirstOrDefault(p => p.IdItemPedido == id);
        }

        public void Cadastrar(CadastrarItemDoPedidoDTO dto)
        {
            ItemDoPedido item = new ItemDoPedido
            {
                IdPedido = dto.IdPedido,
                IdProduto = dto.IdProduto,
                Quantidade = dto.Quantidade,

            };

            _context.ItemDoPedidos.Add(item);

            _context.SaveChanges();
        }


        public void Deletar(int id)
        {
            // cria uma variavel do tipo produto e procura dentro do contxto usando a funçao FIND

            ItemDoPedido ItemEncontrado = _context.ItemDoPedidos.Find(id);

            // verifica se o valor encontrado nao e null e se for cria um erro
            if (ItemEncontrado == null)
            {
                throw new Exception();
            }

            // manda para o contexto e salva
            _context.ItemDoPedidos.Remove(ItemEncontrado);
            _context.SaveChanges();
        }

        public List<ItemDoPedido> ListarTodos()
        {
            return _context.ItemDoPedidos.Include(p => p.IdProdutoNavigation).ToList();

        }
    }
}