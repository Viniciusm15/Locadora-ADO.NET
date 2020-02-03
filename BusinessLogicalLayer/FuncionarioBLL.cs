using BusinessLogicalLayer.Security;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FuncionarioBLL : IEntityCRUD<Funcionario>, IFuncionarioService
    {
        private FuncionarioDAL funcionarioDAL = new FuncionarioDAL();
        public Response Insert(Funcionario item)
        {
            //Exemplo de regra para senha, em aula.
            //int qtdMaiscula = 0;
            //int qtdMinuscula = 0;
            //int qtdNumeros = 0;
            //int qtdSimbolos = 0;
            //item.Password = item.Password.Replace(" ","");

            //foreach (char caractere in item.Password)
            //{
            //if (char.IsLetter(caractere))
            //{
            //if (char.IsUpper(caractere))
            //{
            //qtdMaiscula++;
            //}
            //else
            //{
            //qtdMinuscula++;
            //}
            //}
            //else if (char.IsNumber(caractere))
            //{
            //qtdNumeros++;
            //}
            //else
            //{
            //qtdSimbolos++;
            //}
            //}

            //int QtdLetras = qtdMaiscula + qtdMinuscula;
            //if (QtdLetras <3 || qtdMinuscula <1 || qtdMaiscula < 1 || qtdNumeros <3 || qtdSimbolos < 1)
            //{
            //return "A senha deve conter ao menos 3 letras (1 maiúscila e 1 minúscula), 3 números e 1 símbolo.";
            //}

            Response response = Validate(item);

            if (response.HasErrors())
            {
                response.Sucesso = false;
                return response;
            }

            item.IsActive = true;
            item.Password = HashUtils.HashPassword(item.Password);

            return funcionarioDAL.Insert(item);
        }

        public Response Update(Funcionario item)
        {
            Response response = new Response();
            if (response.Erros.Count != 0)
            {
                response.Sucesso = false;
                return response;
            }

            return funcionarioDAL.Update(item);
        }

        public Response Delete(int id)
        {
            Response response = new Response();
            if (id <= 0)
            {
                response.Sucesso = false;
                response.Erros.Add("Id do funcionário inexistente.");
            }

            if (response.Erros.Count != 0)
            {
                response.Sucesso = true;
                return response;
            }

            return funcionarioDAL.Delete(id);
        }

        public DataResponse<Funcionario> GetData()
        {
            return funcionarioDAL.GetData();
        }

        public DataResponse<Funcionario> GetByID(int id)
        {
            return funcionarioDAL.GetByID(id);
        }

        private Response Validate(Funcionario item)
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

        public DataResponse<Funcionario> Autenticar(string email, string senha)
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

            senha = HashUtils.HashPassword(senha);

            DataResponse<Funcionario> dataResponse = funcionarioDAL.Autenticar(email, senha);
            if (dataResponse.Sucesso)
            {
                User.FuncionarioLogado = dataResponse.Data[0];
            }
            return dataResponse;
        }
    }
}