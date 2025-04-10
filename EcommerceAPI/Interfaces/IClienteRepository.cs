using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IClienteRepository
    {
        //  R - Read
        List<ItemDoPedido> ListarTodos();

        ItemDoPedido BuscarPorId(int id);
        ItemDoPedido BuscarPorEmailSenha(string email, string senha);

        //  C - Create
        void Cadastrar(ItemDoPedido produto);

        //  U - Update

        void Atualizar(int id, ItemDoPedido produto);

        //  D - Delete

        void Deletar(int id);
    }
}
