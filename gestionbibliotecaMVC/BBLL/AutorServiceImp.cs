using gestionbibliotecaMVC.BBLL.interfaces;
using System;
using System.Collections.Generic;
using GestionBibliotecaMVC.Models;
using GestionBibliotecaMVC.DAL;

namespace GestionBibliotecaMVC.BBLL
{
    public class AutorServiceImp : AutorService
    {
        private AutorRepository aR;

        public AutorServiceImp()
        {
            aR = new AutorRepositoryImp();
        }
        public Autor create(Autor autor)
        {
            return aR.create(autor);
        }

        public void delete(int codigoAutor)
        {
            aR.delete(codigoAutor);
        }

        public IList<Autor> getAll()
        {
            return aR.getAll();
        }

        public Autor getByID(int codigoAutor)
        {
            return aR.getById(codigoAutor);
        }

        public Autor update(Autor autor)
        {
            return aR.update(autor);
        }
    }
}