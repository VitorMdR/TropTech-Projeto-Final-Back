using server.Domain.Features.produto;
using System;

namespace server.Domain.Features.pedido
{
    public class Pedido
    {
        public int Id { get; set; }
        public string? ClienteCpf { get; set; }

        public string? NomeCliente { get; set; }

        public Produto Produto { get; set; }

        public int Quantidade { get; set; }

        public double ValorPedido { get; set; }

        public DateTime DataPedido { get; set; }

        public StatusPedido StatusAtual { get; set; }

        public Pedido()
        {

        }

        public void ValorTotalPedido()
        {
            ValorPedido = (Produto.Preco * Quantidade);
            DataPedido = DateTime.Now;
        }

        public bool ValidarPedido()
        {
            if (Quantidade < 1)
                throw new PedidoException("A quantidade de produtos não pode ser zero ou inferior!");

            if (ValorPedido < 0)
                throw new PedidoException("O valor do pedido não pode ser zero ou inferior!");

            if (Quantidade > this.Produto.Estoque)
                throw new PedidoException("Não há estoque suficiente!");

            if (StatusAtual == StatusPedido.finalizado)
                throw new PedidoException("O pedido foi finalizado, não pode ser alterado!");

            if (string.IsNullOrWhiteSpace(ClienteCpf) || string.IsNullOrEmpty(ClienteCpf) || ClienteCpf == "string")
                return false;

            return true;
        }
    }
    public enum StatusPedido
    {
        emAndamento,
        emTransito,
        finalizado
    }
}
