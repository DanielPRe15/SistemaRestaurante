using Microsoft.AspNetCore.Mvc;
using SistemaRestaurante.Models;

namespace SistemaRestaurante.Controllers
{
    public class VentasController : Controller
    {

        BDVentas bdv = new BDVentas();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ventas ()
        {
            List<Pedidos> listaPedidos = bdv.ObtenerTodos();
            return View(listaPedidos);
        }

    }
}
