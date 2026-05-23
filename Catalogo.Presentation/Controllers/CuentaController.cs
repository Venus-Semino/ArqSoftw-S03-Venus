using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using System.Collections.Generic;

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
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                var nuevoUsuario = new Usuario
                {
                    Email = email,
                    Password = password
                };

                _usuarioRepo.Registrar(nuevoUsuario);
                return RedirectToAction("Login");
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
        public async Task<IActionResult> Login(string email, string password)
        {
            var usuario = _usuarioRepo.ObtenerPorEmailYPassword(email, password);

            if (usuario != null)
            {
                // Crear los datos de sesión para la cookie de ASP.NET
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, usuario.Email) };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("Index", "Catalogo");
            }

            ViewBag.Error = "Correo o contraseña incorrectos.";
            return View();
        }

        // Nueva acción para limpiar la cookie de sesión
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}