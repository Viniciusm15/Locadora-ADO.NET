using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    //CQRS
    public class GeneroEF
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        public GeneroEF()
        {

        }

        public GeneroEF(int id, string nome)
        {
            this.ID = id;
            this.Nome = nome;
        }
    }   
}
