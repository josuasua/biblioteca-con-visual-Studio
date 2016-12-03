using gestionbibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.Controllers
{
    public class PrestamoController : Controller
    { 
        private PrestamosService pS;
        private EjemplarService eS;

        public PrestamoController()
        {
            pS = new PrestamosServiceImp();
            eS = new EjemplarServiceImp();
        }

        // GET: Prestamo
        [Authorize(Roles = "User,Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            ActionResult paginaRedirect = null;
            IList<Prestamos> prestamos = null;
            if (User.IsInRole("Admin")) {
                prestamos = pS.getAll();
            } else if (User.IsInRole("User")) {
                int codigo = (int) Session["idUsuario"];
                prestamos = pS.getPrestamosUsuario(codigo);
            }
            
            if(prestamos.Count() > 0)
            {
                ViewBag.Title = "Listado de prestamos";
                paginaRedirect =  View("Index",prestamos);
            }else
            {
                ViewBag.ErrorMessage = "No hay prestamos en la BB.DD";
                paginaRedirect = View("Index", prestamos);
            }
            return paginaRedirect;
        }

        [Authorize(Roles = "User")]
        //GET: Prestamo/Crear/5
        [HttpGet]
        public ActionResult Crear(int codigo) {

            Prestamos prestamo = new Prestamos();
            
            prestamo.Ejemplar.CodEjemplar = codigo;

            prestamo.Usuario.CodUsuario = (int) Session["idUsuario"];
            prestamo = pS.create(prestamo);

            return View("Index");
        }

        [Authorize(Roles = "User")]
        //GET: Prestamo/Update
        [HttpGet]
        public ActionResult Update(int codigo)
        {
            ActionResult paginaRedirect = null;
            Prestamos prestamo = null;
            prestamo = pS.getById(codigo);
            if (prestamo != null) {
                prestamo.CodPrestamo = codigo;
                prestamo.FDevolucion = DateTime.Today;
                prestamo = pS.update(prestamo);
                ViewBag.Message = "El ejemplar se ha entregado con exito";
            } else {
                ViewBag.Message = "Error al entregar el ejemplar";
            }
            IList<Prestamos> prestamos = pS.getPrestamosUsuario(prestamo.Usuario.CodUsuario);
            paginaRedirect = View("Index", prestamos);

            return paginaRedirect;


        }

        [Authorize(Roles = "User")]
        //POST: Prestamo/save
        [HttpPost]
        public ActionResult save(Prestamos prestamo)
        {
            
            if (prestamo.CodPrestamo > 0)
            {
                pS.update(prestamo);
                ViewBag.Message = "Se ha modificado el prestamo con exito";
            }else
            {
                pS.create(prestamo);
                ViewBag.Message= "Se ha creado el prestamo con exito";
            }

            return View("Index");
        }
    }
}