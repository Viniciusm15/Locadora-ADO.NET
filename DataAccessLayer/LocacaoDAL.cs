using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class LocacaoDAL : ILocacaoService
    {
        public Response EfeturarLocacao(Locacao locacao)
        {
            //I/O -> INPUT/OUTPUT
            //Arquivos
            //Conexões
            //NetWork (Comunicação com qualquer hardware externo)
            string connectionString = SqlData.ConnectionString;
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = SqlData.ConnectionString;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = "INSERT INTO LOCACOES VALUES (@CLIENT, @FUNCTIONARY, @PRECO, @DATALOCACAO, @DATADEVOLUCAOPREVISTA, @DATADEVOLUCAO, @MULTA, @FOIPAGO); select scope_identity()";
                sqlCommand.Parameters.AddWithValue(@"CLIENT", locacao.Cliente.ID);
                sqlCommand.Parameters.AddWithValue(@"FUNCTIONARY", locacao.Funcionario.ID);
                sqlCommand.Parameters.AddWithValue(@"PRECO", locacao.Preco);
                sqlCommand.Parameters.AddWithValue(@"DATALOCACAO", locacao.DataLocacao);
                sqlCommand.Parameters.AddWithValue(@"DATADEVOLUCAOPREVISTA", locacao.DataDevolucaoPrevista);
                sqlCommand.Parameters.AddWithValue(@"DATADEVOLUCAO", DBNull.Value);
                sqlCommand.Parameters.AddWithValue(@"MULTA", locacao.Multa);
                sqlCommand.Parameters.AddWithValue(@"FOIPAGO", locacao.FoiPago);
                sqlCommand.Connection = connection;

                try
                {
                    connection.Open();
                    int idGerado = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    locacao.ID = idGerado;

                    //Criar o objeto que representa a resposta do banco!
                    Response response = new Response();
                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
                    Response response = new Response();
                    response.Sucesso = false;

                    if (ex.Message.Contains("FK_LOCACOES_CLIENT"))
                    {
                        response.Erros.Add("Cliente inexistente.");
                    }
                    else if (ex.Message.Contains("FK_LOCACOES_FUNCTIONARY"))
                    {
                        response.Erros.Add("Funcionário inexistente.");
                    }
                    else
                    {
                        response.Erros.Add("Erro no banco de dados, contate o ADM!");
                    }

                    File.WriteAllText("log.txt", ex.Message + " - " + ex.StackTrace);
                    return response;
                }
            }//O using Fecha a conexão automaticamente.
        }

        public Response EfetuarFilmesLocacao(Locacao locacao)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO LOCACOES_FILMES VALUES (@LOCACAOID, @FILMEID);";
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();

                foreach (Filme filme in locacao.filmes)
                {
                    sqlCommand.Parameters.AddWithValue(@"LOCACAOID", locacao.ID);
                    sqlCommand.Parameters.AddWithValue(@"FILMEID", filme.ID);
                    sqlCommand.ExecuteNonQuery();
                    sqlCommand.Parameters.Clear();
                }

                //Criar o objeto que representa a resposta do banco!
                Response response = new Response();
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Sucesso = false;

                response.Erros.Add("Erro no banco de dados, contate o ADM!");
                File.WriteAllText("log.txt", ex.Message);
                return response;
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}