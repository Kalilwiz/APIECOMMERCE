using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IprodutoRepository
    {
        // R - Read (Leitura)
        List<ItemDoPedido> ListarTodos();    // cria um metodo do tipo List com o tipo Produto de nome ListarTodos

        ItemDoPedido BuscarPorId(int id);    // Tras o id de cada produto

        //  C - Create (cadastro)
        void Cadastrar(ItemDoPedido produto);    // Cria o metodo cadastrar do tipo Produto com o nome produto

        //  U - Update (atualizacao)

        void Atualizar(int id, ItemDoPedido produto);

        //  D - Delete(Apagar)

        void Deletar(int id);











    }
}
