using server.Domain.Features.cliente;
using server.Domain.Features.pedido;
using server.Domain.Interfaces;
using server.Infra.Data.DAO;
using System;
using System.Collections.Generic;

namespace server.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private ClienteDAO _clienteDAO = new ClienteDAO();
        private PedidoDAO _pedidoDAO = new PedidoDAO();
        private ProdutoDAO _produtoDAO = new ProdutoDAO();

        public void AdicionarPedido(Pedido novoPedido)
        {
            novoPedido.ValorTotalPedido();

            if (novoPedido.ValidarPedido())
            {
                Cliente cliente = _clienteDAO.BuscaClientePorCpf(novoPedido.ClienteCpf);
                cliente.AtualizaFidelidade(novoPedido.ValorPedido);
                _clienteDAO.AdicionarPontosFidelidade(novoPedido.ClienteCpf, cliente.PontosFidelidade);
                _pedidoDAO.AddPedidoComCliente(novoPedido);
                novoPedido.Produto.DiminuirEstoque(novoPedido.Quantidade);
                _produtoDAO.AtualizarEstoque(novoPedido.Produto.Id, novoPedido.Produto.Estoque);
            }
            else
            {
                _pedidoDAO.AddPedidoSemCliente(novoPedido);
                novoPedido.Produto.DiminuirEstoque(novoPedido.Quantidade);
                _produtoDAO.AtualizarEstoque(novoPedido.Produto.Id, novoPedido.Produto.Estoque);
            }
        }

        public void DeletarPedido(int id)
        {
            var pedido = _pedidoDAO.BuscarPedidoPorID(id);
            if (pedido.EhPossivelAlterarStatusPedido())
                _pedidoDAO.DeletarPedido(id);
        }

        public List<Pedido> BuscaTodosPedidos()
        {
            var lista = _pedidoDAO.BuscarTodosPedidos();
            return lista;
        }

        public Pedido BuscaPedidoPorId(int id)
        {
            var pedido = _pedidoDAO.BuscarPedidoPorID(id);
            return pedido;
        }

        public void AtualizarStatusPedido(int id, StatusPedido status)
        {
            var pedido = _pedidoDAO.BuscarPedidoPorID(id);
            if (pedido.EhPossivelAlterarStatusPedido())
                _pedidoDAO.AtualizarStatusPedido(id, status);
        }
    }
}
