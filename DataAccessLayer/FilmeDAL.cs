using Entities;
using Entities.Enums;
using Entities.ResultSets;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class FilmeDAL : IEntityCRUD<Filme>, IFilmeService
    {
        public Response Insert(Filme item)
        {

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO FILMS VALUES (@NAME,@RELEASEDATE,@CLASSIFICATION,@DURATION,@GENERID); select scope_identity()";
            sqlCommand.Parameters.AddWithValue(@"NAME", item.Nome);
            sqlCommand.Parameters.AddWithValue(@"RELEASEDATE", item.DataLancamento);
            sqlCommand.Parameters.AddWithValue(@"CLASSIFICATION", item.Classificacao);
            sqlCommand.Parameters.AddWithValue(@"DURATION", item.Duracao);
            sqlCommand.Parameters.AddWithValue(@"GENERID", item.GeneroID);
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

                if (ex.Message.Contains("FK"))
                {
                    response.Erros.Add("Gênero não encontrado.");
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

        public Response Update(Filme item)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"UPDATE FILMS SET NAME = @NAME, 
                                                        RELEASEDATE = @RELEASEDATE,
                                                        CLASSIFICATION = @CLASSIFICATION,
                                                        DURATION = @DURATION,
                                                        GENERID = @GENERID 
                                                        WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue(@"NAME", item.Nome);
            sqlCommand.Parameters.AddWithValue(@"RELEASEDATE", item.DataLancamento);
            sqlCommand.Parameters.AddWithValue(@"CLASSIFICATION", item.Classificacao);
            sqlCommand.Parameters.AddWithValue(@"DURATION", item.Duracao);
            sqlCommand.Parameters.AddWithValue(@"GENERID", item.GeneroID);
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
                    response.Erros.Add("ID do cliente deve ser informado.");
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

                if (ex.Message.Contains("FK"))
                {
                    response.Erros.Add("Gênero não encontrado.");
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
            sqlCommand.CommandText = "DELETE FROM FILMS WHERE ID = @ID";
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
                    response.Erros.Add("ID do cliente deve ser informado.");
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

                if (ex.Message.Contains("LOCACAOES_FILMES"))
                {
                    response.Erros.Add("Filme não pode ser excluído, pois não há locações.");
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

        public DataResponse<Filme> GetData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM FILMS";
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Filme> LFilmes = new List<Filme>();

                //Enquanto houver registros, leia!
                while (reader.Read())
                {
                    //Exemplo utilizando cast, é veloz porém perigoso em caso de migração de base.
                    //string nome = (string)reader["Name"];
                    int id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NAME"]);
                    DateTime dataLancamento = Convert.ToDateTime(reader["RELEASEDATE"]);
                    Classificacao classificacao = (Classificacao)reader["CLASSIFICATION"];
                    int duracao = Convert.ToInt32(reader["DURATION"]);
                    int generoID = Convert.ToInt32(reader["GENERID"]);

                    //Criando um gênero para representar o registro no banco.
                    Filme filmes = new Filme(id, nome, dataLancamento, classificacao, duracao, generoID);
                    //Adicionando o gênero na lista criada. (generos)
                    LFilmes.Add(filmes);
                }

                DataResponse<Filme> Dataresponse = new DataResponse<Filme>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = LFilmes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Filme> dataResponse = new DataResponse<Filme>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<Filme> GetByID(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM FILMS WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Filme> filmes = new List<Filme>();

                //Se houver registro, leia!
                if (reader.Read())
                {
                    //Exemplo utilizando cast, é veloz porém perigoso em caso de migração de base.
                    //string nome = (string)reader["Name"];

                    //Criando um filme para representar o registro no banco.
                    Filme filme = new Filme(id,
                                            (string)reader["NAME"],
                                            (DateTime)reader["RELEASEDATE"],
                                            (Classificacao)reader["CLASSIFICATION"],
                                            (int)reader["DURATION"],
                                            (int)reader["GENERID"]);
                    //Adicionando o filme na lista criada. (filmes)
                    filmes.Add(filme);
                }

                DataResponse<Filme> Dataresponse = new DataResponse<Filme>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = filmes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Filme> dataResponse = new DataResponse<Filme>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<FilmeResultSet> GetFilmes()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT F.ID, F.[NAME], G.[NAME] AS GENERS, F.[CLASSIFICATION] FROM FILMS F
                                       INNER JOIN GENERS G
                                       ON F.GENERID = G.ID";
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<FilmeResultSet> filmes = new List<FilmeResultSet>();

                //Enquanto houver registros, leia!
                while (reader.Read())
                {
                    FilmeResultSet filme = new FilmeResultSet();
                    filme.ID = (int)reader[0];
                    filme.Nome = (string)reader[1];
                    filme.Genero = (string)reader[2];
                    filme.Classificacao = (Classificacao)reader[3];

                    filmes.Add(filme);
                }

                DataResponse<FilmeResultSet> Dataresponse = new DataResponse<FilmeResultSet>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = filmes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<FilmeResultSet> dataResponse = new DataResponse<FilmeResultSet>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<FilmeResultSet> GetFilmesByName(string nome)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT F.ID, F.[NAME], G.[NAME] AS GENERS, F.[CLASSIFICATION] FROM FILMS F
                                       INNER JOIN GENERS G
                                       ON F.GENERID = G.ID
                                       WHERE F.[NAME] LIKE @NAME";

            sqlCommand.Parameters.AddWithValue("@NAME", "%" + nome + "%");
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<FilmeResultSet> filmes = new List<FilmeResultSet>();

                //Enquanto houver registros, leia!
                while (reader.Read())
                {
                    FilmeResultSet filme = new FilmeResultSet();
                    filme.ID = (int)reader[0];
                    filme.Nome = (string)reader[1];
                    filme.Genero = (string)reader[2];
                    filme.Classificacao = (Classificacao)reader[3];

                    filmes.Add(filme);
                }

                DataResponse<FilmeResultSet> Dataresponse = new DataResponse<FilmeResultSet>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = filmes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<FilmeResultSet> dataResponse = new DataResponse<FilmeResultSet>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<FilmeResultSet> GetFilmesByGener(int genero)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT F.ID, F.[NAME], G.[NAME] AS GENERS, F.[CLASSIFICATION] FROM FILMS F
                                       INNER JOIN GENERS G
                                       ON F.GENERID = G.ID
                                       WHERE G.ID = @ID";
            sqlCommand.Parameters.AddWithValue("@ID", genero);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<FilmeResultSet> filmes = new List<FilmeResultSet>();

                //Enquanto houver registros, leia!
                while (reader.Read())
                {
                    FilmeResultSet filme = new FilmeResultSet();
                    filme.ID = (int)reader[0];
                    filme.Nome = (string)reader[1];
                    filme.Genero = (string)reader[2];
                    filme.Classificacao = (Classificacao)reader[3];

                    filmes.Add(filme);
                }

                DataResponse<FilmeResultSet> Dataresponse = new DataResponse<FilmeResultSet>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = filmes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<FilmeResultSet> dataResponse = new DataResponse<FilmeResultSet>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<FilmeResultSet> GetFilmesByClassification(Classificacao classificacao)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"SELECT F.ID, F.[NAME], G.[NAME] AS GENERS, F.[CLASSIFICATION] FROM FILMS F
                                       INNER JOIN GENERS G
                                       ON F.GENERID = G.ID
                                       WHERE F.[CLASSIFICATION] = @CLASSIFICATION";
            sqlCommand.Parameters.AddWithValue("@CLASSIFICATION", classificacao);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<FilmeResultSet> filmes = new List<FilmeResultSet>();

                //Enquanto houver registros, leia!
                while (reader.Read())
                {
                    FilmeResultSet filme = new FilmeResultSet();
                    filme.ID = (int)reader[0];
                    filme.Nome = (string)reader[1];
                    filme.Genero = (string)reader[2];
                    filme.Classificacao = (Classificacao)reader[3];

                    filmes.Add(filme);
                }

                DataResponse<FilmeResultSet> Dataresponse = new DataResponse<FilmeResultSet>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = filmes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<FilmeResultSet> dataResponse = new DataResponse<FilmeResultSet>();
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