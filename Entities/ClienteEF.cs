using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ClienteEF
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime Birth_Day { get; set; }
        public bool IsActive { get; set; }

        public ClienteEF()
        {

        }

        public ClienteEF(int id, string name, string cpf, string email, DateTime birth_day, bool isactive)
        {
            this.ID = id;
            this.Name = name;
            this.CPF = cpf;
            this.Email = email;
            this.Birth_Day = birth_day;
            this.IsActive = isactive;
        }
    }
}
