using ApiFinanc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiFinanc.Controllers
{
    public class RespostasController : ApiController
    {
        private readonly RespostaRepo _respostaRepo;

        public RespostasController()
        {
            _respostaRepo = new RespostaRepo();
        }

        // GET: api/Resposta/id
        [HttpGet]
        public IEnumerable<Resposta> List(int id)
        {
            _respostaRepo.InicializaDados(id);
            return _respostaRepo.All;
        }
    }
}
