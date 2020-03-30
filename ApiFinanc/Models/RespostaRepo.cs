using System.Collections.Generic;

namespace ApiFinanc.Models
{
    public class RespostaRepo
    {
        private List<Resposta> _resposta = new List<Resposta>();

        public RespostaRepo()
        {

        }

        public void InicializaDados(int id)
        {
            _resposta = DalHelper.GetRespostas(id);
        }

        public IEnumerable<Resposta> All
        {
            get { return _resposta; }
        }

    }
}