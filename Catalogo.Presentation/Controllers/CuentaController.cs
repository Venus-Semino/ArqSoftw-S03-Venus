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
            // Le decimos a ASP.NET que ignore el Id porque nosotros lo generamos
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                _usuarioRepo.Registrar(usuario);
                return RedirectToAction("Index", "Catalogo");
            }
            return View(usuario);
        }

        // --- NUEVAS ACCIONES PARA EL INICIO DE SESIÓN ---

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
                // Si lo encuentra en el .json, lo deja pasar al catálogo
                return RedirectToAction("Index", "Catalogo");
            }

            // Si se equivoca, le mostramos un error
            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }
    }
}