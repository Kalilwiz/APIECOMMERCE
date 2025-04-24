using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IPagamentoRepository
    {
        List<Pagamento> ListarTodos();    

        Pagamento BuscarPorId(int id);    

        //  C - Create (cadastro)
        void Cadastrar(CadastrarPagamentoDto pagamento);    

        //  U - Update (atualizacao)

        void Atualizar(int id, Pagamento pagamento);

        //  D - Delete(Apagar)

        void Deletar(int id);
    }
}
