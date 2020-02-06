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
    public class FuncionarioDAL : IEntityCRUD<Funcionario>, IFuncionarioService
    {
        public Response Insert(Funcionario item)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "INSERT INTO FUNCTIONARIES ([NAME],BIRTH_DATE,CPF,EMAIL,TELEPHONE,[PASSWORD],ISACTIVE) VALUES (@NAME,@BIRTH_DATE,@CPF,@EMAIL,@TELEPHONE,@PASSWORD,@ISACTIVE); select scope_identity()";
            sqlCommand.Parameters.AddWithValue(@"NAME", item.Name);
            sqlCommand.Parameters.AddWithValue(@"BIRTH_DATE", item.BirthDate);
            sqlCommand.Parameters.AddWithValue(@"CPF", item.CPF);
            sqlCommand.Parameters.AddWithValue(@"EMAIL", item.Email);
            sqlCommand.Parameters.AddWithValue(@"TELEPHONE", item.Telephone);
            sqlCommand.Parameters.AddWithValue(@"PASSWORD", item.Password);
            sqlCommand.Parameters.AddWithValue(@"ISACTIVE", item.IsActive);
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

                if (ex.Message.Contains("UQ_FUN_CPF"))
                {
                    response.Erros.Add("CPF já cadastrado.");
                }
                else if (ex.Message.Contains("UQ_FUN_EMAIL"))
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

        public Response Update(Funcionario item)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = @"UPDATE FUNCTIONARIES SET NAME = @NAME, 
                                                                BIRTH_DATE = @BIRTH_DATE,
                                                                CPF = @CPF,
                                                                EMAIL = @EMAIL,
                                                                TELEPHONE = @TELEPHONE,
                                                                PASSWORD = @PASSWORD,
                                                                ISACTIVE = @ISACTIVE  
                                                                WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue(@"NAME", item.Name);
            sqlCommand.Parameters.AddWithValue(@"BIRTH_DATE", item.BirthDate);
            sqlCommand.Parameters.AddWithValue(@"CPF", item.CPF);
            sqlCommand.Parameters.AddWithValue(@"EMAIL", item.Email);
            sqlCommand.Parameters.AddWithValue(@"TELEPHONE", item.Telephone);
            sqlCommand.Parameters.AddWithValue(@"PASSWORD", item.Password);
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

                if (ex.Message.Contains("UQ_FUN_CPF"))
                {
                    response.Erros.Add("CPF já cadastrado.");
                }
                else if (ex.Message.Contains("UQ_FUN_EMAIL"))
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

        public Response Delete(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "DELETE FROM FUNCTIONARIES WHERE ID = @ID";
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
                    response.Erros.Add("ID do funcionário deve ser informado.");
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

                if (ex.Message.Contains("UQ_FUN_CPF"))
                {
                    response.Erros.Add("CPF já cadastrado.");
                }
                else if (ex.Message.Contains("UQ_FUN_EMAIL"))
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

        public DataResponse<Funcionario> GetData()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM FUNCTIONARIES";
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Funcionario> Funcionarios = new List<Funcionario>();

                //Enquanto houver registros, leia!
                while (reader.Read())
                {
                    //Exemplo utilizando cast, é veloz porém perigoso em caso de migração de base.
                    //string nome = (string)reader["Name"];
                    int id = Convert.ToInt32(reader["ID"]);
                    string nome = Convert.ToString(reader["NAME"]);
                    DateTime dataNascimento = Convert.ToDateTime(reader["BIRTH_DATE"]);
                    string CPF = Convert.ToString(reader["CPF"]);
                    string email = Convert.ToString(reader["EMAIL"]);
                    string telefone = Convert.ToString(reader["TELEPHONE"]);
                    string senha = Convert.ToString(reader["PASSWORD"]);
                    bool ehAtivo = Convert.ToBoolean(reader["ISACTIVE"]);

                    //Criando um gênero para representar o registro no banco.
                    Funcionario funcionario = new Funcionario(id, nome, dataNascimento, CPF, email, telefone, senha, ehAtivo);
                    //Adicionando o gênero na lista criada. (generos)
                    Funcionarios.Add(funcionario);
                }

                DataResponse<Funcionario> Dataresponse = new DataResponse<Funcionario>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = Funcionarios;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Funcionario> dataResponse = new DataResponse<Funcionario>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<Funcionario> GetByID(int id)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SELECT * FROM FUNCTIONARIES WHERE ID = @ID";
            sqlCommand.Parameters.AddWithValue("@ID", id);
            sqlCommand.Connection = connection;

            try
            {
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Funcionario> funcionarios = new List<Funcionario>();

                //Se houver registro, leia!
                if (reader.Read())
                {

                    //Criando um funcionario para representar o registro no banco.
                    Funcionario funcionario = new Funcionario(id,
                                            (string)reader["NAME"],
                                            (DateTime)reader["BIRTH_DATE"],
                                            (string)reader["CPF"],
                                            (string)reader["EMAIL"],
                                            (string)reader["TELEPHONE"],
                                            (string)reader["PASSWORD"],
                                            (bool)reader["ISACTIVE"]);
                    //Adicionando o funcionario na lista criada. (funcionarios)
                    funcionarios.Add(funcionario);
                }

                DataResponse<Funcionario> Dataresponse = new DataResponse<Funcionario>();
                Dataresponse.Sucesso = true;
                Dataresponse.Data = funcionarios;
                return Dataresponse;
            }
            catch (Exception ex)
            {
                //Logar o erro pro ADM ter acesso.
                File.WriteAllText("log.txt", ex.Message);

                DataResponse<Funcionario> dataResponse = new DataResponse<Funcionario>();
                dataResponse.Sucesso = false;
                dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                return dataResponse;
            }
            finally
            {
                connection.Dispose();
            }
        }

        public DataResponse<Funcionario> Autenticar(string email, string senha)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = SqlData.ConnectionString;
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            command.CommandText = "SELECT * FROM FUNCTIONARIES WHERE EMAIL = @EMAIL AND PASSWORD = @SENHA";
            command.Parameters.AddWithValue("@EMAIL", email);
            command.Parameters.AddWithValue("@SENHA", senha);

            try
            {
                connection.Open();
                SqlDataReader sqlReader = command.ExecuteReader();
                DataResponse<Funcionario> response = new DataResponse<Funcionario>();

                if (sqlReader.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.ID = (int)sqlReader["ID"];
                    funcionario.Name = (string)sqlReader["NAME"];
                    funcionario.CPF = (string)sqlReader["CPF"];
                    funcionario.Email = email;
                    funcionario.BirthDate = (DateTime)sqlReader["BIRTH_DATE"];
                    funcionario.Telephone = (string)sqlReader["TELEPHONE"];

                    List<Funcionario> funcionarios = new List<Funcionario>();
                    funcionarios.Add(funcionario);

                    response.Data = funcionarios;
                    response.Sucesso = true;
                    return response;
                }

                response.Erros.Add("Email e/ou senha inválidos.");
                response.Sucesso = false;
                return response;
            }
            catch (Exception)
            {
                DataResponse<Funcionario> response = new DataResponse<Funcionario>();
                response.Sucesso = false;
                response.Erros.Add("Erro no banco de dados contate o administrador.");
                return response;
            }
            finally
            {
                connection.Dispose();
            }
        }
    }
}