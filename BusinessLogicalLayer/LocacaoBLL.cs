using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogicalLayer
{
    public class LocacaoBLL : ILocacaoService
    {
        private LocacaoDAL dal = new LocacaoDAL();
        private ClienteBLL clienteBLL = new ClienteBLL();
        private FuncionarioBLL funcionarioBLL = new FuncionarioBLL();
        public Response EfeturarLocacao(Locacao locacao)
        {
            Response response = new Response();

            if (locacao.filmes.Count.Equals(0))
            {
                response.Erros.Add("Não é possível realizar a locação sem filmes.");
                response.Sucesso = false;
                return response;
            }

            TimeSpan ts = DateTime.Now.Subtract(locacao.Cliente.Birth_Day);
            //Calcula a idade do cliente.
            int idade = (int)(ts.TotalDays / 365);

            //Percorre todos os filmes locados a fim de encontrar algum que o cliente não possa ver.
            foreach (Filme filme in locacao.filmes)
            {
                if ((int)filme.Classificacao > idade)
                {
                    response.Erros.Add("A idade do cliente não corresponde com a classificação indicativa do filme" + filme.Nome);
                }
            }

            //"Seta" a data de devolucação com a data atual do sistema.
            locacao.DataLocacao = DateTime.Now;
            locacao.DataDevolucaoPrevista = DateTime.Now;

            foreach (Filme filme in locacao.filmes)
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
            DataResponse<Cliente> cliente = clienteBLL.GetByID(locacao.Cliente.ID);
            if (cliente.Equals(null))
            {
                response.Erros.Add("Cliente inexistente.");
            }

            //Vai ao banco de dados com afinalidade de descobrir se o ID do Funcionario associado a locação existe no banco de dados.
            DataResponse<Funcionario> funcionario = funcionarioBLL.GetByID(locacao.Cliente.ID);
            if (funcionario.Equals(null))
            {
                response.Erros.Add("Funcionario inexistente.");
            }

            //Utilizaremos o objeto TransactionScope para garantir que, tudo que esta entre o escopo rodará em uma transação onde
            //TUDO FUNCIONA, OU NADA FUNCIONA.
            using (TransactionScope scope = new TransactionScope())
            {
                //Invocar o método EfetuarLocacao no DAL para inserir uma locação no banco.
                response = dal.EfeturarLocacao(locacao);

                if (response.Sucesso)
                {
                    //Invocar o método para inserir o filme na tablea Locacao_Filmes. (Inserções N para N)
                    response = dal.EfetuarFilmesLocacao(locacao);
                    if (response.Sucesso)
                    {
                        //Se der certo, "comita" a operação.
                        //Chamar o Complete signfica que deu tudo certo.
                        scope.Complete();
                    }
                }
            }//Ao chegar no final das chaves, caso o complete não seja chamado, o C# reverterá todas as operações em banco de dados
             //efetuada dentro deste using.

            return response;
        }
    }
}