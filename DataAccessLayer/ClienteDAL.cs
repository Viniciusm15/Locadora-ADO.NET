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
    public class ClienteDAL : IEntityCRUD<Cliente>
    {
        public Response Insert(Cliente item)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO CLIENTS ([NAME],CPF,EMAIL,BIRTH_DAY,ISACTIVE) VALUES (@NAME,@CPF,@EMAIL,@BIRTH_DAY,@ISACTIVE); select scope_identity()";
            sqlCommand.Parameters.AddWithValue(@"NAME", item.Name);
            sqlCommand.Parameters.AddWithValue(@"CPF", item.CPF);
            sqlCommand.Parameters.AddWithValue(@"EMAIL", item.Email);
            sqlCommand.Parameters.AddWithValue(@"BIRTH_DAY", item.Birth_Day.ToString("MM/dd/yyyy"));
            sqlCommand.Parameters.AddWithValue(@"ISACTIVE", item.IsActive);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                int idGerado = Convert.ToInt32(sqlCommand.ExecuteScalar());
                item.ID = idGerado;

                Response response = new Response();
                response.Sucesso = true;
                return response;
            }
            catch (Exception ex)
            {
                Response response = new Response();
                response.Sucesso = false;

                if (ex.Message.Contains("UQ_CLI_CPF"))
                {
                    response.Erros.Add("CPF já cadastrado.");
                }
                else if (ex.Message.Contains("UQ_CLI_EMAIL"))
                {
                    response.Erros.Add("Email já cadastrado.");
                }
                else
                {
                    response.Erros.Add("Erro no banco de dados, contate o ADM!");
                    File.WriteAllText("log.txt", ex.Message);
                }
                return response;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public Response Update(Cliente item)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"UPDATE CLIENTS SET NAME = @NAME, 
                                                          CPF = @CPF,
                                                          EMAIL = @EMAIL,
                                                          BIRTH_DAY = @BIRTH_DAY,
                                                          ISACTIVE = @ISACTIVE 
                                                          WHERE ID = @ID";

            sqlCommand.Parameters.AddWithValue(@"NAME", item.Name);
            sqlCommand.Parameters.AddWithValue(@"CPF", item.CPF);
            sqlCommand.Parameters.AddWithValue(@"EMAIL", item.Email);
            sqlCommand.Parameters.AddWithValue(@"BIRTH_DAY", item.Birth_Day);
            sqlCommand.Parameters.AddWithValue(@"ISACTIVE", item.IsActive);
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

                if (ex.Message.Contains("UQ_CLI_CPF"))
                {
                    response.Erros.Add("CPF já cadastrado.");
                }
                else if (ex.Message.Contains("UQ_CLI_EMAIL"))
                {
                    response.Erros.Add("Email já cadastrado.");
                }
                else
                {
                    response.Erros.Add("Erro no banco de dados, contate o ADM!");
                    File.WriteAllText("log.txt", ex.Message);
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
            sqlCommand.CommandText = "DELETE FROM CLIENTS WHERE ID = @ID";
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

                if (ex.Message.Contains("UQ_CLI_CPF"))
                {
                    response.Erros.Add("CPF já cadastrado.");
                }
                else if (ex.Message.Contains("UQ_CLI_EMAIL"))
                {
                    response.Erros.Add("Email já cadastrado.");
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

        public DataResponse<Cliente> GetData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM CLIENTS";
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Cliente> clientes = new List<Cliente>();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NAME"]);
                    string cpf = Convert.ToString(reader["CPF"]);
                    string email = Convert.ToString(reader["EMAIL"]);
                    DateTime birth_day = Convert.ToDateTime(reader["BIRTH_DAY"]);
                    bool isactive = Convert.ToBoolean(reader["ISACTIVE"]);

                    Cliente cliente = new Cliente(id, nome, cpf, email, birth_day, isactive);
                    clientes.Add(cliente);
                }

                DataResponse<Cliente> Dataresponse = new DataResponse<Cliente>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = clientes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Cliente> dataResponse = new DataResponse<Cliente>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<Cliente> GetByID(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM CLIENTS WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Cliente> clientes = new List<Cliente>();

                //Se houver registro, leia!
                if (reader.Read())
                {
                    //Exemplo utilizando cast, é veloz porém perigoso em caso de migração de base.
                    //string nome = (string)reader["Name"];

                    //Criando um gênero para representar o registro no banco.
                    Cliente cliente = new Cliente(id,
                                                 (string)reader["NAME"],
                                                 (string)reader["CPF"],
                                                 (string)reader["EMAIL"],
                                                 (DateTime)reader["BIRTH_DAY"],
                                                 (bool)reader["isactive"]);
                    //Adicionando o gênero na lista criada. (generos)
                    clientes.Add(cliente);
                }

                DataResponse<Cliente> Dataresponse = new DataResponse<Cliente>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = clientes;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Cliente> dataResponse = new DataResponse<Cliente>();
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
