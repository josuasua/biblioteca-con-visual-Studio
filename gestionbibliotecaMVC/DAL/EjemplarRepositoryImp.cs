using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionBibliotecaMVC.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.Remoting.Contexts;
using System.Data;

namespace GestionBibliotecaMVC.DAL
{
    public class EjemplarRepositoryImp : EjemplarRepository
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;
        public Ejemplar create(Ejemplar ejemplar)
        {
            const string SQL = "crearEjemplar";
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@isbn", ejemplar.ISBN);
                cmd.Parameters.AddWithValue("@numeropaginas", ejemplar.NumPaginas);
                cmd.Parameters.AddWithValue("@fPublicacion", ejemplar.FPublicacion);
                cmd.Parameters.AddWithValue("@idLibro", ejemplar.CodLibro);
                cmd.Parameters.AddWithValue("@idEditorial", ejemplar.CodEditorial);
                cmd.Parameters.Add("@idEjemplar", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                ejemplar.CodEjemplar = int.Parse(cmd.Parameters["@idEjemplar"].Value.ToString());
               
            }
            return ejemplar;
        }

        public void delete(int id)
        {
            const string SQL = "borrarEjemplar";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                conexion.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo",id);
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Ejemplar> getAll()
        {
            const string SQL = "mostrarEjemplares";
            IList<Ejemplar> ejemplares = null;
            Ejemplar ejemplar = null;

            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
               
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    ejemplares = new List<Ejemplar>();
                    if (reader.HasRows){
                        ejemplares = new List<Ejemplar>();
                        while (reader.Read())
                        {
                            ejemplar = parseEjemplar(reader);
                            ejemplares.Add(ejemplar);
                        }
                    }
                   
                }
            }
            return ejemplares;
        }

        public Ejemplar getById(int id)
        {
            const string SQL = "mostrarUnEjemplar";
            Ejemplar ejemplar = null;

            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@codigo", id);
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ejemplar = parseEjemplar(reader);
                        }
                    }
                }
            }
            return ejemplar;
        }

        public IList<Ejemplar> getByIdDeLibro(int codLibro) {

            const string SQL = "mostrarEjemplaresPorLibro";
            IList<Ejemplar> ejemplares = null;
            Ejemplar ejemplar = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {

                conexion.Open();
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idLibro", codLibro);
                cmd.ExecuteNonQuery();
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    ejemplares = new List<Ejemplar>();
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            ejemplar = parseEjemplar(reader);
                            ejemplares.Add(ejemplar);
                        }
                    }
                }
                    
            }
                return ejemplares;

        }

        public Ejemplar update(Ejemplar ejemplar)
        {
            const string SQL = "actualizarEjemplar";
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEjemplar", ejemplar.CodEjemplar);
                cmd.Parameters.AddWithValue("@isbn", ejemplar.ISBN);
                cmd.Parameters.AddWithValue("@idLibro", ejemplar.CodLibro);
                cmd.Parameters.AddWithValue("@numeropaginas", ejemplar.NumPaginas);
                cmd.Parameters.AddWithValue("@idEditorial", ejemplar.CodEditorial);
                cmd.Parameters.AddWithValue("@fPublicacion", ejemplar.FPublicacion);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            
            return ejemplar;
        }

        private Ejemplar parseEjemplar(SqlDataReader reader)
        {
            Ejemplar ejemplar = new Ejemplar();
            ejemplar.CodEjemplar = Convert.ToInt32(reader["idEjemplar"]);
            ejemplar.ISBN = Convert.ToString(reader["isbn"]);
            ejemplar.NumPaginas = Convert.ToInt32(reader["numeropaginas"]);
            ejemplar.FPublicacion = Convert.ToDateTime(reader["fPublicacion"]);
            ejemplar.CodEditorial = Convert.ToInt32(reader["idEditorial"]);
            ejemplar.Titulo = Convert.ToString(reader["titulo"]);
            ejemplar.CodigoAutor = Convert.ToInt32(reader["idAutor"]);
         //   ejemplar.Autor.Nombre = Convert.ToString(reader["nombreAutor"]);
          //  ejemplar.Autor.Apellidos = Convert.ToString(reader["apellidosAutor"]);
            ejemplar.CodLibro = Convert.ToInt32(reader["codLibro"]);
            return ejemplar;
        }
    }
}