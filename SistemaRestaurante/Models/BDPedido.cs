using System.Data.SqlClient;
using System.Data;

namespace SistemaRestaurante.Models
{
    public class BDPedido
    {
        string cadenaConexion = "Data Source=DESKTOP-EPJTHR4;" +
         "Initial Catalog=BD_RESTAURANTE;" +
 "Integrated Security=True;";



        public int Crear( string nombre, int idPlato, int idBebida, int numeroMesa)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spCrearPedidos", con);
            cmd.CommandType = CommandType.StoredProcedure;
        
            cmd.Parameters.AddWithValue("@nombreCliente", nombre);
            cmd.Parameters.AddWithValue("@idPlato", idPlato);
            cmd.Parameters.AddWithValue("@idBebida", idBebida);
            cmd.Parameters.AddWithValue("@numeroMesa", numeroMesa);
       

            con.Open();
            int nroPedidos = cmd.ExecuteNonQuery();
            con.Close();
            return nroPedidos;
        }


    }
}
