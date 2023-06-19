
using System.Data;
using System.Data.SqlClient;

namespace SistemaRestaurante.Models
{
    public class BDVentas
    {
        string cadenaConexion = "Data Source=DESKTOP-EPJTHR4;" +
        "Initial Catalog=BD_RESTAURANTE;" +
"Integrated Security=True;";

        public List<Pedidos> ObtenerTodos()
        {
            
            List<Pedidos> listaPedidos = new List<Pedidos>();
            SqlConnection con = new SqlConnection(cadenaConexion);
            string sql = "SELECT  P.idPedido, P.nombreCliente, PA.NOM_PLATO, PA.PRECIO_PLATO, P.numeroMesa FROM PEDIDOS P INNER JOIN PLATOS PA ON P.idPlato = PA.ID_PLATO";
                
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Pedidos pedidos = new Pedidos();
                pedidos.IdPedido = dr.GetInt32(0);
                pedidos.Nombre = dr.GetString(1);
                pedidos.NombrePlato = dr.GetString(2);
                pedidos.PrecioPlatos = dr.GetDecimal(3);
                pedidos.NumeroMesa = dr.GetInt32(4);
                listaPedidos.Add(pedidos);

            }
            return listaPedidos;

        }

        public Pedidos ObtnerPorId(int idPedido)
        {
            Pedidos pedidos = new Pedidos();
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM PEDIDOS WHERE idPedido=@id", con);
            cmd.Parameters.AddWithValue("@id", idPedido);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                pedidos.IdPedido = dr.GetInt32(0);
                pedidos.Nombre = dr.GetString(1);
                pedidos.NombrePlato = dr.GetString(2);
                pedidos.PrecioPlatos = dr.GetDecimal(3);
                pedidos.NumeroMesa = dr.GetInt32(4);


            }
            return pedidos;

        }

        public int Crear(int idVenta, int idPedido, decimal montoTotal)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spCrearVenta", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdVenta", idVenta);
            cmd.Parameters.AddWithValue("@IdPedido", idPedido);
            cmd.Parameters.AddWithValue("@MontoTotal", montoTotal);

            con.Open();
            int nroVentas = cmd.ExecuteNonQuery();
            con.Close();
            return nroVentas;
        }

        public int Actualizar(Pedidos pedidos)
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            SqlCommand cmd = new SqlCommand("spActualizarPedidos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IdPedido", pedidos.IdPedido);
            cmd.Parameters.AddWithValue("@Nombre", pedidos.nombreCliene);
            cmd.Parameters.AddWithValue("@NombrePlato", pedidos.NombrePlato);
            cmd.Parameters.AddWithValue("@PrecioPlato", pedidos.PrecioPlatos);
            cmd.Parameters.AddWithValue("@NumeroMesa", pedidos.NumeroMesa);

            con.Open();
            int nroPlatos = cmd.ExecuteNonQuery();
            con.Close();
            return nroPlatos;
        }


    }
}
