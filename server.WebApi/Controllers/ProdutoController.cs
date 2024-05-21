using Microsoft.AspNetCore.Mvc;
using server.Domain.Features.produto;
using server.Domain.Interfaces;
using server.Infra.Data.Repository;
using System;

namespace server.WebApi.Controllers
{
    [ApiController]
    [Route("produto")]
    public class ProdutoController : Controller
    {

        private IProdutoRepository _produtoRepository = new ProdutoRepository();


        [HttpPost]
        public IActionResult PostProduto([FromBody] Produto novoProduto)
        {
            try
            {
                if (novoProduto.ValidarProduto())
                {
                    _produtoRepository.AdicionarNovoProduto(novoProduto);
                }
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetProdutos()
        {
            try
            {
                return Ok(_produtoRepository.BuscarTodosProdutos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetProdutosPorId(int id)
        {
            try
            {
                return Ok(_produtoRepository.BuscarProdutoPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("ativo")]
        public IActionResult GetProdutosAtivos()
        {
            try
            {
                return Ok(_produtoRepository.BuscarProdutosAtivos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        public IActionResult PatchEstoque([FromBody] Produto produto)
        {
            try
            {
                _produtoRepository.AtualizarEstoque(produto);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult PutProduto([FromBody] Produto produto)
        {
            try
            {
                _produtoRepository.EditarProduto(produto);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]
        [Route("ativo")]
        public IActionResult PatchProdutoAtivo([FromBody] Produto produto)
        {
            try
            {
                _produtoRepository.AtivarOuDesativarProduto(produto.Id, produto.Ativo);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
