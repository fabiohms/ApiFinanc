using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFinanc.Models
{
    public class Perfil
    {
        public int minino { get; set; }
        public int maximo { get; set; }
        public string descricao { get; set; }

        public Perfil(int min, int max, string des)
        {
            this.minino = min;
            this.maximo = max;
            this.descricao = des;
        }
    }
}