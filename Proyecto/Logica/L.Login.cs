using Sesion.Hash;
using Datos;


namespace Logica.Login
{
    public class LogicaUsuario
    {
        private readonly SP_ValidarLogin sp = new SP_ValidarLogin();

        public (string Estado, int? IdUsuario) ValidarLogin(string usuario, string password)
        {
            string passwordHash = Encrypt.GetSHA256(password);
            return sp.ValidarLogin(usuario, passwordHash);
        }
    }

}
