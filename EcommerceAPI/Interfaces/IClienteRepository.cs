using EcommerceAPI.Models;

namespace EcommerceAPI.Interfaces
{
    public interface IClienteRepository
    {
        //  R - Read
        List<Cliente> ListarTodos();

        Cliente BuscarPorId(int id);
        Cliente BuscarPorEmailSenha(string email, string senha);

        //  C - Create
        void Cadastrar(Cliente cliente);

        //  U - Update

        void Atualizar(int id, Cliente cliente);

        //  D - Delete

        void Deletar(int id);
    }
}
