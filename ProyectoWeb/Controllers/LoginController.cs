using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Models; // Reemplaza con el namespace de tu proyecto
using System.Linq;

namespace ProyectoWeb.Controllers
{
    public class LoginController : Controller
    {
        private readonly DbventasContext _context;

        public LoginController(DbventasContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Index()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Index(string correo, string clave)
        {
            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(clave))
            {
                ViewBag.Error = "Ingrese todos los campos.";
                return View();
            }

            // Buscar el usuario en la base de datos
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == correo && u.Clave == clave);

            if (usuario == null || !usuario.EsActivo.HasValue || !usuario.EsActivo.Value)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos.";
                return View();
            }

            // Guardar información básica del usuario en la sesión
            HttpContext.Session.SetString("IdUsuario", usuario.IdUsuario.ToString());
            HttpContext.Session.SetString("NombreUsuario", usuario.Nombre);

            // Redirigir al Dashboard
            return RedirectToAction("Index", "Dashboard");
        }

        // GET: Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

