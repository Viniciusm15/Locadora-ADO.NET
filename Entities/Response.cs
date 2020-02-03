﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Representa a resposta de uma operação de banco de dados. (envolve Insert, Update, Delete)
    /// </summary> 
    public class Response
    {
        public bool Sucesso { get; set; }
        public List<string> Erros { get; set; }

        public string GetErrorMessage()
        {
            StringBuilder builder = new StringBuilder();
            //Lambda Expression
            Erros.ForEach(erro => builder.AppendLine(erro));
            return builder.ToString();
        }

        public bool HasErrors()
        {
            return this.Erros.Count > 0;
        }

        public Response()
        {
            this.Erros = new List<string>();
        }
    }
}
