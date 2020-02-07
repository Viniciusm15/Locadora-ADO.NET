using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FilmeEF
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime DataLancamento { get; set; }
        public Classificacao Classificacao { get; set; }
        public int Duracao { get; set; }
        public int? GeneroID { get; set; }
        public virtual Genero Genero { get; set; }
        public List<Locacao> locacaos { get; set; }

        public FilmeEF()
        {

        }

        public FilmeEF(int iD, string nome, DateTime dataLancamento, Classificacao classificacao, int duracao, int generoid, Genero genero)
        {
            ID = iD;
            Nome = nome;
            DataLancamento = dataLancamento;
            Classificacao = classificacao;
            Duracao = duracao;
            GeneroID = generoid;
            Genero = genero;
        }

        public double CalcularPreco()
        {
            if (this.DataLancamento.Year.Equals(DateTime.Now.Year))
            {
                return 10;
            }

            int anosLancamento = DateTime.Now.Year - this.DataLancamento.Year;
            if (anosLancamento < 3)
            {
                return 8;
            }

            if (anosLancamento < 5)
            {
                return 6;
            }
            return 4;
        }

        /// <summary>
        /// Calcula a devolução do filme.
        /// </summary>
        /// <returns> Retorna em HORAS o tempo de devolução </returns>
        public int CalcularDevolucao()
        {
            if (this.DataLancamento.Year.Equals(DateTime.Now.Year))
            {
                return 12;
            }

            int anosLancamento = DateTime.Now.Year - this.DataLancamento.Year;
            if (anosLancamento < 2)
            {
                return 24;
            }

            if (anosLancamento < 4)
            {
                return 36;
            }
            return 48;
        }
    }
}
