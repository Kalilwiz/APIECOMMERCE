using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IPedidoRepository
    {   
        //  R - Read (ler)
        List<Pedido> ListarTodos();

        Pedido BuscarPorId(int id);

        //  C - Create (cadastro)
        void Cadastrar(CadastrarPedidoDto pedido);

        //  U - Update (atualizacao)

        void Atualizar(int id, Pedido pedido);

        //  D - Delete(Apagar)

        void Deletar(int id);
    }
}
