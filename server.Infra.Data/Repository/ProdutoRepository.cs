using server.Domain.Features.produto;
using server.Domain.Interfaces;
using server.Infra.Data.DAO;
using System;
using System.Collections.Generic;

namespace server.Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private ProdutoDAO _produtoDAO = new ProdutoDAO();
        

        public void AdicionarNovoProduto(Produto produto)
        {
            _produtoDAO.AdicionarNovoProduto(produto);
        }

        public void EditarProduto(Produto produto)
        {
            _produtoDAO.EditarProduto(produto);
        }
        public Produto BuscarProdutoPorId(int id)
        {   var produto = _produtoDAO.BuscarProdutosporId(id);
            return produto;
        }
        public void AtivarOuDesativarProduto(int id, bool ativo)
        {
            _produtoDAO.AtivarOuDesativarProduto(id, ativo);
        }

        public void AtualizarEstoque(Produto produto)
        {
            var produtoEstoque = BuscarProdutoPorId(produto.Id);
            produtoEstoque.AddEstoque(produto.Estoque);
            _produtoDAO.GerenciarEstoque(produtoEstoque.Id, produtoEstoque.Estoque);
        }

        public List<Produto> BuscarTodosProdutos()
        {
            var lista = _produtoDAO.BuscarProdutos();
            return lista;
        }
        public List<Produto> BuscarProdutosAtivos()
        {
            var listaProdutosAtivos = _produtoDAO.BuscarProdutosAtivos();
            return listaProdutosAtivos;
        }
    }
}
