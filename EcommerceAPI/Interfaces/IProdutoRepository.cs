using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IprodutoRepository
    {
        // R - Read (Leitura)
        List<Produto> ListarTodos();    // cria um metodo do tipo List com o tipo Produto de nome ListarTodos

        Produto BuscarPorId(int id);    // Tras o id de cada produto

        //  C - Create (cadastro)
        void Cadastrar(CadastrarProdutoDto produto);    // Cria o metodo cadastrar do tipo Produto com o nome produto

        //  U - Update (atualizacao)

        void Atualizar(int id, Produto produto);

        //  D - Delete(Apagar)

        void Deletar(int id);











    }
}
