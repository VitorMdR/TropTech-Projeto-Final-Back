using server.Domain.Features.produto;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace server.Infra.Data.DAO
{
    public class ProdutoDAO
    {
        private const string _connectionString = @"Data Source=.\SQLexpress;initial catalog=SERVERSOLUCAO;uid=sa;pwd=bocaum24;";

        public void AdicionarNovoProduto(Produto produto)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PRODUTOS VALUES (@DESCRICAO, @PRECO, @DATAVALIDADE, @QTDESTOQUE, @ATIVO)";

                    comando.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
                    comando.Parameters.AddWithValue("@PRECO", produto.Preco);
                    comando.Parameters.AddWithValue("@DATAVALIDADE", produto.Validade);
                    comando.Parameters.AddWithValue("@QTDESTOQUE", produto.Estoque);
                    comando.Parameters.AddWithValue("@ATIVO", produto.Ativo);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Produto> BuscarProdutos()
        {
            var listaProdutos = new List<Produto>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT *
                                    FROM PRODUTOS";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoLocalizado = new Produto();

                        produtoLocalizado.Id = int.Parse(leitor["ID"].ToString());
                        produtoLocalizado.Descricao = leitor["DESCRICAO"].ToString();
                        produtoLocalizado.Preco = double.Parse(leitor["PRECO"].ToString());
                        produtoLocalizado.Estoque = int.Parse(leitor["QTDESTOQUE"].ToString());
                        produtoLocalizado.Validade = Convert.ToDateTime(leitor["DATAVALIDADE"].ToString());
                        produtoLocalizado.Ativo = bool.Parse(leitor["ATIVO"].ToString());

                        listaProdutos.Add(produtoLocalizado);
                    }
                }
            }

            return listaProdutos;
        }

        public List<Produto> BuscarProdutosAtivos()
        {
            {
                var listaProdutos = new List<Produto>();

                using (var conexao = new SqlConnection(_connectionString))
                {
                    conexao.Open();

                    using (var comando = new SqlCommand())
                    {
                        comando.Connection = conexao;

                        string sql = @"SELECT *
                                    FROM PRODUTOS 
                                    WHERE ATIVO = 1 
                                    AND QTDESTOQUE > 0";

                        comando.CommandText = sql;

                        SqlDataReader leitor = comando.ExecuteReader();

                        while (leitor.Read())
                        {
                            Produto produtoLocalizado = new Produto();

                            produtoLocalizado.Id = int.Parse(leitor["ID"].ToString());
                            produtoLocalizado.Descricao = leitor["DESCRICAO"].ToString();
                            produtoLocalizado.Preco = double.Parse(leitor["PRECO"].ToString());
                            produtoLocalizado.Estoque = int.Parse(leitor["QTDESTOQUE"].ToString());
                            produtoLocalizado.Validade = Convert.ToDateTime(leitor["DATAVALIDADE"].ToString());
                            produtoLocalizado.Ativo = bool.Parse(leitor["ATIVO"].ToString());

                            listaProdutos.Add(produtoLocalizado);
                        }
                    }
                }
                return listaProdutos;
            }
        }

        public Produto BuscarProdutosporId(int id)
        {
            var produto = new Produto();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT *
                                    FROM PRODUTOS 
                                    WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", id);
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Produto produtoLocalizado = new Produto();

                        produtoLocalizado.Id = int.Parse(leitor["ID"].ToString());
                        produtoLocalizado.Descricao = leitor["DESCRICAO"].ToString();
                        produtoLocalizado.Preco = double.Parse(leitor["PRECO"].ToString());
                        produtoLocalizado.Estoque = int.Parse(leitor["QTDESTOQUE"].ToString());
                        produtoLocalizado.Validade = Convert.ToDateTime(leitor["DATAVALIDADE"].ToString());
                        produtoLocalizado.Ativo = bool.Parse(leitor["ATIVO"].ToString());

                        produto = produtoLocalizado;
                    }
                }
            }
            return produto;
        }
        public void EditarProduto(Produto produto)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE PRODUTOS SET DESCRICAO = @DESCRICAO, PRECO = @PRECO, DATAVALIDADE = @DATAVALIDADE, QTDESTOQUE = @QTDESTOQUE, ATIVO = @ATIVO WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", produto.Id);
                    comando.Parameters.AddWithValue("@DESCRICAO", produto.Descricao);
                    comando.Parameters.AddWithValue("@PRECO", produto.Preco);
                    comando.Parameters.AddWithValue("@DATAVALIDADE", produto.Validade);
                    comando.Parameters.AddWithValue("@QTDESTOQUE", produto.Estoque);
                    comando.Parameters.AddWithValue("@ATIVO", produto.Ativo);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtivarOuDesativarProduto(int id, bool active)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE PRODUTOS SET ATIVO = @ATIVO WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", id);
                    comando.Parameters.AddWithValue("@ATIVO", active);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void GerenciarEstoque(int id, int quantidade)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE PRODUTOS SET QTDESTOQUE = @QTDESTOQUE WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", id);
                    comando.Parameters.AddWithValue("@QTDESTOQUE", quantidade);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarEstoque(int id, int quantidade)
        {
                        
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE PRODUTOS SET QTDESTOQUE = @QTDESTOQUE WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", id);
                    comando.Parameters.AddWithValue("@QTDESTOQUE", quantidade);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}
