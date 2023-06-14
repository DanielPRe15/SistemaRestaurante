using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.Pkcs;

namespace SistemaRestaurante.Models
{
    public class BDVentas
    {
        string cadenaConexion = "Data Source=DESKTOP-EPJTHR4;Initial Catalog=BD_RESTAURANTE;Integrated Security=True;";

        public List<Pedidos> ObtenerTodos()
        {
            
            List<Pedidos> listaPedidos = new List<Pedidos>();
            SqlConnection con = new SqlConnection(cadenaConexion);
            string sql = "SELECT * FROM PEDIDOS";
                
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Pedidos pedidos = new Pedidos();
                pedidos.IdPedido = dr.GetInt32(0);
                pedidos.Nombre = dr.GetString(1);
                pedidos.IdPlato = dr.GetInt32(2);
                pedidos.NumeroMesa = dr.GetInt32(3);
                listaPedidos.Add(pedidos);

            }
            return listaPedidos;

        }

        public Pedidos ObtnerPorId(int IdPedido)
        {
            Pedidos pedidos = new Pedidos();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PEDIDOS WHERE idPedido=@id", con);
            cmd.Parameters.AddWithValue("@id", IdPedido);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                pedidos.IdPedido = dr.GetInt32(0);
                pedidos.Nombre = dr.GetString(1);
                pedidos.NumeroMesa = dr.GetInt32(2);


            }
            return pedidos;

        }

        



    }
}
