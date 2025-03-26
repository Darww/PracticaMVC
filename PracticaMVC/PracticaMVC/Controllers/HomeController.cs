using Microsoft.AspNetCore.Mvc;
using PracticaMVC.Models;
using System.Diagnostics;

namespace PracticaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // MÉTODO AUTENTICAR AÑADIDO
        public IActionResult Autenticar()
        {
            ViewData["ErrorMessage"] = "";
            return View();
        }


        public IActionResult Index()
        {   //obtengo las variables de sesion
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            var tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            var nombreUsuario = HttpContext.Session.GetString("Nombre");

            if (usuarioId == null)
            {
                // Si no existe la sesión, redirigir al login
                return RedirectToAction("Autenticar", "Home");
            }

            //retorno de informacion a la vista por viewbag y viewdata
            ViewBag.nombre = nombreUsuario;
            ViewData["tipoUsuario"] = tipoUsuario;  

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
