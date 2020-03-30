using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiFinanc.Models
{
    public class FormularioRepo
    {
        private List<Formulario> _formulario = new List<Formulario>();

        public FormularioRepo() { }

        public void InicializaDados(int id)
        {
            _formulario = DalHelper.GetFormularios(id);
        }

        public int Sequencial
        {
            get { return DalHelper.GetSeqForm(); }
        }

        public string Resultado(int id)
        {
            return DalHelper.calculaPerfil(DalHelper.GetResultado(id));
        }

        public IEnumerable<Formulario> All
        {
            get { return _formulario; }
        }

        public void InsereFormulario(Formulario formulario)
        {
            DalHelper.InsertFormulario(formulario);
        }
    }
}