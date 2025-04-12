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
    public class ProdutoController : ControllerBase
    {
        private IprodutoRepository _produtoRepository;

        private readonly AquiCometerasLoucurasContext _context;
        public ProdutoController(AquiCometerasLoucurasContext context, IprodutoRepository produtoRepository)
        {
            _context = context;
            _produtoRepository = new ProdutoRepository(context);
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
            _context.SaveChanges();                  // sempre que alterar o banco, usar essa fun
            
            return Created();                        //created representa o codigo 201 que significa "Funcionou e criou algo"
        }

    }
}
