using server.Domain.Features.cliente;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace server.Infra.Data.DAO
{
    public class ClienteDAO
    {
        private const string _connectionString = @"Data Source=.\SQLexpress;initial catalog=SERVERSOLUCAO;uid=sa;pwd=bocaum24;";

        
        public void AdicionarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"INSERT CLIENTES VALUES (@NOME, @CPF, @DATANASCIMENTO, @PONTOSFIDELIDADE)";

                    comando.Parameters.AddWithValue("@NOME", cliente.Nome);
                    comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
                    comando.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);
                    comando.Parameters.AddWithValue("@PONTOSFIDELIDADE", cliente.PontosFidelidade);

                    
                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DeletarCliente(string cpf)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"DELETE FROM CLIENTES WHERE CPF = @CPF;";

                    comando.Parameters.AddWithValue("@CPF", cpf);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }

        public void DeletarPedidosPorCpf(string cpf)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;
                    string sql = @"DELETE FROM PEDIDOS WHERE CPF_CLIENTE = @CPF_DIGITADO";
                    comando.Parameters.AddWithValue("@CPF_DIGITADO", cpf);
                    comando.CommandText = sql;
                    comando.ExecuteNonQuery();
                }
            }
        }

        public Cliente BuscaClientePorCpf(string cpf)
        {
            var cliente = new Cliente();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT *
                                    FROM CLIENTES WHERE CPF = @CPF";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@CPF", cpf);

                    SqlDataReader leitor = comando.ExecuteReader();
                    
                    while (leitor.Read())
                    {
                        Cliente clienteLocalizado = new Cliente();

                        clienteLocalizado.Id = int.Parse(leitor["ID"].ToString());
                        clienteLocalizado.Nome = leitor["NOME"].ToString();
                        clienteLocalizado.Cpf = leitor["CPF"].ToString();
                        clienteLocalizado.DataNascimento = Convert.ToDateTime(leitor["DATANASCIMENTO"].ToString());
                        clienteLocalizado.PontosFidelidade = double.Parse(leitor["PONTOSFIDELIDADE"].ToString());
                        cliente = clienteLocalizado;

                    }
                }
            }
            if(cliente != null)
            {
                return cliente;
            }
            return null;
        }

        public Cliente BuscaClientePorId(int id)
        {
            var cliente = new Cliente();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT *
                                    FROM CLIENTES WHERE Id = @ID";

                    comando.CommandText = sql;

                    comando.Parameters.AddWithValue("@ID", id);

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteLocalizado = new Cliente();

                        clienteLocalizado.Id = int.Parse(leitor["ID"].ToString());
                        clienteLocalizado.Nome = leitor["NOME"].ToString();
                        clienteLocalizado.Cpf = leitor["CPF"].ToString();
                        clienteLocalizado.DataNascimento = Convert.ToDateTime(leitor["DATANASCIMENTO"].ToString());
                        clienteLocalizado.PontosFidelidade = double.Parse(leitor["PONTOSFIDELIDADE"].ToString());
                        cliente = clienteLocalizado;

                    }
                }
            }
            if (cliente != null)
            {
                return cliente;
            }
            return null;
        }

        public void EditarCliente(Cliente cliente)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE CLIENTES SET NOME = @NOME, CPF = @CPF, DATANASCIMENTO = @DATANASCIMENTO WHERE ID = @ID";

                    comando.Parameters.AddWithValue("@ID", cliente.Id);
                    comando.Parameters.AddWithValue("@NOME", cliente.Nome);
                    comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
                    comando.Parameters.AddWithValue("@DATANASCIMENTO", cliente.DataNascimento);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void AdicionarPontosFidelidade(string cpf, double pontosFidelidade)
        {
            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"UPDATE CLIENTES SET PONTOSFIDELIDADE = @PONTOSFIDELIDADE WHERE CPF = @CPF";

                    comando.Parameters.AddWithValue("@CPF", cpf);
                    comando.Parameters.AddWithValue("@PONTOSFIDELIDADE", pontosFidelidade);

                    comando.CommandText = sql;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Cliente> BuscaClientes()
        {
            var listaClientes = new List<Cliente>();

            using (var conexao = new SqlConnection(_connectionString))
            {
                conexao.Open();

                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexao;

                    string sql = @"SELECT *
                                    FROM CLIENTES";

                    comando.CommandText = sql;

                    SqlDataReader leitor = comando.ExecuteReader();

                    while (leitor.Read())
                    {
                        Cliente clienteLocalizado = new Cliente();

                        clienteLocalizado.Id = int.Parse(leitor["ID"].ToString());
                        clienteLocalizado.Nome = leitor["NOME"].ToString();
                        clienteLocalizado.Cpf = leitor["CPF"].ToString();
                        clienteLocalizado.DataNascimento = Convert.ToDateTime(leitor["DATANASCIMENTO"].ToString());
                        clienteLocalizado.PontosFidelidade = double.Parse(leitor["PONTOSFIDELIDADE"].ToString());
                     
                        listaClientes.Add(clienteLocalizado);
                    }
                }
            }
            return listaClientes;
        }

    }
}
