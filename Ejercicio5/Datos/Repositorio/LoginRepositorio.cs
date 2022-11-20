using Dapper;
using Datos.Interfaces;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos.Repositorio
{
    public class LoginRepositorio : ILoginRepositorio
    {
        private string CadenaConexon;

        public LoginRepositorio(string _cadenaConexion)
        {
            CadenaConexon = _cadenaConexion;
        }

        private MySqlConnection Conexion()
        {
            return new MySqlConnection(CadenaConexon);
        }

        public async Task<bool> ValidarUsuario(Login login)
        {
            bool valido = false;
            try
            {
                using MySqlConnection conexion = Conexion();
                await conexion.OpenAsync();
                string sql = "SELECT 1 FROM usuario WHERE Codigo = @Codigo AND Contraseña = @Contraseña;";
                valido = await conexion.ExecuteScalarAsync<bool>(sql, new { login.Codigo, login.Contraseña });
            }
            catch (Exception ex)
            {
            }
            return valido;
        }

    }
}
