using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly AquiCometerasLoucurasContext _context;

        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(AquiCometerasLoucurasContext context, IPagamentoRepository pagamentoRepository)
        {
            _context = context;
            _pagamentoRepository = pagamentoRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()

        { 
            return Ok(_pagamentoRepository.ListarTodos());
        }
    }
}
