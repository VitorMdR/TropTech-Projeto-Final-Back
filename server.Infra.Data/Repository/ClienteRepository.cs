using server.Domain.Features.cliente;
using server.Domain.Interfaces;
using server.Infra.Data.DAO;
using System.Collections.Generic;

namespace server.Infra.Data.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private ClienteDAO _clienteDAO = new ClienteDAO();
        
        public void CriarNovoCliente(Cliente novoCliente)
        {
            var listaVerificacao = _clienteDAO.BuscaClientes();

            if (listaVerificacao.Exists(i => i.Cpf == novoCliente.Cpf))
            {
                throw new ClienteExisteException();
            }

            _clienteDAO.AdicionarCliente(novoCliente);
        }

        public void DeletarCliente(string cpf)
        {
            _clienteDAO.DeletarCliente(cpf);
        }

        public void EditarCliente(Cliente cliente)
        {
            _clienteDAO.EditarCliente(cliente);
        }
        public void AddPontosFidelidade(string cpf, double pontosFidelidade)
        {
            _clienteDAO.AdicionarPontosFidelidade(cpf, pontosFidelidade);
        }

        public List<Cliente> BuscarCliente()
        {
            var lista = _clienteDAO.BuscaClientes();
            return lista;
        }

        public Cliente BuscarClientePorId(int id)
        {
            var cliente = _clienteDAO.BuscaClientePorId(id);
            return cliente;
        }
    }
}
