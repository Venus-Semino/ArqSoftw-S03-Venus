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
        public IActionResult Registro(Usuario usuario)
        {
            // Forzamos la remoción del ID del estado de validación
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                _usuarioRepo.Registrar(usuario);
                // Al registrar con éxito, te manda directo al catálogo
                return RedirectToAction("Index", "Catalogo");
            }

            // Si llega aquí, el asp-validation-summary te dirá exactamente qué campo falló
            return View(usuario);
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