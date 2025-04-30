using EcommerceAPI.Context;
using EcommerceAPI.DTO;
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

    public class ItemDoPedidoController : ControllerBase
    {

        // criando uma variavel privada para injetar a interface no controller
        private IItemDoPedidoRepository _itemDoPedidoRepository;

        // criando um contrutor para criar uma variavel do tipo da interface e passando para dentro da variavel private
        // isso faz com que o construtor leia e traga informacoes automaticamente pelo c#
        public ItemDoPedidoController(IItemDoPedidoRepository ItemDoPedidoRepository)
        {
            _itemDoPedidoRepository = ItemDoPedidoRepository;
        }

        // metodo get para usar o metodo listar

        [HttpGet]

        // criando o metodo listar usando o metodo iactionresult para trazer seu resultado e o codigo para retornar ao navegador
        public IActionResult ListarProdutos()
        {
            // chamando o metodo da sua interface e exibindo com o ok(codigo 200)
            return Ok(_itemDoPedidoRepository.ListarTodos());
        }

        // metodo posto usado para Cadastrar seus produtos
        [HttpPost]

        // criando o metodod cadastrar produto usando ia result com o argumento produto usando a dto cadastrar produto para cadastrar apenas o que eu quero
        public IActionResult CadastrarProduto(CadastrarItemDoPedidoDTO ItemDoPedido)
        {
            // usando metodo cadastrar de dentro do seu repositorio para cadastrar com as informaçoes dadas
            _itemDoPedidoRepository.Cadastrar(ItemDoPedido);
            // retornando ok
            return Created();
        }

        // metodo get buscando com um endpoint

        [HttpGet("{id}")]

        // criando o metodod listarporid com iactionresult com o argumento id
        public IActionResult ListarPorID(int id)
        {
            // criando a variavel produto do tipo produto para buscar o id informado e trazer as informacoes localizadas
            ItemDoPedido ItemDoPedido = _itemDoPedidoRepository.BuscarPorId(id);

            // verificando se for nulo
            if (ItemDoPedido == null)
            {
                return NotFound();
            }


            // trazendo o resultado e o codigo 
            return Ok(ItemDoPedido);
        }


        // criando metodo put para atualizar algo criado usando um endpoint
        [HttpPut("{id}")]

        // criando um metodo alterar com os argumetos id e produto do tipo produto
        public IActionResult Alterar(int id, ItemDoPedido produto)
        {
            // usando try catch para tentar atualizar com base no seu id
            // retorna notfoud se nao achar
            try
            {
                //usando metodo atualizar do seu repositorio para procurar com base no seu id e alterar com as informacoes passadas dentro do seu produto
                _itemDoPedidoRepository.Atualizar(id, produto);

                return Ok(produto);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // metodo delete com endpoint

        [HttpDelete("{id}")]

        // criando metodo delete com o argumento id
        public IActionResult Delete(int id)
        {

            // usando try catch para tentar localizar o id informado
            // retorna notfound se nao encontrar o id
            try
            {
                // usando metodo deletar de dentro do seu repositorio com base no seu id
                _itemDoPedidoRepository.Deletar(id);
                // retornando que foi excluido
                return NoContent();

            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }
    }
}
