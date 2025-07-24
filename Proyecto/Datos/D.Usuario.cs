using System;
using System.Data;


namespace Datos2
{ 
public class Usuario
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public char Sexo { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public int IdRol { get; set; }
    public int IdTipoDoc { get; set; }
    public int NroDoc { get; set; }
    public int Cuil { get; set; }
    public int IdLocalidad { get; set; }
    public string Calle { get; set; }
    public int Nro { get; set; }
    public int Piso { get; set; }
    public int Depto { get; set; }
    public int Telefono { get; set; }
    public string Correo { get; set; }
    public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}