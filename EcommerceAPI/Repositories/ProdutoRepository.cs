using EcommerceAPI.Context;
using EcommerceAPI.DTO;
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

        // crio o metodo atualizar com os argumentos id e uma variavel do tipo produto
        public void Atualizar(int id, Produto produto)
        {

            // crio uma variavel do tipo produto, procuro dentro do contexto o id usando FIND e armazeno dentro da variavel
            Produto produtoEncontrado = _context.Produtos.Find(id);

            // verifico se o id encontrado nao e nulo e lanco um erro para tratar
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            // uso a variavel criada para alterar o banco com base na informacao que o usuario informar em produto

            produtoEncontrado.Nome = produto.Nome;
            produtoEncontrado.Categoria = produto.Categoria;
            produtoEncontrado.Preco = produto.Preco;
            produtoEncontrado.EstoqueDisponivel = produto.EstoqueDisponivel;
            produtoEncontrado.Descricao = produto.Descricao;
            produtoEncontrado.Imagem = produto.Imagem;

            // salvo as alteracoes no contexto

            _context.SaveChanges();

        }

        public Produto BuscarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);        // funcao lambda
        }

        public void Cadastrar(CadastrarProdutoDto dto)
        {
            Produto produto = new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                EstoqueDisponivel = dto.EstoqueDisponivel,
                Categoria = dto.Categoria,
                Imagem = dto.Imagem,

            };
            _context.Produtos.Add(produto);

            _context.SaveChanges();

        }

        public void Deletar(int id)
        {
            Produto produtoEncontrado = _context.Produtos.Find(id);

            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            _context.Produtos.Remove(produtoEncontrado);
            _context.SaveChanges();

        }

        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
