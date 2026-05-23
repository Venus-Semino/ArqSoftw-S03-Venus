using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Ruta y registro para la base de datos de películas (Catálogo)
var jsonPath = Path.Combine(builder.Environment.ContentRootPath, "data", "items.json");
builder.Services.AddSingleton<IItemRepository>(new JsonItemRepository(jsonPath));

// 2. Ruta y registro para la base de datos de usuarios
var usersJsonPath = Path.Combine(builder.Environment.ContentRootPath, "data", "usuarios.json");
builder.Services.AddSingleton<IUsuarioRepository>(new JsonUsuarioRepository(usersJsonPath));

// 3. Registrar el servicio de la capa de Aplicación
builder.Services.AddScoped<ItemService>();

builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();