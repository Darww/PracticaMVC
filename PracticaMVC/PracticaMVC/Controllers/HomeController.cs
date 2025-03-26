using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticaMVC.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using PracticaMVC.Servicios;

namespace PracticaMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly equiposDbContext _context;

        public HomeController(ILogger<HomeController> logger, equiposDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Autenticacion]
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

        // MÉTODO AUTENTICAR AÑADIDO
        public IActionResult Autenticar()
        {
            ViewData["ErrorMessage"] = "";
            return View();
        }

        // POST: Procesa el formulario de login 
        [HttpPost]
        public async Task<IActionResult> Autenticar(string txtUsuario, string txtClave)
        {
            var usuario = (from u in _context.Usuarios
                           where u.email == txtUsuario
                           && u.contrasenia == txtClave
                           && u.activo == "S"
                           && u.blogueado == "N"
                           select u).FirstOrDefault();

            if (usuario != null)
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.id_usuario);
                HttpContext.Session.SetString("TipoUsuario", usuario.tipo_usuario);
                HttpContext.Session.SetString("Nombre", usuario.nombre);
                return RedirectToAction("Index", "Home");
            }

            ViewData["ErrorMessage"] = "Error, usuario inválido!!!!";
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

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
