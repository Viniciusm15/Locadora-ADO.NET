using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class LocacaoService : ILocacaoServiceEF
    {
        public Response EfeturarLocacao(LocacaoEF locacao)
        {
            Response response = new Response();


            if (locacao.Filmes.Count.Equals(0))
            {
                response.Erros.Add("Não é possível realizar a locação sem filmes.");
                response.Sucesso = false;
                return response;
            }

            TimeSpan ts = DateTime.Now.Subtract(locacao.Cliente.Birth_Day);
            //Calcula a idade do cliente.
            int idade = (int)(ts.TotalDays / 365);

            //Percorre todos os filmes locados a fim de encontrar algum que o cliente não possa ver.
            foreach (FilmeEF filme in locacao.Filmes)
            {
                if ((int)filme.Classificacao > idade)
                {
                    response.Erros.Add("A idade do cliente não corresponde com a classificação indicativa do filme" + filme.Nome);
                }
            }

            //"Seta" a data de devolucação com a data atual do sistema.
            locacao.DataLocacao = DateTime.Now;
            locacao.DataDevolucaoPrevista = DateTime.Now;

            foreach (FilmeEF filme in locacao.Filmes)
            {
                //Adiciona tempo na devolução de acordo com a data de lançamento.
                locacao.DataDevolucaoPrevista = locacao.DataDevolucaoPrevista.AddHours(filme.CalcularDevolucao());

                //Adiciona os preços dos filmes.
                locacao.Preco += filme.CalcularPreco();
            }

            if (response.Erros.Count > 0)
            {
                response.Sucesso = false;
                return response;
            }

            //Necessário (dependendo da equipe que você estiver alocado)
            //Vai ao banco de dados com afinalidade de descobrir se o ID do cliente associado a locação existe no banco de dados.
            ClienteService cs = new ClienteService();
            DataResponse<ClienteEF> cliente = cs.GetByID(locacao.Cliente.ID);
            if (cliente.Equals(null))
            {
                response.Erros.Add("Cliente inexistente.");
            }

            //Vai ao banco de dados com afinalidade de descobrir se o ID do Funcionario associado a locação existe no banco de dados.
            FuncionarioService fs = new FuncionarioService();
            DataResponse<FuncionarioEF> funcionario = fs.GetByID(locacao.Funcionario.ID);
            if (funcionario.Equals(null))
            {
                response.Erros.Add("Funcionario inexistente.");
            }
            using (LocadoraDbContext db = new LocadoraDbContext())
            {
                db.Locacoes.Add(locacao);
                db.SaveChanges();
            }

            return response;
        }
    }
}
