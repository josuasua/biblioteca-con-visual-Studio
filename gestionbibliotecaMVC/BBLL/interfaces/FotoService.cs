using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GestionBibliotecaMVC.BBLL.interfaces {
    interface FotoService {

        Foto getByID(int idFoto);
        Foto create(Foto foto);
        Foto update(Foto foto);
        void delete(int idFoto);

    }
}
