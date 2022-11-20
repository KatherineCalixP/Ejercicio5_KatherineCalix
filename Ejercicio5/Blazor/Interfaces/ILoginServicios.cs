using Modelos;

namespace Blazor.Interfaces
{
    public interface ILoginServicios
    {
        Task<bool> ValidarUsuario(Login login);
    }
}
