using Catalogo.Domain.Models;
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
            if (ModelState.IsValid)
            {
                _usuarioRepo.Registrar(usuario);
                // Redirigir al catálogo después de registrarse con éxito
                return RedirectToAction("Index", "Catalogo");
            }
            return View(usuario);
        }
    }
}