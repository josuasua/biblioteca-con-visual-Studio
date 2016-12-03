using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace GestionBibliotecaMVC.Models
{
    public class Autor
    {
       
        private int _codAutor;
        private string _nombre;
        private string _apellidos;
        [Display(Name = "Nombre", ResourceType = typeof(MyResources.AutorResources))]
        public string NombreCompleto { get { return this._nombre + " " + this._apellidos; } }
        public Autor()
        {
            this._codAutor = -1;
            this._nombre = "";
            this._apellidos = "";

        }
        public int CodAutor
        {
            get
            {
                return _codAutor;
            }

            set
            {
                _codAutor = value;
            }
        }

        //Con el DisplayName puedes poner un alias para en la vista ver este nombre con html.labelfor, aunque lo malo es que no se puede internacionalizar
        [Display (Name="Nombre", ResourceType=typeof(MyResources.AutorResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.AutorResources),
            ErrorMessageResourceName = "Nombrerequerido")]
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        //Con el DisplayName puedes poner un alias para en la vista ver este nombre con html.labelfor, aunque lo malo es que no se puede internacionalizar
        [Display(Name = "Apellidos", ResourceType = typeof(MyResources.AutorResources))]
        [Required(ErrorMessageResourceType = typeof(MyResources.AutorResources),
            ErrorMessageResourceName = "Apellidorequerido")]
        public string Apellidos {
            get {
                return _apellidos;
            }

            set {
                _apellidos = value;
            }
        }


    }
}