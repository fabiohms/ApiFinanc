using ApiFinanc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiFinanc.Controllers
{
    public class FormulariosController : ApiController
    {
        private readonly FormularioRepo _formularioRepo;

        public FormulariosController()
        {
            _formularioRepo = new FormularioRepo();
        }

        // GET: api/Formularios/id
        /*[HttpGet]
        public IEnumerable<Formulario> List(int id)
        {
            _formularioRepo.InicializaDados(id);
            return _formularioRepo.All;
        }*/

        // GET: api/Formularios
        [HttpGet]
        public int GeraSeq()
        {
            return _formularioRepo.Sequencial;
        }

        [HttpGet]
        public string Resultado(int id)
        {
            return _formularioRepo.Resultado(id);
        }

        // POST: api/Formularios
        [HttpPost()]
        public void Insert([FromBody]Formulario formulario)
        {
            _formularioRepo.InsereFormulario(formulario);
        }
    }
}
