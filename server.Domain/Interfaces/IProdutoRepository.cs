using server.Domain.Features.produto;
using System.Collections.Generic;

namespace server.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        void AdicionarNovoProduto(Produto novoProduto);
        void EditarProduto(Produto novoProduto);
        void AtualizarEstoque(Produto product);
        void AtivarOuDesativarProduto(int id, bool ativo);    
        List<Produto> BuscarTodosProdutos();
        Produto BuscarProdutoPorId(int id);
        List<Produto> BuscarProdutosAtivos();
    }
}
