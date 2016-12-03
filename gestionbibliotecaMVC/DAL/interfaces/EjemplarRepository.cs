using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionBibliotecaMVC.DAL
{
    public interface EjemplarRepository
    {
        IList<Ejemplar> getAll();

        void delete(int id);

        Ejemplar create(Ejemplar ejemplar);

        Ejemplar update(Ejemplar ejemplar);

        Ejemplar getById(int id);

        IList<Ejemplar> getByIdDeLibro(int codLibro);


    }
}