using Microsoft.AspNetCore.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class MesasController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult Mesas() 
        {
            return View();
        }
    }
}

