using server.Domain.Features.pedido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        void AdicionarPedido(Pedido novoPedido);
        void DeletarPedido(int id);
        void AtualizarStatusPedido(int id, StatusPedido status);
        List<Pedido> BuscaTodosPedidos();
        Pedido BuscaPedidoPorId(int id);
    }
}
