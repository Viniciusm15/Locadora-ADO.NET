using BusinessLogicalLayer.Security;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FuncionarioService : IEntityCRUDEF<FuncionarioEF>, IFuncionarioServiceEF
    {
        public Response Insert(FuncionarioEF item)
        {
            Response response = Validate(item);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    db.Funcionarios.Add(item);
                    db.SaveChanges();

                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
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
            }
        }

        public Response Update(FuncionarioEF item)
        {
            Response response = Validate(item);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    db.Entry<FuncionarioEF>(item).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    response.Sucesso = true;
                    return response;
                }
                catch (Exception ex)
                {
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
            }
        }

        public Response Delete(int id)
        {
            DataResponse<FuncionarioEF> dResponse = new DataResponse<FuncionarioEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    FuncionarioEF funcionario = db.Funcionarios.Find(id);

                    List<FuncionarioEF> funcionarios = new List<FuncionarioEF>();
                    funcionarios.Add(funcionario);

                    dResponse.Data = funcionarios;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {
                    dResponse.Sucesso = false;

                    if (ex.Message.Contains("UQ_FUN_CPF"))
                    {
                        dResponse.Erros.Add("CPF já cadastrado.");
                    }
                    else if (ex.Message.Contains("UQ_FUN_EMAIL"))
                    {
                        dResponse.Erros.Add("Email já cadastrado.");
                    }
                    else
                    {
                        dResponse.Erros.Add("Erro no banco de dados, contate o ADM!");
                        File.WriteAllText("log.txt", ex.Message);
                        return dResponse;
                    }

                    return dResponse;
                }
            }
        }

        public DataResponse<FuncionarioEF> GetData()
        {
            DataResponse<FuncionarioEF> dResponse = new DataResponse<FuncionarioEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    List<FuncionarioEF> funcionarios = db.Funcionarios.Select(f => new FuncionarioEF()
                    {
                        ID = f.ID,
                        Name = f.Name,
                        BirthDate = f.BirthDate,
                        CPF = f.CPF,
                        Email = f.Email,
                        Telephone = f.Telephone,
                        Password = f.Password,
                        IsActive = f.IsActive

                    }).ToList();

                    dResponse.Data = funcionarios;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {

                    //Logar o erro pro ADM ter acesso.
                    File.WriteAllText("log.txt", ex.Message);

                    DataResponse<Funcionario> dataResponse = new DataResponse<Funcionario>();
                    dataResponse.Sucesso = false;
                    dataResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                    return dResponse;
                }
            }
        }

        public DataResponse<FuncionarioEF> GetByID(int id)
        {
            DataResponse<FuncionarioEF> dResponse = new DataResponse<FuncionarioEF>();

            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                try
                {
                    FuncionarioEF filme = db.Funcionarios.Find(id);

                    List<FuncionarioEF> funcionarios = new List<FuncionarioEF>();
                    funcionarios.Add(filme);

                    dResponse.Data = funcionarios;
                    dResponse.Sucesso = true;
                    return dResponse;
                }
                catch (Exception ex)
                {
                    //Logar o erro pro ADM ter acesso.
                    File.WriteAllText("log.txt", ex.Message);

                    dResponse.Sucesso = false;
                    dResponse.Erros.Add("Falha ao acessar o banco de dados, contate o suporte.");
                    return dResponse;
                }
            }
        }

        private Response Validate(FuncionarioEF item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                response.Erros.Add("O nome do Funcionario deve ser informado.");
            }
            else
            {
                item.Name = EXT.NormatizarNome(item.Name);
                if (item.Name.Length < 2 || item.Name.Length > 100)
                {
                    response.Erros.Add("O nome do funcionario deve conter entre 2 e 100 caracteres.");
                }
                else if (!EXT.CorrectName(item.Name))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            if (item.BirthDate.Equals(DateTime.MinValue) || item.BirthDate > DateTime.Now)
            {
                response.Erros.Add("Data inválida.");
            }

            if (string.IsNullOrWhiteSpace(item.CPF))
            {
                response.Erros.Add("Informe o seu CPF.");
            }
            else
            {
                item.CPF = EXT.NormatizarCPF(item.CPF);
                if (item.CPF.Length < 2 || item.CPF.Length > 14)
                {
                    response.Erros.Add("O CPF deve conter entre 2 e 14 caracteres.");
                }
                else if (!EXT.IsCpf(item.CPF))
                {
                    response.Erros.Add("O CPF deve estar no formato correto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.Email))
            {
                response.Erros.Add("Informe o seu email.");
            }
            else
            {
                item.Email = EXT.NormatizarEmail(item.Email);
                if (item.Email.Length < 2 || item.Email.Length > 50)
                {
                    response.Erros.Add("O email deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.IsEmail(item.Email))
                {
                    response.Erros.Add("O email deve estar no formato correto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.Telephone))
            {
                response.Erros.Add("Informe o seu telefone.");
            }
            else
            {
                item.Email = item.Email.Trim();
                if (item.Telephone.Length < 14 || item.Telephone.Length > 15)
                {
                    response.Erros.Add("O telefone deve conter entre 14 a 15 caracteres.");
                }
                else if (!EXT.IsTelephone(item.Telephone))
                {
                    response.Erros.Add("O telefone deve estar no formato correto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.Password))
            {
                response.Erros.Add("Informe sua senha.");
            }
            else
            {
                item.Password = item.Password.Trim();
                if (item.Password.Length < 8 || item.Password.Length > 15)
                {
                    response.Erros.Add("A senha deve conter entre 8 e 15 caracteres.");
                }
                else if (!EXT.CorrectPassWord(item.Password))
                {
                    response.Erros.Add("A senha deve estar no formato correto. (Pelo menos uma UpperCase e um caracter especial)");
                }
            }

            return response;
        }

        public DataResponse<FuncionarioEF> Autenticar(string email, string senha)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(email))
            {
                response.Erros.Add("Informe o seu email.");
            }
            else
            {
                email = EXT.NormatizarEmail(email);
                if (email.Length < 2 || email.Length > 50)
                {
                    response.Erros.Add("O email deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.IsEmail(email))
                {
                    response.Erros.Add("O email deve estar no formato correto.");
                }
            }

            if (string.IsNullOrWhiteSpace(senha))
            {
                response.Erros.Add("Informe sua senha.");
            }
            else
            {
                senha = senha.Trim();
                if (senha.Length < 8 || senha.Length > 15)
                {
                    response.Erros.Add("A senha deve conter entre 8 e 15 caracteres.");
                }
                else if (!EXT.CorrectPassWord(senha))
                {
                    response.Erros.Add("A senha deve estar no formato correto. (Pelo menos uma UpperCase e um caracter especial)");
                }
            }

            using (LocadoraDbContext db = new LocadoraDbContext())
            {

                List<FuncionarioEF> result = db.Funcionarios.Where(f => f.Email.Contains(email)).Where(f => f.Password.Contains(senha)).Select(f => new FuncionarioEF()
                {
                    Email = f.Email,
                    Password = f.Password

                }).ToList();

                senha = HashUtils.HashPassword(senha);

                DataResponse<FuncionarioEF> dataResponse = new DataResponse<FuncionarioEF>();
                dataResponse.Data = result;
                response.Sucesso = true;

                if (dataResponse.Sucesso)
                {
                    UserEF.FuncionarioLogado = dataResponse.Data[0];
                }

                return dataResponse;
            }
        }
    }
}
