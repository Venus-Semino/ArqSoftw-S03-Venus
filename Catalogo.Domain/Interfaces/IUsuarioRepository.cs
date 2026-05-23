using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Catalogo.Domain.Models;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Registrar(Usuario usuario);
    }
}