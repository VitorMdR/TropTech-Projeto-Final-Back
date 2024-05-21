﻿using NUnit.Framework;
using server.Domain.Features.cliente;
using System;

namespace server.Tests
{
    public class ClienteUnitTests
    {
        /*
         * Quando validar cliente
         * E nome menor que três
         * Então deve resultar em cliente inválido
         */
        [Test]
        public void Quando_ValidarProduto_E_NomeMenorQueTres_Entao_DeveEstourarExcecao()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "To";
            cliente.Cpf = "12345678912";
            cliente.DataNascimento= DateTime.Now.AddDays(-3);

            // act

            ClienteException ex = Assert.Throws<ClienteException>(() => cliente.ValidarCliente());


            // assert

            Assert.That(ex.Message, Is.EqualTo("O nome deve conter no mínomo 3 caracteres!"));
        }

        /*
         * Quando validar cliente
         * E nome for vazio 
         * Então deve resultar em cliente inválido
         */
        [Test]
        public void Quando_ValidarProduto_E_NomeNaoForInformado_Entao_DeveResultarEmFalse()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = " ";
            cliente.Cpf = "12345678912";
            cliente.DataNascimento = DateTime.Now.AddDays(-3);

            // act

            ClienteException ex = Assert.Throws<ClienteException>(() => cliente.ValidarCliente());


            // assert

            Assert.That(ex.Message, Is.EqualTo("O nome deve conter no mínomo 3 caracteres!"));
        }

        /*
         * Quando validar cliente
         * E cpf não for informado 
         * Então deve resultar em cliente inválido
         */
        [Test]
        public void Quando_ValidarProduto_E_CpfNaoForInformado_Entao_DeveResultarEmFalse()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Tonho da Lua";
            cliente.Cpf = " ";
            cliente.DataNascimento = DateTime.Now.AddDays(-3);

            // act

            ClienteException ex = Assert.Throws<ClienteException>(() => cliente.ValidarCliente());


            // assert

            Assert.That(ex.Message, Is.EqualTo("O cpf não pode ser vazio."));
        }

        /*
         * Quando validar cliente
         * E cpf for diferente de 11 digitos númericos
         * Então deve resultar em cliente inválido
         */
        [Test]
        public void Quando_ValidarProduto_E_CpfForDiferenteDeOnze_Entao_DeveResultarEmFalse()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Tonho da Lua";
            cliente.Cpf = "123123";
            cliente.DataNascimento = DateTime.Now.AddDays(-3);

            // act

            ClienteException ex = Assert.Throws<ClienteException>(() => cliente.ValidarCliente());


            // assert

            Assert.That(ex.Message, Is.EqualTo("O CPF deve conter 11 dígitos númericos"));
        }

        /*
         * Quando validar produto
         * E data de nascimento for maior que hoje
         * Então deve resultar em produto inválido
         */
        [Test]
        public void Quando_ValidarProduto_E_DataDeNascimentoForMaiorQueHoje_Entao_DeveResultarEmFalse()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Tonho da Lua";
            cliente.Cpf = "12312312312";
            cliente.DataNascimento = DateTime.Now.AddDays(1);

            // act

            ClienteException ex = Assert.Throws<ClienteException>(() => cliente.ValidarCliente());


            // assert

            Assert.That(ex.Message, Is.EqualTo("A data de nascimento deve ser anterior a hoje!"));
        }

        /*
         * Quando validar produto
         * E nome é diferente de vazio
         * E cpf é válido
         * E data de nascimento é válida
         * O caminho é feliz
         */
        [Test]
        public void CaminhoFeliz()
        {
            // arrange
            var cliente = new Cliente();
            cliente.Nome = "Tonho da Lua";
            cliente.Cpf = "12312312312";
            cliente.DataNascimento = DateTime.Now.AddMonths(-1);

            // action
            var ehValido = cliente.ValidarCliente();

            // assert
            Assert.IsTrue(ehValido);
        }
    }
}
