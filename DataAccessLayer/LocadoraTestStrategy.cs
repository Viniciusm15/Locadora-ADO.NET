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
        //protected override void Seed(LocadoraDbContext context)
        //{
        //    //Código pra criar dados de testes quando a base for recriada
        //    using (context)
        //    {
        //        Cliente c = new Cliente()
        //        {
        //            Name = "Necão Bernart",
        //            IsActive = true,
        //            CPF = "901.917.069-41",
        //            Birth_Day = DateTime.Now.AddYears(-55)
        //        };

        //        context.Clientes.Add(c);
        //        context.SaveChanges();
        //    }

        //    base.Seed(context);
        //}
    }
}
