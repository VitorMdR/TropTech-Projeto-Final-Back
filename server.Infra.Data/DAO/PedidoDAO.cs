using server.Domain.Features.cliente;
using server.Domain.Features.pedido;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace server.Infra.Data.DAO
{
    public class PedidoDAO
    {
        private const string _connectionString = @"Data Source=.\SQLexpress;initial catalog=SERVERSOLUCAO;uid=sa;pwd=bocaum24;";

        public void AddPedidoComCliente(Pedido novoPedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PEDIDOS VALUES (@CPF_CLIENTE, @PRODUTO_ID, @DATAPEDIDO, @QTDPRODUTO, @STATUSPEDIDO, @VALORTOTAL)";


                    comando.Parameters.AddWithValue("@CPF_CLIENTE", novoPedido.ClienteCpf);
                    comando.Parameters.AddWithValue("@PRODUTO_ID", novoPedido.Produto.Id);
                    comando.Parameters.AddWithValue("@DATAPEDIDO", novoPedido.DataPedido);
                    comando.Parameters.AddWithValue("@QTDPRODUTO", novoPedido.Quantidade);
                    comando.Parameters.AddWithValue("@STATUSPEDIDO", novoPedido.StatusAtual);
                    comando.Parameters.AddWithValue("@VALORTOTAL", novoPedido.ValorPedido);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void AddPedidoSemCliente(Pedido novoPedido)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT PEDIDOS 
                                    (PRODUTO_ID, DATAPEDIDO, QTDPRODUTO, STATUSPEDIDO, VALORTOTAL)
                                    VALUES
                                (@PRODUTO_ID, @DATAPEDIDO, @QTDPRODUTO, @STATUSPEDIDO, @VALORTOTAL)";

                    comando.Parameters.AddWithValue("@PRODUTO_ID", novoPedido.Produto.Id);
                    comando.Parameters.AddWithValue("@DATAPEDIDO", novoPedido.DataPedido);
                    comando.Parameters.AddWithValue("@QTDPRODUTO", novoPedido.Quantidade);
                    comando.Parameters.AddWithValue("@STATUSPEDIDO", novoPedido.StatusAtual);
                    comando.Parameters.AddWithValue("@VALORTOTAL", novoPedido.ValorPedido);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DeletarPedido(int id)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM PEDIDOS WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", id);


                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }


        public List<Pedido> BuscarTodosPedidos()
        {
            var listaPedidos = new List<Pedido>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT P.ID as ID_PEDIDO,
                                    C.NOME,
                                    P.DATAPEDIDO,
                                    P.VALORTOTAL,
                                    P.STATUSPEDIDO
                                    FROM PEDIDOS P 
                                    LEFT JOIN CLIENTES C
                                    ON C.CPF = P.CPF_CLIENTE;";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Pedido pedidoLocalizado = new Pedido();

                        pedidoLocalizado.Id = int.Parse(leitor["ID_PEDIDO"].ToString());
                        if (leitor["NOME"].ToString() != null)
                        {
                            pedidoLocalizado.NomeCliente = leitor["NOME"].ToString();
                        }
                        pedidoLocalizado.DataPedido = Convert.ToDateTime(leitor["DATAPEDIDO"].ToString());
                        pedidoLocalizado.ValorPedido = Convert.ToDouble(leitor["VALORTOTAL"].ToString());
                        pedidoLocalizado.StatusAtual = (StatusPedido)int.Parse(leitor["STATUSPEDIDO"].ToString());


                        listaPedidos.Add(pedidoLocalizado);
                    }
                }
            }

            return listaPedidos;
        }
        public Pedido BuscarPedidoPorID(int id)
        {
            var pedido = new Pedido();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT P.ID as IDPEDIDO,
                                    C.NOME,
                                    P.DATAPEDIDO,
                                    P.VALORTOTAL,
                                    P.STATUSPEDIDO
                                    FROM PEDIDOS P 
                                    LEFT JOIN CLIENTES C
                                    ON C.CPF = P.CPF_CLIENTE
                                    WHERE P.ID = @ID;";

                    comando.Parameters.AddWithValue("@ID", id);
                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Pedido pedidoLocalizado = new Pedido();

                        pedidoLocalizado.Id = int.Parse(leitor["IDPEDIDO"].ToString());
                        if (leitor["NOME"].ToString() != null)
                        {
                            pedidoLocalizado.NomeCliente = leitor["NOME"].ToString();
                        }
                        pedidoLocalizado.DataPedido = Convert.ToDateTime(leitor["DATAPEDIDO"].ToString());
                        pedidoLocalizado.ValorPedido = Convert.ToDouble(leitor["VALORTOTAL"].ToString());
                        pedidoLocalizado.StatusAtual = (StatusPedido)int.Parse(leitor["STATUSPEDIDO"].ToString());

                        pedido = pedidoLocalizado;
                    }
                }
            }
            return pedido;
        }
        public void AtualizarStatusPedido(int id, StatusPedido status)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE PEDIDOS SET STATUSPEDIDO = @STATUSPEDIDO WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", id);
                    comando.Parameters.AddWithValue("@STATUSPEDIDO", status);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
    }
}