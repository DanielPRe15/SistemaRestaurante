using System.Data;
using System.Data.SqlClient;

namespace SistemaRestaurante.Models
{
    public class BDPlatos
    {
        // Cambiar la cadena de conexion segun tu configuración
        string cadenaConexion = "Data Source=DESKTOP-CRJD420;Initial Catalog=BD_RESTAURANTE2;Integrated Security=True;";

        public List<Platos> ObtenerTodos()
        {
            List<Platos> listaPlatos = new List<Platos>();
            SqlConnection con = new SqlConnection(cadenaConexion);
            string sql = "select * from PLATOS";
            SqlCommand cmd = new SqlCommand(sql, con);

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

        public Platos ObtenerPorId(Int32 id)
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

        public int Crear(Int32 id, string nombre, decimal precio)
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
