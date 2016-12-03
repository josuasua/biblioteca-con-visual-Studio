using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestionBibliotecaMVC.API
{
    public class EditorialController : ApiController
    {
        private EditorialService eS;

        public EditorialController() {
            eS = new EditorialServiceImp();
        }

        // GET api/<controller>
        [HttpGet]
        public HttpResponseMessage GetAll() {
            IList<Editorial> editoriales = eS.getAll();
            var response = Request.CreateResponse<IList<Editorial>>(System.Net.HttpStatusCode.OK, editoriales);
            return response;
        }

        // GET api/<controller>/5
        [HttpGet]
        public HttpResponseMessage GetById(int id) {

            Editorial editorial = eS.getById(id);
            HttpResponseMessage response;
            if (editorial != null) {
                response = Request.CreateResponse<Editorial>(System.Net.HttpStatusCode.OK, editorial);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }
        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post(Editorial editorial) {
            eS.create(editorial);
            return Request.CreateResponse(System.Net.HttpStatusCode.Created);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public HttpResponseMessage Put(Editorial editorial) {
            eS.update(editorial);
            return Request.CreateResponse<Editorial>(System.Net.HttpStatusCode.OK, editorial);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage Delete(int id) {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

    }
}
