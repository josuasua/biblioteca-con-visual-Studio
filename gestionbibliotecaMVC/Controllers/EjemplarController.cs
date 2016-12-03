using gestionbibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.Controllers
{
    public class EjemplarController : Controller
    {
        private EjemplarService ejS;
        private LibroServiceImp lS;
        private EditorialService edS;

        public EjemplarController()
        {
            ejS = new EjemplarServiceImp();
            lS = new LibroServiceImp();
            edS = new EditorialServiceImp();
        }
        // GET: Ejemplar
        [HttpGet]
        public ActionResult Index(int codLibro = -1)
        {
            ActionResult paginaRedirect = null;
            IList<Ejemplar> ejemplares = null;
            ViewBag.codLibro = codLibro;
            if (codLibro > 0) {
                ejemplares = ejS.getByIdDeLibro(codLibro);
                if (ejemplares.Count() <= 0) {
                    ViewBag.ErrorMessage = "No se han encontrado ejemplares del libro seleccionado";
                    
                } 
            } else {
                ejemplares = ejS.getAll();

                if (ejemplares.Count() <= 0) {
                    ViewBag.ErrorMessage = "No se han encontrado ejemplares";
                }
            }
            paginaRedirect = View("Index", ejemplares);

            return paginaRedirect;
        }

        //POST: Ejemplar/save
        [HttpPost]
        public ActionResult save(Ejemplar ejemplar)
        {
            ActionResult resultado = null;
            //Este validador, toma el objeto que devuelve directamente la vista. Da igual las modificaciones que hagas en este metodo
            //Por lo tanto, la siguiente instruccion no vale de nada, para la validacion de editorial hay que buscarse la vida de otra manera.
            //ejemplar.Editorial = edS.getById(ejemplar.Editorial.CodEditorial);
            if (ModelState.IsValid)
            {
                if(ejemplar.CodEjemplar > 0)
                {
                    ejS.update(ejemplar);
                    ViewBag.Message = "El ejemplar se ha actualizado";
                    resultado = RedirectToAction("Index");
                }
                else
                {
                    ejS.create(ejemplar);
                    ViewBag.Message = "El ejemplar se ha creado con éxito";
                    resultado = RedirectToAction("Index");

                }
            }
            else
            {
                ViewBag.EditorialList = edS.getAll();
                resultado = View("Ejemplar",ejemplar);
            }
           //
            return resultado;
        }

        //GET : Ejemplar/createUpdate
        public ActionResult createUpdate(int codLibro = -1,int cod = -1)
        {
            ActionResult resultado = null;
            Ejemplar ejemplar = null;
            if (cod > 0) {
                ejemplar = ejS.getEjemplarById(cod);
            }
            ViewBag.EditorialList = edS.getAll();
            if (ejemplar != null)
            {
                
                ViewBag.Message = "Editar Ejemplar";
                /*
                libro = lS.getById(codLibro);
                ejemplar.CodLibro = libro.CodLibro;
                ejemplar.Titulo = libro.Titulo;
                ejemplar.Autor = libro.Autor;
                */
                resultado = View("Ejemplar", ejemplar);
            }
            else
            {
                ViewBag.Message = "Nuevo Ejemplar";
                ejemplar = new Ejemplar();
                ejemplar.CodLibro = codLibro;
                ejemplar.Titulo = lS.getById(codLibro).Titulo;
                /*
                ejemplar.CodLibro = libro.CodLibro;
                ejemplar.Titulo = libro.Titulo;
                ejemplar.Autor = libro.Autor;
                libro = lS.getById(codLibro);
                */
                resultado = View("Ejemplar", ejemplar);
            }
            return resultado;
        }

        //GET: Ejemplar/Delete/5
        public ActionResult delete(int cod)
        {
            if(ejS.getEjemplarById(cod) != null)
            {
                ejS.delete(cod);
                ViewBag.Message = "El ejemplar se ha borrado correctamente";
            }
            /*
             * Si pones View("") --> Lo mandas a la vista
             * Si pones RedirectToAction --> lo mandas al metodo del controlador
             */
            return RedirectToAction("Index");
        }
        
    }
}