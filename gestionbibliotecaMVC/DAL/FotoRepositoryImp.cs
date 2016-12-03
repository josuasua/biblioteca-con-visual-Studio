using GestionBibliotecaMVC.DAL.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionBibliotecaMVC.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GestionBibliotecaMVC.DAL {
    public class FotoRepositoryImp : FotoRepository {

        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;

        public Foto create(Foto foto) {
            const string SQL = "crearFoto";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                
                cmd.Parameters.AddWithValue("@imagen", "");
                cmd.Parameters.Add("@idFoto", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                foto.idFoto = Convert.ToInt32(cmd.Parameters["@idFoto"].Value);

            }

            return foto;
        }

        public void delete(int id) {
            const string SQL = "borrarFoto";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", id);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public Foto getById(int id) {
            Foto foto = new Foto();
            const string SQL = "mostrarUnaFoto";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@codigo", id);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            foto = parseFoto(reader);
                        }
                    }
                }
            }
            return foto;
        }

        public Foto update(Foto foto) {
            const string SQL = "actualizarFoto";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                conexion.Open();
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idFoto", foto.idFoto);
                cmd.Parameters.AddWithValue("@imagen", foto.imagen);            
                cmd.ExecuteNonQuery();
            }

            return foto;
        }

        private Foto parseFoto(SqlDataReader reader) {
            Foto foto = new Foto();
            foto.idFoto = Convert.ToInt32(reader["idFoto"]);
            foto.imagen = Convert.ToString(reader["imagen"]);
            return foto;
        }
    }
     
}