using EcommerceAPI.DTO;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private IPedidoRepository _pedidoRepository;

        public PedidoController(IPedidoRepository produtoRepository)
        {
            _pedidoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult ListarPedidos()
        {
            return Ok(_pedidoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarPedido(CadastrarPedidoDto cadastrarPedido)
        {
            _pedidoRepository.Cadastrar(cadastrarPedido);

            return Created();
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorID(int id)
        {
            //return Ok(_pedidoRepository.BuscarPorId(id));

            Pedido pedido = _pedidoRepository.BuscarPorId(id);

            if (pedido == null)
            {
                return NotFound();
            }

            return Ok(pedido);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Pedido pedido)
        {
            try
            {
                _pedidoRepository.Atualizar(id, pedido);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            try
            {
                _pedidoRepository.Deletar(id);
                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

    }
}
