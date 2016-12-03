using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionBibliotecaMVC.App_Start {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new System.Web.Mvc.AuthorizeAttribute()); // sirve para autorizaciones y permisos
            // filters.Add(new RequireHttpsAttribute()); // este sirve para Https con ssl, no descomentar, solo usaremos Authorize
        }
    }

    
}