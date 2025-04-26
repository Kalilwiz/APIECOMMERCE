using System.Diagnostics.Contracts;
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

        // cria um metodo com um argumento e usa ele com uma funcao lambda e a funcao firstordefout para trazer o valor sempre que for igual ao dado pelo usuario
        public Produto BuscarPorId(int id)
        {
            return _context.Produtos.FirstOrDefault(p => p.IdProduto == id);        // funcao lambda
        }

        // cria uma variavel usando a interface cadastrar dto para mostrar apenas o que quer
        public void Cadastrar(CadastrarProdutoDto dto)
        {

            // cria uma variavel produto para passar os dados do cadastro para dentro da tabela produtos
            Produto produto = new Produto
            {
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                EstoqueDisponivel = dto.EstoqueDisponivel,
                Categoria = dto.Categoria,
                Imagem = dto.Imagem,

            };

            // manda para o contexto e salva

            _context.Produtos.Add(produto);

            _context.SaveChanges();

        }

        // cria o metodo deletar com o argumento id, 

        public void Deletar(int id)
        {
            // cria uma variavel do tipo produto e procura dentro do contxto usando a funçao FIND

            Produto produtoEncontrado = _context.Produtos.Find(id);

            // verifica se o valor encontrado nao e null e se for cria um erro
            if (produtoEncontrado == null)
            {
                throw new Exception();
            }

            // manda para o contexto e salva
            _context.Produtos.Remove(produtoEncontrado);
            _context.SaveChanges();

        }

        // cria um metodo listar todos do tipo LIST usando a classe produto e procura usando o metodo tolist que tras uma lista com tudo que ta dentro de produto
        public List<Produto> ListarTodos()
        {
            return _context.Produtos.ToList();
        }
    }
}
