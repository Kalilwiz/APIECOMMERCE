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

        public void Atualizar(int id, Produto produto)
        {
            throw new NotImplementedException();
        }

        public Produto BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Produto produto)
        {
            _context.Produtos.Add(produto);

            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
