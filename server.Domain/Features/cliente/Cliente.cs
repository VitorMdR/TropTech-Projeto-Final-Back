using System;

namespace server.Domain.Features.cliente
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public double PontosFidelidade { get; set; }
        public Cliente()
        {

        }

        public void AtualizaFidelidade(double valor)
        {
            PontosFidelidade += (valor * 2);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public bool ValidarCliente()
        {
            if (Nome.Length < 3)
                throw new ClienteException("O nome deve conter no mínomo 3 caracteres!");

            if (string.IsNullOrWhiteSpace(this.Nome))
                throw new ClienteException("O nome do cliente não pode ser vazio!");

            if (string.IsNullOrWhiteSpace(this.Cpf))
                throw new ClienteException("O cpf não pode ser vazio.");

            if (this.Cpf.Length != 11)
                throw new ClienteException("O CPF deve conter 11 dígitos númericos");

            if (this.DataNascimento > DateTime.Now)
                throw new ClienteException("A data de nascimento deve ser anterior a hoje!");

            return true;
        }
    }
}
