using Microsoft.AspNetCore.Mvc;
using server.Domain.Features.cliente;
using server.Domain.Interfaces;
using server.Infra.Data.Repository;
using System;

namespace server.WebApi.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository = new ClienteRepository();
        

        [HttpPost]
        public IActionResult PostCliente([FromBody] Cliente novoCliente)
        {
            try
            {
                if (novoCliente.ValidarCliente())
                {
                    _clienteRepository.CriarNovoCliente(novoCliente);
                }
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCliente()
        {
            try
            {
                return Ok(_clienteRepository.BuscarCliente());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IActionResult PutCliente([FromBody] Cliente novoCliente)
        {
            try
            {
                _clienteRepository.EditarCliente(novoCliente);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{cpf}")]
        public IActionResult DeletarCliente(string cpf)
        {
            try
            {
                _clienteRepository.DeletarCliente(cpf);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetClientePorId(int id)
        {
            try
            {
                return Ok(_clienteRepository.BuscarClientePorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
