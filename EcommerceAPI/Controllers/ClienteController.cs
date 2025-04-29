using EcommerceAPI.Context;
using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }


        [HttpGet("/buscar/{nome}")]

        public IActionResult ListarPorNome(string nome)
        {
            return Ok(_clienteRepository.BuscarClientePorNome(nome));
        }



        [HttpGet]

        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cliente cliente = _clienteRepository.BuscarPorId(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarClienteDto cliente)
        {
            _clienteRepository.Cadastrar(cliente);
            return Created();

        }

        //[HttpPost]
        //public IActionResult CriarLogin(Cliente email, Cliente Senha)
        //{
        //    _clienteRepository.CriarLogin(email, Senha);
        //    return Created();
        //}

        [HttpPut("{id}")]

        public IActionResult Alterar(int id, Cliente cliente)
        {
            try
            {
                _clienteRepository.Atualizar(id, cliente);

                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clienteRepository.Deletar(id);
                return NoContent();

            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }



    }
}
