using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies; // <-- Asegúrate de tener este using

var builder = WebApplication.CreateBuilder(args);

// 1. Registro de Repositorios y Servicios
var jsonPath = Path.Combine(builder.Environment.ContentRootPath, "data", "items.json");
builder.Services.AddSingleton<IItemRepository>(new JsonItemRepository(jsonPath));

var usersJsonPath = Path.Combine(builder.Environment.ContentRootPath, "data", "usuarios.json");
builder.Services.AddSingleton<IUsuarioRepository>(new JsonUsuarioRepository(usersJsonPath));

builder.Services.AddScoped<ItemService>();
builder.Services.AddControllersWithViews();

// 2. Configurar la autenticación nativa por Cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Cuenta/Login"; // Ruta de redirección por defecto
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// IMPORTANTE: UseAuthentication siempre debe ir antes de UseAuthorization
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();