using EcommerceAPI.Context;
using EcommerceAPI.Interfaces;
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
            _produtoRepository = produtoRepository;
        }
         
        [HttpGet]
        public IActionResult ListarProdutos() 
        {
            return Ok(_produtoRepository.ListarTodos());
        }


    }
}
