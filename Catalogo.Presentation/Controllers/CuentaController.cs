using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoApp.Presentation.Controllers
{
    public class CuentaController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public CuentaController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(string email, string password)
        {
            // Validación manual súper sencilla e infalible
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var nuevoUsuario = new Usuario
                {
                    Email = email,
                    Password = password
                };

                _usuarioRepo.Registrar(nuevoUsuario);
                return RedirectToAction("Index", "Catalogo");
            }

            ViewBag.Error = "Por favor llena todos los campos.";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var usuario = _usuarioRepo.ObtenerPorEmailYPassword(email, password);

            if (usuario != null)
            {
                return RedirectToAction("Index", "Catalogo");
            }

            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }
    }
}