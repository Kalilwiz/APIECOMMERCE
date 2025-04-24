using EcommerceAPI.DTO;
using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IClienteRepository
    {
        //  R - Read
        List<Cliente> ListarTodos();

        Cliente BuscarPorId(int id);
        Cliente BuscarPorEmailSenha(string email, string senha);

        List<Cliente> BuscarClientePorNome(string nome);

        Cliente CriarLogin(Cliente email, Cliente senha);

        //  C - Create
        void Cadastrar(CadastrarClienteDto cliente);

        //  U - Update

        void Atualizar(int id, Cliente cliente);

        //  D - Delete

        void Deletar(int id);
    }
}
