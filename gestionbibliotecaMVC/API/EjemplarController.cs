using gestionbibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionBibliotecaMVC.API {
    public class EjemplarController : ApiController {
        private EjemplarService eS;

        public EjemplarController(){
            eS = new EjemplarServiceImp();
            }
        // GET api/<controller>
        public HttpResponseMessage Get() {
            IList<Ejemplar> ejemplares = eS.getAll();
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            if (ejemplares != null) {
                response = Request.CreateResponse<IList<Ejemplar>>(System.Net.HttpStatusCode.OK, ejemplares);
            } else {
                response = Request.CreateResponse (System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id) {
            Ejemplar ejemplar = eS.getEjemplarById(id);
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            if (ejemplar != null) {
                response = Request.CreateResponse<Ejemplar>(System.Net.HttpStatusCode.OK, ejemplar);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        // POST api/<controller>
        public void Post([FromBody]string value) {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        public void Delete(int id) {
        }
    }
}