using System.Collections.Generic;

namespace ApiFinanc.Models
{
    public class PerguntaRepo
    {
        private List<Pergunta> _perguntas = new List<Pergunta>();

        public PerguntaRepo()
        {
            this.InicializaDados();
        }

        private void InicializaDados()
        {
            _perguntas = DalHelper.GetPerguntas();
        }

        public IEnumerable<Pergunta> All
        {
            get { return _perguntas; }
        }
    }
}