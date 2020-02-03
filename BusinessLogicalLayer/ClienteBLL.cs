using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ClienteBLL : IEntityCRUD<Cliente>
    {
        ClienteDAL clientedal = new ClienteDAL();
        public Response Insert(Cliente item)
        {
            Response response = Validate(item);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            ClienteDAL clienteDAL = new ClienteDAL();
            return clienteDAL.Insert(item);
        }

        public Response Update(Cliente item)
        {
            Response response = new Response();
            if (response.Erros.Count != 0)
            {
                response.Sucesso = false;
                return response;
            }

            return clientedal.Update(item);
        }

        public Response Delete(int id)
        {
            Response response = new Response();
            if (id <= 0)
            {
                response.Sucesso = false;
                response.Erros.Add("Id do cliente inexistente.");
            }

            if (response.Erros.Count != 0)
            {
                response.Sucesso = true;
                return response;
            }

            return clientedal.Delete(id);
        }

        public DataResponse<Cliente> GetData()
        {
            return clientedal.GetData();
        }

        public DataResponse<Cliente> GetByID(int id)
        {
            return clientedal.GetByID(id);
        }

        private Response Validate(Cliente item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Name))
            {
                response.Erros.Add("Informe o seu nome.");
            }
            else
            {
                item.Name = EXT.NormatizarNome(item.Name);
                if (item.Name.Length < 2 || item.Name.Length > 50)
                {
                    response.Erros.Add("O nome deve conter entre 2 e 50 caracteres.");
                }
                else if (!EXT.CorrectName(item.Name))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            if (string.IsNullOrWhiteSpace(item.CPF))
            {
                response.Erros.Add("Informe o seu CPF.");
            }
            else
            {
                item.CPF = EXT.NormatizarCPF(item.CPF);
                if (item.CPF.Length < 2 || item.CPF.Length > 50)
                {
                    response.Erros.Add("O CPF deve conter entre 2 e 50 caracteres.");
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

            return response;
        }
    }
}
