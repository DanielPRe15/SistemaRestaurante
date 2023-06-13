using Microsoft.AspNetCore.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }



    }
}
