using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionBibliotecaMVC.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GestionBibliotecaMVC.DAL
{
    public class PrestamosRepositoryImp : PrestamosRepository
    {

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Prestamos create(Prestamos prestamos)
        {
            const string SQL = "crearPrestamo";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();          

                cmd.Parameters.AddWithValue("@fRecogida", prestamos.FRecogida);
                cmd.Parameters.AddWithValue("@idEjemplar", prestamos.Ejemplar.CodEjemplar);
                cmd.Parameters.AddWithValue("@idUsuario", prestamos.Usuario.CodUsuario);
                cmd.Parameters.Add("@idPrestamo", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                prestamos.CodPrestamo = Convert.ToInt32(cmd.Parameters["@idPrestamo"].Value);
                
            }
            return prestamos;
        }

        public IList<Prestamos> getAll()
        {
            const string SQL = "mostrarPrestamos";
            IList<Prestamos> prestamos = null;
            Prestamos prestamo = null;
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                prestamos = new List<Prestamos>();
                conexion.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            prestamo = parsePrestamo(reader);
                            prestamos.Add(prestamo);
                        }
                    }
                }

            }
            return prestamos;
        }

        public IList<Prestamos> getPrestamosUsuario(int codigo) {
            const string SQL = "mostrarPrestamosByIdUsuario";
            IList<Prestamos> prestamos = null;
            Prestamos prestamo = null;
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                prestamos = new List<Prestamos>();
                conexion.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", codigo);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            prestamo = parsePrestamo(reader);
                            prestamos.Add(prestamo);
                        }
                    }
                }

            }
            return prestamos;
        }

        private Prestamos parsePrestamo(SqlDataReader reader)
        {
            Prestamos prestamo = new Prestamos();
            prestamo.CodPrestamo = Convert.ToInt32(reader["idPrestamo"]);
            if (reader["fDevolucion"] != DBNull.Value) {
                prestamo.FDevolucion = Convert.ToDateTime(reader["fDevolucion"]);
            }
            prestamo.FRecogida = Convert.ToDateTime(reader["fRecogida"]);
            prestamo.Ejemplar.Titulo = Convert.ToString(reader["titulo"]);
            prestamo.Usuario.CodUsuario = Convert.ToInt32(reader["idUsuario"]);
            
          //  prestamo.Ejemplar.Autor.Nombre = Convert.ToString(reader["nombreAutor"]);
            return prestamo;

        }

        public Prestamos getById(int id)
        {
            const string SQL = "mostrarUnPrestamo";
            Prestamos prestamo = null;
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@codigo", id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            prestamo = parsePrestamo(reader);
                        }
                    }
                }
            }
            return prestamo;
        }

        public Prestamos update(Prestamos prestamos)
        {
            const string SQL = "actualizarPrestamo";
            using(SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                conexion.Open();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@fDevolucion", prestamos.FDevolucion);
                cmd.Parameters.AddWithValue("@idPrestamo", prestamos.CodPrestamo);
                
                cmd.ExecuteNonQuery();
            }
            return prestamos;
        }
    }
}