using GestionBibliotecaMVC.BBLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionBibliotecaMVC.Models;
using GestionBibliotecaMVC.DAL;

namespace GestionBibliotecaMVC.BBLL
{

    public class PrestamosServiceImp : PrestamosService
    {
        private PrestamosRepository pr;

        public PrestamosServiceImp()
        {
            pr = new PrestamosRepositoryImp();
        }

        public Prestamos create(Prestamos prestamo)
        {
            pr.create(prestamo);
            return prestamo;
        }

        public IList<Prestamos> getAll()
        {
            return pr.getAll();
        }

        public IList<Prestamos> getPrestamosUsuario(int codigo) {
            return pr.getPrestamosUsuario(codigo);
        }

        public Prestamos getById(int codigoPrestamos)
        {
            return pr.getById(codigoPrestamos);
        }

        public Prestamos update(Prestamos prestamo)
        {
            return pr.update(prestamo);
        }
    }
}