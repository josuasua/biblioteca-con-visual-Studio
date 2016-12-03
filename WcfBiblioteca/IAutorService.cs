using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfBiblioteca {
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAutorService {

        [OperationContract]
        string GetVersion();

        [OperationContract()]
        Autor getAutorById(int codigoAutor);

        // TODO: agregue aquí sus operaciones de servicio
    }


    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class Autor {

        string nombre = "";
        //string apellidos = "";
        string errorMessage = "";

        [DataMember]
        public string Nombre {
            get {
                return nombre;
            }
            set {
                nombre = value;
            }
        }

        [DataMember]
        public string ErrorMessage {
            get {
                return errorMessage;
            }
            set {
                errorMessage = value;
            }
        }
    }
    }
