using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos; 
using Datos2; 

namespace Proyecto
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            btnRegistrar.Click += btnRegistrar_Click;
            this.Load += Register_Load;
        }

        private void Register_Load(object sender, EventArgs e)
        {
            CargarComboboxes();
        }

        private void CargarComboboxes()
        {
            try
            {
                // Cargar datos para cmbSexo
                cmbSexo.Items.AddRange(new object[] { 'M', 'F', 'O' });

                // Cargar datos para cmbRol (ejemplo)
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "Id";
                cmbRol.DataSource = new List<dynamic>
                {
                    new { Id = 1, Nombre = "Administrador" },
                    new { Id = 2, Nombre = "Usuario" }
                };

                // Cargar datos para cmbTipoDoc (ejemplo)
                cmbTipoDoc.DisplayMember = "Descripcion";
                cmbTipoDoc.ValueMember = "Id";
                cmbTipoDoc.DataSource = new List<dynamic>
                {
                    new { Id = 1, Descripcion = "DNI" },
                    new { Id = 2, Descripcion = "Pasaporte" }
                };

                // Cargar datos para cmbLocalidad (ejemplo)
                cmbLocalidad.DisplayMember = "Nombre";
                cmbLocalidad.ValueMember = "Id";
                cmbLocalidad.DataSource = new List<dynamic>
                {
                    new { Id = 1, Nombre = "Buenos Aires" },
                    new { Id = 2, Nombre = "Córdoba" }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar comboboxes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario
                {
                    Nombre = txtNombre.Text, 
                    Apellido = txtApellido.Text,
                    Sexo = Convert.ToChar(cmbSexo.SelectedItem),
                    FechaNacimiento = dtpFechaNacimiento.Value,
                    IdRol = Convert.ToInt32(cmbRol.SelectedValue),
                    IdTipoDoc = Convert.ToInt32(cmbTipoDoc.SelectedValue),
                    NroDoc = int.Parse(txtDocumento.Text),
                    Cuil = int.Parse(txtCuil.Text),
                    IdLocalidad = Convert.ToInt32(cmbLocalidad.SelectedValue),
                    Calle = txtCalle.Text,
                    Nro = int.Parse(txtNumero.Text),
                    Piso = int.Parse(txtPiso.Text),
                    Depto = int.Parse(txtDepto.Text),
                    Telefono = int.Parse(txtTelefono.Text),
                    Correo = txtCorreo.Text,
                    NombreUsuario = txtUsuario.Text,
                    Contrasena = txtContrasena.Text
                };

                UsuarioDatos registro = new UsuarioDatos();
                bool registrado = registro.RegistrarUsuario(usuario);

                if (registrado)
                {
                    MessageBox.Show("Usuario registrado correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo registrar el usuario.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
