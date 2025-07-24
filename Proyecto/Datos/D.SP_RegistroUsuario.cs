using Microsoft.Data.SqlClient;
using System.Data;
using Datos2;

namespace Datos
{
    public class UsuarioDatos
    {
        private readonly Conexion.Conexion conexion = new Conexion.Conexion();

        public bool RegistrarUsuario(Usuario usuario)
        {
            using (SqlConnection con = conexion.AbrirConexion())
            {
                using (SqlCommand cmd = new SqlCommand("SP_RegistroUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", usuario.Apellido);
                    cmd.Parameters.AddWithValue("@sexo", usuario.Sexo);
                    cmd.Parameters.AddWithValue("@fecha_nac", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@id_rol", usuario.IdRol);
                    cmd.Parameters.AddWithValue("@id_tipo_doc", usuario.IdTipoDoc);
                    cmd.Parameters.AddWithValue("@nrodoc", usuario.NroDoc);
                    cmd.Parameters.AddWithValue("@cuil", usuario.Cuil);
                    cmd.Parameters.AddWithValue("@id_localidad", usuario.IdLocalidad);
                    cmd.Parameters.AddWithValue("@calle", usuario.Calle);
                    cmd.Parameters.AddWithValue("@nro", usuario.Nro);
                    cmd.Parameters.AddWithValue("@piso", usuario.Piso);
                    cmd.Parameters.AddWithValue("@depto", usuario.Depto);
                    cmd.Parameters.AddWithValue("@telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@usuario", usuario.NombreUsuario);

                    SqlParameter registrado = new SqlParameter("@registrado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(registrado);

                    cmd.ExecuteNonQuery();

                    return Convert.ToBoolean(registrado.Value);
                }
            }
        }
    }
}
