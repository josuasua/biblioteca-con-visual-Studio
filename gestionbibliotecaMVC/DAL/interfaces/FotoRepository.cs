using GestionBibliotecaMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GestionBibliotecaMVC.DAL.interfaces {
    interface FotoRepository {

        void delete(int id);

        Foto create(Foto foto);

        Foto update(Foto foto);

        Foto getById(int id);

    }
}
