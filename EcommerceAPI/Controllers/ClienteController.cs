using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
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

        [HttpGet]

        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult Cadastrar(Cliente cliente)
        {
            _clienteRepository.Cadastrar(cliente);
            return Created();

        }





    }
}
