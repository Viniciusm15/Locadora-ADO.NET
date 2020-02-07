using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    class LocadoraTestStrategy : DropCreateDatabaseAlways<LocadoraDbContext>
    {
        protected override void Seed(LocadoraDbContext context)
        {
            //Código pra criar dados de testes quando a base for recriada
            using (context)
            {
                FilmeEF filme = new FilmeEF()
                {
                    Nome = "Necão Bernart",
                    DataLancamento = DateTime.Now,
                    Classificacao = Entities.Enums.Classificacao.Dez,
                    Duracao = 120
                };

                context.Filmes.Add(filme);
                context.SaveChanges();
            }

        //    base.Seed(context);
        //}
    }
}
