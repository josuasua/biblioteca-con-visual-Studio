using gestionbibliotecaMVC.Models;
using GestionBibliotecaMVC.BBLL;
using GestionBibliotecaMVC.BBLL.interfaces;
using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionBibliotecaMVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private UsuarioService uS;
        private FotoService fS;
        public LoginController() {
            uS = new UsuarioServiceImp();
            fS = new FotoServiceImp();
        }
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Message = "Menu de login";
            return View("Index");
        }

        //POST: Login
    //    [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(Login model) {
            Usuario user = null;
            int codigo = 0;
            ActionResult retorno= null;
            FormsAuthenticationTicket authTicket;
            if (ModelState.IsValid) {
                //
                if (model.Alias.Equals("admin") && model.Pass.Equals("admin")) {
                    user = new Usuario();
                    authTicket = new FormsAuthenticationTicket(
                            1,                              //version
                            model.Alias,                      // user name
                            DateTime.Now,                  // created
                            DateTime.Now.AddMinutes(20),   // expires
                            model.Recordar,                    // persistent?
                            "Admin"                        // can be used to store roles
                    );
                    user.Alias = model.Alias;
                    user.CodUsuario = 0;
                    user.IdFoto = 0;
                    user.Pass = model.Pass;
                    retorno = RedirectToAction("Index", "Home");

                } else {

                    codigo = uS.Login(model).CodUsuario;
                    user = uS.getById(codigo);
                    authTicket = new FormsAuthenticationTicket(
                            1,                              //version                   
                            model.Alias,                      // user name
                            DateTime.Now,                  // created
                            DateTime.Now.AddMinutes(20),   // expires
                            model.Recordar,                    // persistent?
                            "User"                        // can be used to store roles
                            );
                }
                    if (codigo > 0 || user!=null) {
                        
                        Session["idUsuario"] = user.CodUsuario;
                        string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                        var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                        Response.Cookies.Add(authCookie);

                        Session["usuario"] = user;
                        Foto foto = fS.getByID(user.IdFoto);
                        
                        //  FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        retorno = RedirectToAction("Index", "Home", foto);
                    } else {
                        ModelState.AddModelError("", "El usuario y/o contraseñas son incorrectos.");
                        retorno = View("Index");
                    }
                
            } else {
                ModelState.AddModelError("", "El usuario y/o contraseñas son incorrectos.");
                retorno = View("Index");
            }
           
                
            return retorno;
        }
            

        //POST: Logout
        [HttpPost]
            public ActionResult Logout() {
                System.Diagnostics.Debug.Write("He llegado a logout");
                Session.Abandon();
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Home");
            }
        }
        }