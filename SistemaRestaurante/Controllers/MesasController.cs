using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.Controllers
{
    public class MesasController : Controller
    {
        BDPedido bdpe = new BDPedido();
        BDPlatos bdp = new BDPlatos();
        BDBebidas bdb = new BDBebidas();

        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult Mesas() 
        {
            return View();
        }


        public IActionResult Listado()
        {
            // Muestra la lista de clientes de la BD
            List<Pedidos> listaPedidos = bdp.ObtenerTodos();
            return View(listaPedidos);
        }




        [HttpGet]
        public IActionResult CrearMesa1()
        {
            List <Platos> platos = bdp.ObtenerTodos();
            List<Bebidas> bebidas = bdb.ObtenerTodos();

            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
             ViewBag.bebidas = new SelectList(bebidas, "IdBe", "NombreBe", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa1(string nombre, int idPlato, int idBebida,int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, idBebida, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            List<Bebidas> bebidas = bdb.ObtenerTodos();
            ViewBag.bebidas = new SelectList(bebidas, "IdBe", "NombreBe", idBebida);

            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa2()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            List<Bebidas> bebidas = bdb.ObtenerTodos();

            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            ViewBag.bebidas = new SelectList(bebidas, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa2(string nombre, int idPlato, int idBebida, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, idBebida, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            List<Bebidas> bebidas = bdb.ObtenerTodos();
            ViewBag.platos = new SelectList(bebidas, "Id", "Nombre", idBebida);

            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa3()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            List<Bebidas> bebidas = bdb.ObtenerTodos();

            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            ViewBag.bebidas = new SelectList(bebidas, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa3(string nombre, int idPlato, int idBebida, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, idBebida, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            List<Bebidas> bebidas = bdb.ObtenerTodos();
            ViewBag.platos = new SelectList(bebidas, "Id", "Nombre", idBebida);

            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa4()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            List<Bebidas> bebidas = bdb.ObtenerTodos();

            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            ViewBag.bebidas = new SelectList(bebidas, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa4(string nombre, int idPlato, int idBebida, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, idBebida, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            List<Bebidas> bebidas = bdb.ObtenerTodos();
            ViewBag.platos = new SelectList(bebidas, "Id", "Nombre", idBebida);

            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa5()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            List<Bebidas> bebidas = bdb.ObtenerTodos();

            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            ViewBag.bebidas = new SelectList(bebidas, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa5(string nombre, int idPlato, int idBebida, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, idBebida, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            List<Bebidas> bebidas = bdb.ObtenerTodos();
            ViewBag.platos = new SelectList(bebidas, "Id", "Nombre", idBebida);

            return View();
        }
        [HttpGet]
        public IActionResult CrearMesa6()
        {
            List<Platos> platos = bdp.ObtenerTodos();
            List<Bebidas> bebidas = bdb.ObtenerTodos();

            ViewBag.platos = new SelectList(platos, "Id", "Nombre", 1);
            ViewBag.bebidas = new SelectList(bebidas, "Id", "Nombre", 1);
            return View();
        }
        [HttpPost]
        public IActionResult CrearMesa6(string nombre, int idPlato, int idBebida, int numeroMesa)
        {
            int nroRegistros = bdpe.Crear(nombre, idPlato, idBebida, numeroMesa);
            ViewBag.mensaje = "Pedido realizado correctamente";
            List<Platos> platos = bdp.ObtenerTodos();
            ViewBag.platos = new SelectList(platos, "Id", "Nombre", idPlato);
            List<Bebidas> bebidas = bdb.ObtenerTodos();
            ViewBag.platos = new SelectList(bebidas, "Id", "Nombre", idBebida);

            return View();
        }
    }
}

