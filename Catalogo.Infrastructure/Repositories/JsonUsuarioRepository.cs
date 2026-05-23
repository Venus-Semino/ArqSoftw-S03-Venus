using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Catalogo.Domain.Models;
using CatalogoApp.Domain.Interfaces;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Infrastructure.Repositories
{
    public class JsonUsuarioRepository : IUsuarioRepository
    {
        private readonly string _filePath;

        public JsonUsuarioRepository(string filePath)
        {
            _filePath = filePath;
            var carpeta = Path.GetDirectoryName(_filePath);
            if (!string.IsNullOrEmpty(carpeta))
                Directory.CreateDirectory(carpeta);
        }

        public void Registrar(Usuario usuario)
        {
            var usuarios = ObtenerTodos();
            usuario.Id = usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1;
            usuarios.Add(usuario);

            var json = JsonSerializer.Serialize(usuarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        private List<Usuario> ObtenerTodos()
        {
            if (!File.Exists(_filePath)) return new List<Usuario>();
            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Usuario>>(json) ?? new List<Usuario>();
        }
    }
}