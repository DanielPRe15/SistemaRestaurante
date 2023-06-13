using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.Controllers
{
    public class PlatosController : Controller
    {

        BDPlatos bdp = new BDPlatos();

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Listado()
        {
            // Muestra la lista de clientes de la BD
            List<Platos> listaPlatos = bdp.ObtenerTodos();
            return View(listaPlatos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Int32 id, string nombre, decimal precio)
        {
            int nroRegistros = bdp.Crear(id, nombre, precio);
            ViewBag.mensaje = "Cliente creado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            return View();
        }


        [HttpGet]
        public IActionResult Editar(Int32 id)
        {
            Platos cliente = bdp.ObtenerPorId(id);
            return View(cliente);
        }
        [HttpPost]
        public IActionResult Editar(Platos platos)
        {
            int nroRegistros = bdp.Actualizar(platos);
            if (nroRegistros == 1)
            {
                ViewBag.mensaje = "Plato actualizado correctamente";
            }
            else
            {
                ViewBag.mensaje = "Plato NO actualizado";
            }

            return View(platos);
        }

        public IActionResult Eliminar(Int32 id)
        {
            Platos platos = bdp.ObtenerPorId(id);
            return View(platos);
        }
        [HttpPost]
        public IActionResult Eliminar(Platos platos)
        {
            Platos platosEliminar = bdp.ObtenerPorId(platos.Id);
            int nroRegistros = bdp.Borrar(platos.Id);

            if (nroRegistros == 1)
            {
                ViewBag.mensaje = "Cliente eliminado correctamente";
            }
            else
            {
                ViewBag.mensaje = "Cliente NO eliminado correctamente";
            }

            return View(platosEliminar);
        }

    }
}
