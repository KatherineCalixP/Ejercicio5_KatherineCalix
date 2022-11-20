
using Blazor.Interfaces;
using Datos.Interfaces;
using Datos.Repositorio;
using Modelos;
namespace Blazor.Servicios
{
    public class LoginServicios : ILoginServicios
    {
        private readonly Config _configuracion;
        private ILoginRepositorio loginRepositorio;

        public LoginServicios(Config config)
        {
            _configuracion = config;
            loginRepositorio = new LoginRepositorio(config.CadenaConexion);
        }


        public async Task<bool> ValidarUsuario(Login login)
        {
            return await loginRepositorio.ValidarUsuario(login);
        }
    }
}
