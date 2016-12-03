using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionBibliotecaMVC.ModelView {
    public class LibroModelView {
        private int _codLibro;
        private string _titulo;
        private int _codAutor;
        private string _nombre;

        public LibroModelView() {
            this._codLibro = -1;
            this._titulo = "";
            this._codAutor = -1;
            this._nombre = "";

        }
        public int CodLibro {
            get {
                return _codLibro;
            }

            set {
                _codLibro = value;
            }
        }
        [Display(Name = "Titulo", ResourceType = typeof(MyResources.LibroResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.LibroResources),
            ErrorMessageResourceName = "Titulorequerido")]
        public string Titulo {
            get {
                return _titulo;
            }

            set {
                _titulo = value;
            }
        }

        public int CodAutor {
            get {
                return _codAutor;
            }
            set {
                _codAutor = value;
            }
        }

        public string Nombre {
            get {
                return _nombre;
            }
            set {
                _nombre = value;
            }
        }
    }
}