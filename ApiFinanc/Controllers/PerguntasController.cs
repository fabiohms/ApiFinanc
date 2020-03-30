using ApiFinanc.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace ApiFinanc.Controllers
{
    public class PerguntasController : ApiController
    {
        private readonly PerguntaRepo _perguntaRepo;

        public PerguntasController()
        {
            _perguntaRepo = new PerguntaRepo();
        }

        // GET: api/Pergunta
        [HttpGet]
        public IEnumerable<Pergunta> List()
        {
            return _perguntaRepo.All;
        }
    }
}
