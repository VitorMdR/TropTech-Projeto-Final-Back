using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Features.cliente
{
    public class ClienteExisteException : Exception
    {
        public ClienteExisteException() : base("Cliente já cadastrado")
        {

        }
    }
}
