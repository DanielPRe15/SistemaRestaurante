using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.Controllers
{
    public class MesasController : Controller
    {
        BDPedido bdpe = new BDPedido();
        BDPlatos bdp = new BDPlatos();

        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult Mesas() 
        {
            return View();
        }

        [HttpGet]
        public IActionResult CrearMesa1()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa1(string nombre, int idPlato, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa2()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa2(string nombre, int idPlato, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa3()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa3(string nombre, int idPlato, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa4()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa4(string nombre, int idPlato, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa5()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa5(string nombre, int idPlato, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa6()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa6(string nombre, int idPlato, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            return View();
        }
    }
}

