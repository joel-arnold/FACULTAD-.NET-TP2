using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace UI.Escritorio
{
    public partial class FormularioMenu : Form
    {
        Usuario usuarioActual;

        public FormularioMenu()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FormularioMenu_Shown(object sender, EventArgs e)
        {
            FormularioLogin appLogin = new FormularioLogin();
            if (appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
            else
            {
                this.usuarioActual = appLogin.usr;
                MessageBox.Show("Bienvenido usuario " + usuarioActual.NombreUsuario, "UTN FRRO",
       MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void mnuABMCUsuarios_Click(object sender, EventArgs e)
        {
            String Tipo = "tUsuarios";
            mostrarFormulario(Tipo);

        }

        private void mnuABMCEspecialidad_Click(object sender, EventArgs e)
        {
            String Tipo = "tEspecialidades";
            mostrarFormulario(Tipo);
        }

        private void mnuABMCPlanes_Click(object sender, EventArgs e)
        {
            String Tipo = "tPlanes";
            mostrarFormulario(Tipo);
        }

        private void mnuInscripcion_Click(object sender, EventArgs e)
        {
            String Tipo = "tInscripciones";
            mostrarFormulario(Tipo);
        }

        private void mostrarFormulario(String Tipo)
        {
            General gral = new General(Tipo, this.usuarioActual);
            gral.Show();
        }
    }
}
