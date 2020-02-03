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
    public class GeneroDAL : IEntityCRUD<Genero>
    {
        /// <summary>
        /// Método que insere o gênero em uma base SQL Server.
        /// Este objeto gênero chamado de "item", é criado na camada PresentationLayer (Windows Form) e validado na camada
        /// BusinessLogicalLayer (BLL) até chegar a este ponto, prontinho para ser cadastrado no banco!
        /// </summary>
        /// <param name="item"></param>
        public Response Insert(Genero item)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO GENERS ([NAME]) VALUES (@NAME); select scope_identity()";
            sqlCommand.Parameters.AddWithValue(@"NAME", item.Nome);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                int idGerado = Convert.ToInt32(sqlCommand.ExecuteScalar());
                item.ID = idGerado;

                //Criar o objeto que representa a resposta do banco!
                Response response = new Response();
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Sucesso = false;

                if (ex.Message.Contains("UQ"))
                {
                    response.Erros.Add("Gênero já cadastrado!");
                }
                else
                {
                    response.Erros.Add("Erro no banco de dados, contate o ADM!");
                    File.WriteAllText("log.txt", ex.Message);
                    return response;
                }

                return response;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public Response Update(Genero item)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"UPDATE GENERS SET NAME = @NAME
                                                         WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue(@"NAME", item.Nome);
            sqlCommand.Parameters.AddWithValue(@"ID", item.ID);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                int NLinhasAfetadas = sqlCommand.ExecuteNonQuery();

                Response response = new Response();
                if (NLinhasAfetadas != 1)
                {
                    response.Sucesso = false;
                    response.Erros.Add("ID do gênero deve ser informado.");
                    return response;
                }

                //Criar o objeto que representa a resposta do banco!
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Sucesso = false;

                if (ex.Message.Contains("UQ"))
                {
                    response.Erros.Add("Gênero já cadastrado!");
                }
                else
                {
                    response.Erros.Add("Erro no banco de dados, contate o ADM!");
                    File.WriteAllText("log.txt", ex.Message);
                    return response;
                }

                return response;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public Response Delete(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM GENERS WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue(@"ID", id);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                int NLinhasAfetadas = sqlCommand.ExecuteNonQuery();

                Response response = new Response();
                if (NLinhasAfetadas != 1)
                {
                    response.Sucesso = false;
                    response.Erros.Add("ID do gênero deve ser informado.");
                    return response;
                }

                //Criar o objeto que representa a resposta do banco!
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Sucesso = false;

                if (ex.Message.Contains("UQ"))
                {
                    response.Erros.Add("Gênero já cadastrado!");
                }
                else
                {
                    response.Erros.Add("Erro no banco de dados, contate o ADM!");
                    File.WriteAllText("log.txt", ex.Message);
                    return response;
                }

                return response;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<Genero> GetData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM GENERS";
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Genero> generos = new List<Genero>();

                //Enquanto houver registros, leia!
                while (reader.Read())
                {
                    //Exemplo utilizando cast, é veloz porém perigoso em caso de migração de base.
                    //string nome = (string)reader["Name"];
                    int id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NAME"]);
                    
                    //Criando um gênero para representar o registro no banco.
                    Genero genero = new Genero(id, nome);
                    //Adicionando o gênero na lista criada. (generos)
                    generos.Add(genero);
                }

                DataResponse<Genero> Dataresponse = new DataResponse<Genero>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = generos;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Genero> dataResponse = new DataResponse<Genero>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<Genero> GetByID(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM GENERS WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Genero> generos = new List<Genero>();

                //Se houver registro, leia!
                if (reader.Read())
                {

                    //Criando um genero para representar o registro no banco.
                    Genero genero = new Genero(id,
                                              (string)reader["NAME"]);
                    //Adicionando o genero na lista criada. (generos)
                    generos.Add(genero);
                }

                DataResponse<Genero> Dataresponse = new DataResponse<Genero>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = generos;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Genero> dataResponse = new DataResponse<Genero>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}
