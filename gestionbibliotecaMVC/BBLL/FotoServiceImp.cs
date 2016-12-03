using GestionBibliotecaMVC.BBLL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionBibliotecaMVC.Models;
using GestionBibliotecaMVC.DAL.interfaces;
using GestionBibliotecaMVC.DAL;

namespace GestionBibliotecaMVC.BBLL {
    public class FotoServiceImp : FotoService {

        private FotoRepository fR;
        public FotoServiceImp() {
            fR = new FotoRepositoryImp();
        }

        public Foto create(Foto foto) {
            return fR.create(foto);
        }

        public void delete(int idFoto) {
            fR.delete(idFoto);
        }

        public Foto getByID(int idFoto) {
            return fR.getById(idFoto);
        }

        public Foto update(Foto foto) {
            return fR.update(foto);
        }
    }
}