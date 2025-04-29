using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IItemDoPedidoRepository
    {
        List<ItemDoPedido> ListarTodos();

        ItemDoPedido BuscarPorId(int id);

        //  C - Create (cadastro)
        void Cadastrar(CadastrarItemDoPedidoDTO itempedido);

        //  U - Update (atualizacao)

        void Atualizar(int id, ItemDoPedido itempedido);

        //  D - Delete(Apagar)

        void Deletar(int id);
    }
}
