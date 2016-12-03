using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace GestionBibliotecaMVC.Models
{
    /*
     * Como la herencia y la implementacion se hace con los dos puntos, si queremos heradar e implementar,
     *  en primer lugar pondremos la herencia y posteriormente pondremos las implementaciones separadas por un ' ' 
     */
    public class Ejemplar : Libro {
        private int _codEjemplar;
        private string _iSBN;
        private int _numPaginas;
        private DateTime _fPublicacion;
        private int codEditorial;
        private Editorial _editorial;

        public Ejemplar() : base()
        {
            this._codEjemplar = -1;
            this._iSBN = "";
            this._numPaginas = 0;
            this._fPublicacion = new DateTime();
            this._editorial = new Editorial();
            this.codEditorial = -1;
        }

        public int CodEjemplar
        {
            get
            {
                return _codEjemplar;
            }

            set
            {
                _codEjemplar = value;
            }
        }
        [Display(Name = "ISBN", ResourceType = typeof(MyResources.EjemplarResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.EjemplarResources),
            ErrorMessageResourceName = "ISBNrequerido")]
        public string ISBN
        {
            get
            {
                return _iSBN;
            }

            set
            {
                _iSBN = value;
            }
        }
        [Display(Name = "Numeropaginas", ResourceType = typeof(MyResources.EjemplarResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.EjemplarResources),
            ErrorMessageResourceName = "Numeropaginasrequerido")]
        public int NumPaginas
        {
            get
            {
                return _numPaginas;
            }

            set
            {
                _numPaginas = value;
            }
        }
        [DisplayFormat(DataFormatString = @"{dd\/MM\/yyyy}") ]
        [Display(Name = "FPublicacion", ResourceType = typeof(MyResources.EjemplarResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.EjemplarResources),
            ErrorMessageResourceName = "FPublicacionrequerido")]
        public DateTime FPublicacion
        {
            get
            {
                return _fPublicacion;
            }

            set
            {
                _fPublicacion = value;
            }
        }

        public int CodEditorial {
            get {
                return codEditorial;
            }

            set {
                codEditorial = value;
            }
        }

        /*
        //El virtual deja que este objeto aunque tenga validación, desde ejemplar no la necesita
        public virtual Editorial Editorial
        {
            get
            {
                return _editorial;
            }

            set
            {
                _editorial = value;
            }
        }*/
    }
}