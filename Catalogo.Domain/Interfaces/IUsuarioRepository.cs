using Catalogo.Domain.Models;
using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Registrar(Usuario usuario);
    }
}