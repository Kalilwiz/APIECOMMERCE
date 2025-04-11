using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IItemDoPedido
    {
        List<ItemDoPedido> ListarTodos();

        ItemDoPedido BuscarPorId(int id);

        //  C - Create (cadastro)
        void Cadastrar(ItemDoPedido itempedido);

        //  U - Update (atualizacao)

        void Atualizar(int id, ItemDoPedido itempedido);

        //  D - Delete(Apagar)

        void Deletar(int id);
    }
}
