using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/Caloteiros")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly AquiCometerasLoucurasContext _context;

        private IClienteRepository _clienteRepository;

        public ClienteController(AquiCometerasLoucurasContext context, IClienteRepository clienteRepository)
        {
            _context = context;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]

        public IActionResult ListarTodos()
        {
            return Ok(_clienteRepository.ListarTodos());
        }





    }
}
