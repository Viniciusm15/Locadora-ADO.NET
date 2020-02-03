using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    /// <summary>
    /// Classe responsável pelas regras de negócio da entidade Gênero.
    /// </summary>
    public class GeneroBLL : IEntityCRUD<Genero>
    {
        public GeneroDAL dal = new GeneroDAL();
        public Response Insert(Genero item)
        {
            Response response = Validate(item);
            //TODO: Implementar posteriormente regra de prevenção de gêneros repetidos no banco de dados.

            //Se for encontrado erro de validação, retorne-os!
            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            //Se chegou aqui, bora pro DAL!
            //Retorna a resposta do DAL! Se tiver dúvidas do que é esta resposta, analise o método DAL!
            return dal.Insert(item);
        }

        public Response Update(Genero item)
        {
            Response response = new Response();
            if (response.Erros.Count != 0)
            {
                response.Sucesso = false;
                return response;
            }

            return dal.Update(item);
        }

        public Response Delete(int id)
        {
            Response response = new Response();
            if (id <= 0)
            {
                response.Sucesso = false;
                response.Erros.Add("Id do gênero inexistente.");
            }

            if (response.Erros.Count != 0)
            {
                response.Sucesso = true;
                return response;
            }

            return dal.Delete(id);
        }

        public DataResponse<Genero> GetData()
        {
            return dal.GetData();
        }

        public DataResponse<Genero> GetByID(int id)
        {
            return dal.GetByID(id);
        }

        private Response Validate(Genero item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("O nome do gênero deve ser informado.");
            }
            else
            {
                //Remove espaços em branco no começo e no final da string.
                item.Nome = item.Nome.Trim();

                //Remove espaços extras entre as palavras.
                //EX: " A        B" =  "A B".
                item.Nome = Regex.Replace(item.Nome, @"\s+", " ");

                if (item.Nome.Length < 2 || item.Nome.Length > 40)
                {
                    response.Erros.Add("O nome do gênero deve conter entre 2 e 50 caracteres.");
                }
            }

            return response;
        }
    }
}
