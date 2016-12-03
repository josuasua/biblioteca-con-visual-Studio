using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.API
{
    public class UsuarioController : ApiController {
        private UsuarioService uS;

        public UsuarioController() {
            uS = new UsuarioServiceImp();
        }
        // GET api/<controller>
        public HttpResponseMessage GetAll() {
            IEnumerable<Usuario> usuarios = uS.getAll();
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            if (usuarios != null) {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, usuarios);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        // GET api/<controller>/5
        public HttpResponseMessage GetById(int id) {

            Usuario usuario = uS.getById(id);
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            if (usuario != null) {
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK, usuario);
            } else {
                response = Request.CreateResponse(System.Net.HttpStatusCode.NotFound);
            }
            return response;
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Usuario usuario) {
            uS.create(usuario);
            return Request.CreateResponse(System.Net.HttpStatusCode.Created);
        }

        // PUT api/<controller>/5
        public HttpResponseMessage Put(Usuario usuario) {
            uS.update(usuario);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, usuario);
        }

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id) {
            var response = Request.CreateResponse(System.Net.HttpStatusCode.Forbidden);
            Usuario usuario = uS.getById(id);
            if (usuario != null) {
                uS.delete(id);
                response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            }

            return response;
        }
    }
}