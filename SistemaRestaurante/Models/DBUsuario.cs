using System.Data.SqlClient;
using System.Data;

namespace SistemaRestaurante.Models
{
    public class DBUsuario
    {
        //cadena conexion
        string conexion = "Data Source=DESKTOP-EPJTHR4;Initial Catalog=BD_RESTAURANTE;Integrated Security=True;";

        //listar usuarios
        public List<Usuario> listarUsuarios()
        {
            //lista
            List<Usuario> lstUsuarios = new List<Usuario>();


            //conexion
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("SELECT * FROM usuario", con);

            con.Open();

            //ejecucion cmd
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                //instacia objeto de la clase Usuario
                Usuario user = new Usuario();

                //obtener datos de la consulta
                user.id = dr.GetInt32(0);
                user.nombre = dr.GetString(1);
                user.pass = dr.GetString(2);

                //agregamos el obj a la lista de usuarios
                lstUsuarios.Add(user);
            }

            //retornamos lista de usuarios
            return lstUsuarios;



        }

        //crear usuarios
        public int crear(int id, string nombre, string pass)
        {
            SqlConnection con = new SqlConnection(conexion);

            SqlCommand cmd = new SqlCommand("spCrearUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@pass", pass);

            //abrimos conexion
            con.Open();
            int nroUsuario = cmd.ExecuteNonQuery();

            con.Close();

            return nroUsuario;

        }

        //actualizar usuarios
        public int actualizar(Usuario usuario)
        {
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("spActualizarUsuario", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", usuario.id);
            cmd.Parameters.AddWithValue("@nombre", usuario.nombre);
            cmd.Parameters.AddWithValue("@pass", usuario.pass);

            con.Open();

            int nroUsuarios = cmd.ExecuteNonQuery();

            con.Close();


            return nroUsuarios;
        }

        //Eliminar usuario
        public int eliminar(int id)
        {
            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("spEliminarUsuario", con);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();

            int nroUsuarios = cmd.ExecuteNonQuery();

            con.Close();

            return nroUsuarios;

        }

        //obtener id
        public Usuario obtenerId(int id)
        {
            Usuario user = new Usuario();


            SqlConnection con = new SqlConnection(conexion);
            SqlCommand cmd = new SqlCommand("select * from USUARIO where IdUsuario=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {


                user.id = dr.GetInt32(0);
                user.nombre = dr.GetString(1);
                user.pass = dr.GetString(2);

            }
            return user;
        }
    }
}

