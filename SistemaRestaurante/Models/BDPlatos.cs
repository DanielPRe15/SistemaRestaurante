﻿using System;
using System.Data;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

namespace SistemaRestaurante.Models
{
    public class BDPlatos
    {
        // Cambiar la cadena de conexion segun tu configuración
        string cadenaConexion = "Data Source=DESKTOP-EPJTHR4;" +
        "Initial Catalog=BD_RESTAURANTE;"+
"Integrated Security=True;";
       
        public List<Platos> ObtenerTodos()
        {
            List<Platos> listaPlatos = new List<Platos>();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PLATOS", con);


            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Platos platos = new Platos();
                platos.Id = dr.GetInt32(0);
                platos.Nombre = dr.GetString(1);
                platos.Precio = dr.GetDecimal(2);
                listaPlatos.Add(platos);
            }
            return listaPlatos;
        }

        public Platos ObtenerPorId(int id)
        {
            Platos platos = new Platos();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PLATOS WHERE ID_PLATO=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                platos.Id = dr.GetInt32(0);
                platos.Nombre = dr.GetString(1);
                platos.Precio = dr.GetDecimal(2);

            }
            return platos;
        }

        public int Crear(int id, string nombre, decimal precio)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spCrearPlato", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@codPlato", id);
            cmd.Parameters.AddWithValue("@nomPlato", nombre);
            cmd.Parameters.AddWithValue("@precio", precio);

            con.Open();
            int nroPlatos = cmd.ExecuteNonQuery();
            con.Close();
            return nroPlatos;
        }
        public int Actualizar(Platos platos)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spActualizarPlatos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", platos.Id);
            cmd.Parameters.AddWithValue("@nombre", platos.Nombre);
            cmd.Parameters.AddWithValue("@precio", platos.Precio);
          
            con.Open();
            int nroPlatos = cmd.ExecuteNonQuery();
            con.Close();
            return nroPlatos;
        }
        public int Borrar(int id)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spBorrarPlatos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int nroPlatos = cmd.ExecuteNonQuery();
            con.Close();
            return nroPlatos;
        }


    }
}
