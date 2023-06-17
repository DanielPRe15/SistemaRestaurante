using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaRestaurante.Models;
using System.Runtime.Intrinsics.Arm;

namespace SistemaRestaurante.Controllers
{
    public class BebidasController : Controller
    {

        BDBebidas bdb = new BDBebidas();
        

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Listado()
        {
            // Muestra la lista de clientes de la BD
            List<Bebidas> listaBebidas = bdb.ObtenerTodos();
            return View(listaBebidas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            List<Bebidas> bebidas = bdb.ObtenerTodos();
          
            return View();



            }
        [HttpPost]
        public IActionResult Crear(int id, string nombre, decimal precio)
        {
            int nroRegistros = bdb.Crear(id, nombre, precio);
            ViewBag.mensaje = "Bebida creado correctamente";
            List<Bebidas> bebidas = bdb.ObtenerTodos();
            return View();
        }


        [HttpGet]
        public IActionResult Editar(int id)
        {
            Bebidas bebidas = bdb.ObtenerPorId(id);
            return View(bebidas);
        }
        [HttpPost]
        public IActionResult Editar(Bebidas bebidas)
        {
            int nroRegistros = bdb.Actualizar(bebidas);
            if (nroRegistros == 1)
            {
                ViewBag.mensaje = "Bebida actualizada correctamente";
            }
            else
            {
                ViewBag.mensaje = "Bebido NO actualizado";
            }

            return View(bebidas);
        }

        public IActionResult Eliminar(int id)
        {
            Bebidas bebidas = bdb.ObtenerPorId(id);
            return View(bebidas);
        }
        [HttpPost]
        public IActionResult Eliminar(Bebidas bebidas)
        {
            Bebidas bebidasEliminar = bdb.ObtenerPorId(bebidas.IdBe);
            int nroRegistros = bdb.Borrar(bebidas.IdBe);

            if (nroRegistros == 1)
            {
                ViewBag.mensaje = "Bebida eliminado correctamente";
            }
            else
            {
                ViewBag.mensaje = "Bebida NO eliminado correctamente";
            }

            return View(bebidasEliminar);
        }
    }
}
