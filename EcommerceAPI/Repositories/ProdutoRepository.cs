using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories
{
    public class ProdutoRepository : IprodutoRepository
    {

        private readonly AquiCometerasLoucurasContext _context;

        public ProdutoRepository(AquiCometerasLoucurasContext context)
        {
            _context = context;
        }

        

        public void Atualizar(int id, ItemDoPedido produto)
        {
            throw new NotImplementedException();
        }

        public ItemDoPedido BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(ItemDoPedido produto)
        {
            _context.Produtos.Add(produto);
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<ItemDoPedido> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
