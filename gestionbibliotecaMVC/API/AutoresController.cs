using gestionbibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionBibliotecaMVC {
    public class AutoresController : ApiController {

        private AutorService aS;

        public AutoresController() {
            aS = new AutorServiceImp();
        }

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage GetAll() {
            IEnumerable<Autor> autores = aS.getAll();
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            if (autores != null) {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, autores);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        /**
         * se utiliza httpResponseMessage --> para poder encapsular mensaje Http y objetos
         */

        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage GetById(int id) {

            Autor autor = aS.getByID(id);
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            if (autor != null) {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, autor);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post(Autor autor) {
            aS.create(autor);
            return Request.CreateResponse(System.Net.HttpStatusCode.Created);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage Put(Autor autor) {
            aS.update(autor);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, autor);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id) {
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            Autor autor = aS.getByID(id);
            if (autor != null) {
                aS.delete(id);
            }
        }
    }
}