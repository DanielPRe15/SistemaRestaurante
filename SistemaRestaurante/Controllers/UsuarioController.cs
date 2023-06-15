using Microsoft.AspNetCore.Mvc;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.Controllers
{
    public class UsuarioController : Controller
    {
        DBUsuario dbu = new DBUsuario();


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ManUser()
        {
            List<Usuario> lstUsuarios = dbu.listarUsuarios();
            return View(lstUsuarios);
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(int id, string nombre, string pass)
        {
            int nroUsuario = dbu.crear(id, nombre, pass);
            ViewBag.mensaje = "Usuario Creado";

            return View();
        }
        public IActionResult Editar(int id)
        {
            Usuario usuario = dbu.obtenerId(id);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Editar(Usuario usuario)
        {
            int nroUsuarios = dbu.actualizar(usuario);

            if (nroUsuarios == 1)
            {
                ViewBag.mensaje = "Se actualizo correctamente";
            }
            else
            {
                ViewBag.mensaje = "No se puso Actualizar";
            }

            return View(usuario);
        }

        public IActionResult Eliminar(int id)
        {
            Usuario usuario = dbu.obtenerId(id);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario usuario)
        {
            Usuario usuarioEliminar = dbu.obtenerId(usuario.id);

            int nroUsuario = dbu.eliminar(usuario.id);
            if (nroUsuario == 1)
            {
                ViewBag.mensaje = "Usuario eliminado";
            }
            else
            {
                ViewBag.mensaje = "Usuario no eliminado";
            }

            return View(usuarioEliminar);
        }

    }
}

