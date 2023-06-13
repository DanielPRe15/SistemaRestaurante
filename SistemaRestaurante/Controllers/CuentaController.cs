using Microsoft.AspNetCore.Mvc;
using SistemaRestaurante.Data;
using SistemaRestaurante.Models;
using System.Data;
using System.Data.SqlClient;

namespace SistemaRestaurante.Controllers
{
    public class CuentaController : Controller
    {
        private readonly DbContext _contexto;

        public CuentaController(DbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View("Registrar");
        }

        [HttpPost]
        public ActionResult Registrar(UsuarioModel u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_contexto.Valor))
                    {
                        using (SqlCommand cmd = new("sp_registrar", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = u.Nombre;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = u.Clave;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    return RedirectToAction("login", "Cuenta");
                }
            }
            catch (Exception)
            {
                return View("Registrar");
            }
            ViewData["error"] = "Error de credenciales";
            return View("Registrar");
        }

        public ActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginModel l)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new(_contexto.Valor))
                    {
                        using (SqlCommand cmd = new("sp_login", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = l.Nombre;
                            cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = l.Clave;
                            con.Open();

                            SqlDataReader dr = cmd.ExecuteReader();

                       
                            con.Close();
                        }
                    }
                    return RedirectToAction("Inicio", "Inicio");
                }
            }
            catch (Exception)
            {
                return View("Inicio", "Inicio");
            }
            return View("Inicio", "Inicio");
        }

        public ActionResult Logout()
        {
            Response.Cookies.Delete("user");
            return RedirectToAction("Inicio", "Inicio");
        }
    }
}
