using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFinanc.Models
{
    public class Formulario
    {
        public int id_formulario { get; set; }
        public int id_pergunta { get; set; }
        public int id_resposta { get; set; }

        public Formulario(int id_form, int id_perg, int id_resp)
        {
            this.id_formulario = id_form;
            this.id_pergunta = id_perg;
            this.id_resposta = id_resp;
        }
    }
}