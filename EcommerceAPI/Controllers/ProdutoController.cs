using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IprodutoRepository _produtoRepository;

        public ProdutoController(IprodutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IActionResult ListarProdutos()
        {
            return Ok(_produtoRepository.ListarTodos());
        }

        [HttpPost]
        public IActionResult CadastrarProduto(Produto produto)
        {
            _produtoRepository.Cadastrar(produto);
            return Created();
        }

        [HttpGet("{id}")]

        public IActionResult ListarPorID(int id)
        {
            Produto produto = _produtoRepository.BuscarPorId(id);

            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPut("{id}")]

        public IActionResult Alterar(int id, Produto produto)
        {
            try
            {
                _produtoRepository.Atualizar(id, produto);

                return Ok(produto);
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
                _produtoRepository.Deletar(id);
                return NoContent();

            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }
    }
}

