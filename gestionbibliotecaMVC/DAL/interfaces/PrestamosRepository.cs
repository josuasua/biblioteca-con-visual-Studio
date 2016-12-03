using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBibliotecaMVC.DAL
{
    interface PrestamosRepository
    {
        IList<Prestamos> getAll();

        Prestamos getById(int id);

        Prestamos create(Prestamos prestamos);

        Prestamos update(Prestamos prestamos);

        IList<Prestamos> getPrestamosUsuario(int codigo);


    }
}
