using Microsoft.AspNetCore.Mvc;
using server.Domain.Features.pedido;
using server.Domain.Interfaces;
using server.Infra.Data.Repository;
using System;

namespace server.WebApi.Controllers
{
    [ApiController]
    [Route("pedido")]
    public class PedidoController : ControllerBase
    {
        private IPedidoRepository _pedidoRepository = new PedidoRepository();


        [HttpPost]
        public IActionResult PostPedido([FromBody] Pedido novoPedido)
        {
            try
            {
                _pedidoRepository.AdicionarPedido(novoPedido);

                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetTodosPedidos()
        {
            try
            {
                return Ok(_pedidoRepository.BuscaTodosPedidos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetPedidosPorId(int id)
        {
            try
            {
                return Ok(_pedidoRepository.BuscaPedidoPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarPedido(int id)
        {
            try
            {
                _pedidoRepository.DeletarPedido(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPatch]        
        public IActionResult AtualizarStatus(int id, StatusPedido status)
        {
            try
            {
                _pedidoRepository.AtualizarStatusPedido(id, status);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
