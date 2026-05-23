using CatalogoApp.Domain.Models;

namespace CatalogoApp.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        void Registrar(Usuario usuario);
        // Nueva regla:
        Usuario ObtenerPorEmailYPassword(string email, string password);
    }
}