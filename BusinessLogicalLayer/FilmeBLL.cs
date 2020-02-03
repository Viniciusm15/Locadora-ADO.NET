using DataAccessLayer;
using Entities;
using Entities.Enums;
using Entities.ResultSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class FilmeBLL : IEntityCRUD<Filme>, IFilmeService
    {
        private FilmeDAL filmeDAL = new FilmeDAL();
        public Response Insert(Filme item)
        {
            Response response = Validate(item);

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            return filmeDAL.Insert(item);
        }

        public Response Update(Filme item)
        {
            Response response = new Response();
            if (response.Erros.Count != 0)
            {
                response.Sucesso = false;
                return response;
            }

            return filmeDAL.Update(item);
        }

        public Response Delete(int id)
        {
            Response response = new Response();
            if (id <= 0)
            {
                response.Sucesso = false;
                response.Erros.Add("Id do filme inexistente.");
            }

            if (response.Erros.Count != 0)
            {
                response.Sucesso = true;
                return response;
            }

            return filmeDAL.Delete(id);
        }

        public DataResponse<Filme> GetData()
        {
            return filmeDAL.GetData();
        }

        public DataResponse<Filme> GetByID(int id)
        {
            return filmeDAL.GetByID(id);
        }

        private Response Validate(Filme item)
        {
            Response response = new Response();

            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                response.Erros.Add("O nome do filme deve ser informado.");
            }
            else
            {
                item.Nome = EXT.NormatizarNome(item.Nome);
                if (item.Nome.Length < 2 || item.Nome.Length > 100)
                {
                    response.Erros.Add("O nome do filme deve conter entre 2 e 100 caracteres.");
                }
                else if (!EXT.CorrectName(item.Nome))
                {
                    response.Erros.Add("O nome está no formato incorreto.");
                }
            }

            if (item.Duracao <= 10)
            {
                response.Erros.Add("A duração não pode ser menor que 10 minutos.");
            }

            if (item.DataLancamento.Equals(DateTime.MinValue) || item.DataLancamento > DateTime.Now)
            {
                response.Erros.Add("Data inválida.");
            }

            return response;
        }

        public DataResponse<FilmeResultSet> GetFilmes()
        {
            return filmeDAL.GetFilmes();
        }

        public DataResponse<FilmeResultSet> GetFilmesByName(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                DataResponse<FilmeResultSet> response = new DataResponse<FilmeResultSet>();
                response.Sucesso = false;
                response.Erros.Add("Nome deve ser informado.");
                return response;
            }
            nome = nome.Trim();
            return filmeDAL.GetFilmesByName(nome);
        }

        public DataResponse<FilmeResultSet> GetFilmesByGener(int genero)
        {
            if (genero <= 0)
            {
                DataResponse<FilmeResultSet> response = new DataResponse<FilmeResultSet>();
                response.Sucesso = false;
                response.Erros.Add("Gênero deve ser informado.");
                return response;
            }
            return filmeDAL.GetFilmesByGener(genero);
        }

        public DataResponse<FilmeResultSet> GetFilmesByClassification(Classificacao classificacao)
        {
            return filmeDAL.GetFilmesByClassification(classificacao);
        }
    }
}