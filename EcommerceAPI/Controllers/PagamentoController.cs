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
    public class PagamentoController : ControllerBase
    {
        private IPagamentoRepository _pagamentoRepository;

        public PagamentoController(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        [HttpGet]
        public IActionResult ListarTodos()

        {
            return Ok(_pagamentoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPagamento(Pagamento pagamento)
        {
            _pagamentoRepository.Cadastrar(pagamento);

            return Created();
        }
    }
}
