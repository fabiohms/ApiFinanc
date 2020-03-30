using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFinanc.Models
{
    public class Pergunta
    {
        public int id_pergunta { get; set; }
        public string des_pergunta { get; set; }

        public Pergunta(int id, string descricao)
        {
            this.id_pergunta = id;
            this.des_pergunta = descricao;
        }
    }
}