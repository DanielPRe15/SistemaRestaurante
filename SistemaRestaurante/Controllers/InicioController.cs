using Microsoft.AspNetCore.Mvc;

namespace SistemaRestaurante.Controllers
{
    public class InicioController : Controller
    {
        public IActionResult Inicio()
        {
            ViewData["usuario"] = Request.Cookies["user"];
            return View();
        }



    }
}
