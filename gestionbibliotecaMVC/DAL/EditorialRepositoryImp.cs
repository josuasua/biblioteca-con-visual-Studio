﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionBibliotecaMVC.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GestionBibliotecaMVC.DAL {
    public class EditorialRepositoryImp : EditorialRepository {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["gestionBiblioteca"].ConnectionString;
        public Editorial create(Editorial editorial) {
            const string SQL = "crearEditorial";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("@editorial", editorial.Nombre);
                cmd.Parameters.Add("@idEditorial", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                editorial.CodEditorial = Convert.ToInt32(cmd.Parameters["@idEditorial"].Value);

            }
            return editorial;
        }

        public void delete(int id) {
            const string SQL = "borrarEditorial";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codigo", id);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public IList<Editorial> getAll() {
            IList<Editorial> editoriales = null;
            const string SQL = "mostrarEditoriales";
            Editorial editorial;

            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();

                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows) {
                        editoriales = new List<Editorial>();
                        while (reader.Read()) {
                            editorial = parseEditorial(reader);
                            editoriales.Add(editorial);
                        }
                    }
                }
            }

            return editoriales;
        }

        private Editorial parseEditorial(SqlDataReader reader) {
            Editorial editorial = new Editorial();
            editorial.CodEditorial = Convert.ToInt32(reader["idEditorial"]);
            editorial.Nombre = Convert.ToString(reader["editorial"]);
            return editorial;
        }

        public Editorial getById(int id) {
            Editorial editorial = null;
            const string SQL = "mostrarUnEditorial";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                conexion.Open();
                cmd.Parameters.AddWithValue("codigo", id);
                using (SqlDataReader reader = cmd.ExecuteReader()) {
                    if (reader.HasRows) {
                        while (reader.Read()) {

                            editorial = parseEditorial(reader);
                        }
                    }
                }
            }
            return editorial;
        }

        public Editorial update(Editorial editorial) {
            const string SQL = "actualizarEditorial";

            using (SqlConnection conexion = new SqlConnection(cadenaConexion)) {
                SqlCommand cmd = new SqlCommand(SQL, conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEditorial", editorial.CodEditorial);
                cmd.Parameters.AddWithValue("@editorial", editorial.Nombre);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            return editorial;
        }
    }
}