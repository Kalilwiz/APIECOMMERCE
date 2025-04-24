using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;

namespace EcommerceAPI.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly AquiCometerasLoucurasContext _context;

        public ClienteRepository(AquiCometerasLoucurasContext context)
        {
            _context = context;
        }
        public void Atualizar(int id, Cliente cliente)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);

            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            clienteEncontrado.NomeCompleto = cliente.NomeCompleto;
            clienteEncontrado.Email = cliente.Email;
            clienteEncontrado.Telefone = cliente.Telefone;
            clienteEncontrado.Endereco = cliente.Endereco;
            clienteEncontrado.Senha = cliente.Senha;
            clienteEncontrado.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();
        }

        public List<Cliente> BuscarClientePorNome(string nome)
        {
            var Cliente = _context.Clientes.Where(c => c.NomeCompleto == nome).ToList();

            return Cliente;
        }

        public Cliente? BuscarPorEmailSenha(string email, string senha)
        {
            Cliente clienteEncontrado = _context.Clientes.FirstOrDefault(c => c.Email == email && c.Senha == senha);

            return clienteEncontrado;
        }

        public Cliente BuscarPorId(int id)
        {
            return _context.Clientes.FirstOrDefault(c => c.IdCliente == id);
        }

        public void Cadastrar(CadastrarClienteDto dto)
        {
            Cliente cliente = new Cliente 
            {
                NomeCompleto = dto.NomeCompleto,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Endereco = dto.Endereco,
                Senha = dto.Senha,
                DataCadastro = dto.DataCadastro,
            };


            _context.Clientes.Add(cliente);

            _context.SaveChanges();
        }

        public void CriarLogin(Cliente email, Cliente Senha)
        {
            _context.Clientes.Add(email);
            _context.Clientes.Add(Senha);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Cliente clienteEncontrado = _context.Clientes.Find(id);
            if (clienteEncontrado == null)
            {
                throw new Exception();
            }

            _context.Clientes.Remove(clienteEncontrado);
            _context.SaveChanges();
        }

        public List<Cliente> ListarTodos()
        {
            return _context.Clientes.OrderBy(C => C.NomeCompleto).ToList();
        }

        Cliente IClienteRepository.CriarLogin(Cliente email, Cliente senha)
        {
            throw new NotImplementedException();
        }
    }
}
