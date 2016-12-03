using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.Controllers
{
    public class FotoController : Controller
    {
        private FotoService fS;
        private UsuarioService uS;

        public FotoController(){
            fS = new FotoServiceImp();
            uS = new UsuarioServiceImp();
            }

        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult Index() {
            ActionResult paginaRedirect = null;
            Usuario usuario = new Usuario();
            Foto foto = new Foto();
            int codigo = (int)Session["idUsuario"];
            usuario = uS.getById(codigo);
            if (usuario.IdFoto == 0) {
                //crear foto
                paginaRedirect = View("Foto", foto);
            } else {
                foto = fS.getByID(usuario.IdFoto);
                paginaRedirect = View ("Foto", foto);
            }
            


            
            return paginaRedirect;

        }

        //POST: Foto/save
        [HttpPost]
        public ActionResult save(HttpPostedFileBase file) {
            ActionResult paginaRedirect = null;
            Foto fotografia = new Foto();
            Usuario usuario = new Usuario();
            int codigo = (int)Session["idUsuario"];
            usuario = uS.getById(codigo);
            fotografia =fS.create(fotografia);
            if (ModelState.IsValid) {
                string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
                file.SaveAs(Server.MapPath("~/imagenes/" + archivo));
                fotografia.imagen = archivo;
                fotografia=fS.update(fotografia);
                usuario.IdFoto = fotografia.idFoto;
                usuario = uS.update(usuario);
                paginaRedirect = RedirectToAction("Index", "Home");
            } else {
                paginaRedirect = RedirectToAction("Foto", fotografia);
            }      
            return paginaRedirect;
        }

    }
}