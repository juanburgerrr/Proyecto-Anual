using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logica;
using Logica.Login;


namespace Proyecto
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


private void btnIniciarSesion_Click(object sender, EventArgs e)
    {
        string usuario = textBox1.Text.Trim();
        string password = textBox2.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // Instancia de la lógica
        LogicaUsuario logica = new LogicaUsuario();
        var resultado = logica.ValidarLogin(usuario, password);

        switch (resultado.Estado)
        {
            case "OK":
                MessageBox.Show("Inicio de sesión exitoso.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //redireccion
                break;

            case "CAMBIO_OBLIGATORIO":
                MessageBox.Show("Debe cambiar su contraseña.", "Cambio obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //redireccion
                break;

            case "VENCIDA":
                MessageBox.Show("Su contraseña ha vencido. Debe actualizarla.", "Contraseña vencida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //redireccion
                break;

            case "ERROR":
            case "ERROR_INTERNO":
            default:
                MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                break;
        }
    }


    private void linkRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RecuperarContraseña recuperar = new RecuperarContraseña();
            recuperar.ShowDialog(); // o .Show() si querés que no bloquee el formulario de Login
        }
    }
}
