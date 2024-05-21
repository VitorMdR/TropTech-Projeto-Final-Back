using System;

namespace server.Domain.Features.produto
{
    public class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public DateTime Validade { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }
        public Produto()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void AddEstoque(int qtd)
        {

            this.Estoque += qtd;
        }
        public void DiminuirEstoque(int qtd)
        {

            this.Estoque -= qtd;
        }


        public bool ValidarProduto()
        {
            if (string.IsNullOrEmpty(Descricao))
                throw new ProdutoException("O produto deve conter uma descrição!");

            if (Descricao.Length < 3)
                throw new ProdutoException("A descrição do produto deve conter três ou mais letras!");

            if (Preco < 1)
                throw new ProdutoException("O preço deve ser superior a zero!");

            if (Validade < DateTime.Now)
                throw new ProdutoException("A data de vencimento não pode ser inferior a hoje!");

            if (Estoque != 0)

                throw new ProdutoException("O produto deve iniciar com estoque zero!");

            if (!Ativo)
                throw new ProdutoException("O produto deve iniciar Ativo!");

            return true;
        }
    }
}
