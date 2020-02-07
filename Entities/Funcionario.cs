using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public Funcionario()
        {

        }

        public Funcionario(int iD, string nome, DateTime birthDate, string cPF, string email, string telephone, string password, bool isActive)
        {
            ID = iD;
            Name = nome;
            BirthDate = birthDate;
            CPF = cPF;
            Email = email;
            Telephone = telephone;
            Password = password;
            IsActive = isActive;
        }
    }
}
