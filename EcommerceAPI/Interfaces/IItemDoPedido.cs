using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IItemDoPedido
    {
        List<ItemDoPedido> ListarTodos();

        ItemDoPedido BuscarPorId(int id);

        //  C - Create (cadastro)
        void Cadastrar(ItemDoPedido produto);

        //  U - Update (atualizacao)

        void Atualizar(int id, ItemDoPedido produto);

        //  D - Delete(Apagar)

        void Deletar(int id);
    }
}
