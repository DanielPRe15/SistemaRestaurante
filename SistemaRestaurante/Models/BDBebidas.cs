using System.Data.SqlClient;
using System.Data;

namespace SistemaRestaurante.Models
{
    public class BDBebidas
    {
        // Cambiar la cadena de conexion segun tu configuración
        string cadenaConexion = "Data Source=DESKTOP-EPJTHR4;" +
        "Initial Catalog=BD_RESTAURANTE;" +
"Integrated Security=True;";

        public List<Bebidas> ObtenerTodos()
        {
            List<Bebidas> listaBebidas = new List<Bebidas>();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BEBIDAS", con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Bebidas bebidas = new Bebidas();
                bebidas.IdBe = dr.GetInt32(0);
                bebidas.NombreBe = dr.GetString(1);
                bebidas.PrecioBe = dr.GetDecimal(2);
                listaBebidas.Add(bebidas);
            }
            return listaBebidas;
        }

        public Bebidas ObtenerPorId(int id)
        {
            Bebidas bebidas = new Bebidas();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BEBIDAS WHERE ID_BEBIDA=@id", con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                bebidas.IdBe = dr.GetInt32(0);
                bebidas.NombreBe = dr.GetString(1);
                bebidas.PrecioBe = dr.GetDecimal(2);

            }
            return bebidas;
        }

        public int Crear( int id, string nombre, decimal precio)
        {   
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spCrearBebida", con);
            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.Parameters.AddWithValue ("@id", id);
            cmd.Parameters.AddWithValue("@nomBebida", nombre);
            cmd.Parameters.AddWithValue("@precio", precio);

            con.Open();
            int nroBebidas = cmd.ExecuteNonQuery();
            con.Close();
            return nroBebidas;
        }
        public int Actualizar(Bebidas bebidas)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spActualizarBebidas", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", bebidas.IdBe);
            cmd.Parameters.AddWithValue("@nombre", bebidas.NombreBe);
            cmd.Parameters.AddWithValue("@precio", bebidas.PrecioBe);

            con.Open();
            int nroBebidas = cmd.ExecuteNonQuery();
            con.Close();
            return nroBebidas;
        }
        public int Borrar(int id)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spBorrarBebidas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            int nroBebidas = cmd.ExecuteNonQuery();
            con.Close();
            return nroBebidas;
        }

    }
}
