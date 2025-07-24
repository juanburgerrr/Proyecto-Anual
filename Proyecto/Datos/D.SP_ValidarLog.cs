using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Conexion;

namespace Datos
{
    public class SP_ValidarLogin
    {
        private Conexion.Conexion conexion = new Conexion.Conexion();

        public (string Estado, int? IdUsuario) ValidarLogin(string usuario, string password)
        {
            string estado = "ERROR";
            int? idUsuario = null;

            try
            {
                using (SqlCommand comando = new SqlCommand("SP_ValidarLogin", conexion.AbrirConexion()))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@usuario", usuario);
                    comando.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            estado = lector["Estado"]?.ToString() ?? "ERROR";
                            if (estado == "OK")
                                idUsuario = Convert.ToInt32(lector["Id_Usuario"]);
                        }
                    }
                }
            }
            catch
            {
                estado = "ERROR_INTERNO";
            }
            finally
            {
                conexion.CerrarConexion();
            }

            return (estado, idUsuario);
        }
    }

}
