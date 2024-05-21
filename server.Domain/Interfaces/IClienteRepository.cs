using server.Domain.Features.cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Interfaces
{
    public interface IClienteRepository
    {
        void CriarNovoCliente(Cliente novoCliente);
        void EditarCliente(Cliente novoCliente);
        void AddPontosFidelidade(string cpf, double pontosFidelidade);
        void DeletarCliente(string cpf);
        List<Cliente> BuscarCliente();
        Cliente BuscarClientePorId(int id);
    }
}
