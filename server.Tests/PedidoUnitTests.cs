using NUnit.Framework;
using server.Domain.Features.cliente;
using server.Domain.Features.pedido;
using server.Domain.Features.produto;
using System;

namespace server.Tests
{
    public class PedidoUnitTests
    {
        /*
        * Quando validar pedido 
        * E a quantidade de produtos for zero
        * Então deve lançar erro
        */
        [Test]
        public void Quando_ValidarPedido_E_AQuantidadeDeProdutosForZero_Entao_DeveLançarErro()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Jão das Couves";
            cliente.Cpf = "10020030011";
            cliente.DataNascimento= DateTime.Now.AddDays(-1);

            var produto = new Produto();
            produto.Descricao = "Sapo-boi azul";
            produto.Preco = 10.50;
            produto.Validade = DateTime.Now.AddDays(11);
            produto.Estoque = 1;
            produto.Ativo = true;

            var pedido = new Pedido();
            pedido.ClienteCpf = cliente.Cpf;
            pedido.NomeCliente = cliente.Nome;
            pedido.Produto = produto;
            pedido.Quantidade = 0;
            pedido.ValorTotalPedido();            
            pedido.StatusAtual = StatusPedido.emAndamento;

            // act

            PedidoException ex = Assert.Throws<PedidoException>(() => pedido.ValidarPedido());


            // assert

            Assert.That(ex.Message, Is.EqualTo("A quantidade de produtos não pode ser zero ou inferior!"));
        }
        /*
        * Quando validar pedido 
        * E a quantidade de produtos for menor que zero
        * Então deve lançar erro
        */
        [Test]
        public void Quando_ValidarProduto_E_AQuantidadeDeProdutosForMenorQueZero_Entao_DeveResultarEmErro()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Jão das Couves";
            cliente.Cpf = "10020030011";
            cliente.DataNascimento = DateTime.Now.AddDays(-1);

            var produto = new Produto();
            produto.Descricao = "Sapo-boi azul";
            produto.Preco = 10.50;
            produto.Validade = DateTime.Now.AddDays(11);
            produto.Estoque = 1;
            produto.Ativo = true;

            var pedido = new Pedido();
            pedido.ClienteCpf = cliente.Cpf;
            pedido.NomeCliente = cliente.Nome;
            pedido.Produto = produto;
            pedido.Quantidade = -1;
            pedido.ValorTotalPedido();
            pedido.StatusAtual = StatusPedido.emAndamento;

            // act

            PedidoException ex = Assert.Throws<PedidoException>(() => pedido.ValidarPedido());


            // assert

            Assert.That(ex.Message, Is.EqualTo("A quantidade de produtos não pode ser zero ou inferior!"));
        }

        /*
        * Quando validar produto
        * E o status atual for finalizado
        * Então deve lançar erro
        */
        [Test]
        public void Quando_ValidarProduto_E_OStatusAtualDoProdutoForFinalizado_Entao_DeveResultarEmErro()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Jão das Couves";
            cliente.Cpf = "10020030011";
            cliente.DataNascimento = DateTime.Now.AddDays(-1);

            var produto = new Produto();
            produto.Descricao = "Sapo-boi azul";
            produto.Preco = 10.50;
            produto.Validade = DateTime.Now.AddDays(11);
            produto.Estoque = 1;
            produto.Ativo = true;

            var pedido = new Pedido();
            pedido.ClienteCpf = cliente.Cpf;
            pedido.NomeCliente = cliente.Nome;
            pedido.Produto = produto;
            pedido.Quantidade = 1;
            pedido.ValorTotalPedido();
            pedido.StatusAtual = StatusPedido.finalizado;

            // act

            PedidoException ex = Assert.Throws<PedidoException>(() => pedido.ValidarPedido());

            // assert

            Assert.That(ex.Message, Is.EqualTo("O pedido foi finalizado, não pode ser alterado!"));
        }

        /*
        * Quando criar um pedido
        * E quantidade de produtos for maior que quantidade de produtos em estoque
        * Então deve lançar erro
        */
        [Test]
        public void Quando_CriarPedido_E_QuantidadeDeProdutosForMaiorQueQuantidadeDeProdutosEmEstoque_Entao_DeveResultarEmErro()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Jão das Couves";
            cliente.Cpf = "10020030011";
            cliente.DataNascimento = DateTime.Now.AddDays(-1);

            var produto = new Produto();
            produto.Descricao = "Sapo-boi azul";
            produto.Preco = 10.50;
            produto.Validade = DateTime.Now.AddDays(11);
            produto.Estoque = 2;
            produto.Ativo = true;

            var pedido = new Pedido();
            pedido.ClienteCpf = cliente.Cpf;
            pedido.NomeCliente = cliente.Nome;
            pedido.Produto = produto;
            pedido.Quantidade = 3;
            pedido.ValorTotalPedido();
            pedido.StatusAtual = StatusPedido.emAndamento;

            // act

            PedidoException ex = Assert.Throws<PedidoException>(() => pedido.ValidarPedido());

            // assert

            Assert.That(ex.Message, Is.EqualTo("Não há estoque suficiente!"));
        }

        /*
        * Quando validar produto
        * E a quantidade for maior que zero
        * E o valor do pedido for maior que zero
        * E estatus atual for diferente de finalizado
        * Tudo ok
        */
        [Test]
        public void TudoOk()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Jão das Couves";
            cliente.Cpf = "10020030011";
            cliente.DataNascimento = DateTime.Now.AddDays(-1);

            var produto = new Produto();
            produto.Descricao = "Sapo-boi azul";
            produto.Preco = 10.50;
            produto.Validade = DateTime.Now.AddDays(11);
            produto.Estoque = 10;
            produto.Ativo = true;

            var pedido = new Pedido();
            pedido.ClienteCpf = cliente.Cpf;
            pedido.NomeCliente = cliente.Nome;
            pedido.Produto = produto;
            pedido.Quantidade = 1;
            pedido.ValorTotalPedido();
            pedido.StatusAtual = StatusPedido.emAndamento;

            // action
            var ehValido = pedido.ValidarPedido();

            // assert
            Assert.IsTrue(ehValido);
        }
    }
}
