using Microsoft.AspNetCore.Mvc;
using SistemaRestaurante.Models;
using System.Runtime.Intrinsics.Arm;

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


        [HttpGet]
        public IActionResult Editar(int idPedido)
        {
           Pedidos pedidos = bdv.ObtnerPorId(idPedido);
            return View(pedidos);
        }
        [HttpPost]
        public IActionResult Editar(Pedidos pedidos)
        {
            int nroRegistros = bdv.Actualizar(pedidos);
            if (nroRegistros == 1)
            {
                ViewBag.mensaje = "Plato actualizado correctamente";
            }
            else
            {
                ViewBag.mensaje = "Plato NO actualizado";
            }

            return View(pedidos);
        }

    }
}
