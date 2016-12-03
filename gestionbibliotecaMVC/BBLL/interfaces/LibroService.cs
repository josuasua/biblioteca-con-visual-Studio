using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotecaMVC.BBLL.interfaces
{
    interface LibroService
    {
        Libro getById(int codigoLibro);

        Libro create(Libro libro);

        Libro update(Libro libro);

        void delete(int codigoLibro);

        IList<Libro> getAll();
    }
}
