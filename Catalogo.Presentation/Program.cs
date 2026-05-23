using CatalogoApp.Application.Services;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Ruta del archivo JSON — se guarda en la carpeta "data" del proyectovar jsonPath = Path.Combine(

var jsonPath = Path.Combine(builder.Environment.ContentRootPath, "data", "items.json");
// Registrar el repositorio JSON como implementación de IItemRepositorybuilder.Services.AddSingleton<IItemRepository>(

builder.Services.AddSingleton<IItemRepository>(new JsonItemRepository(jsonPath));

// Ruta para la base de datos de usuarios JSON
var usersJsonPath = Path.Combine(builder.Environment.ContentRootPath, "data", "usuarios.json");
builder.Services.AddSingleton<IUsuarioRepository>(new JsonUsuarioRepository(usersJsonPath));

// Registrar el servicio de Applicationbuilder.Services.AddScoped<ItemService>();
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