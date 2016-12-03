using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionBibliotecaMVC.ModelView {
    public class PrestamoModelView {

        public Prestamos prestamos {get; set;}
        public IDictionary<int,string> ejemplares{get;set;}
    }
}