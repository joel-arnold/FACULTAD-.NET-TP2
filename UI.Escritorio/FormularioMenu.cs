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
using Negocio;

namespace UI.Escritorio
{
    public partial class FormularioMenu : Form
    {
        Usuario usuarioActual;
        Personas personaActual;

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
                usuarioActual = appLogin.usr;
                LogicaPersona lp = new LogicaPersona();
                personaActual = lp.TraerUno(appLogin.usr.IDPersona);
                MessageBox.Show("Bienvenido " + personaActual.Nombre + " " + personaActual.Apellido, "UTN FRRO",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                switch (personaActual.Tipo)
                {
                case Personas.TipoPersona.Administrativo:
                    mnuInscripcion.Enabled = false;
                    mnuNotas.Enabled = false;
                    break;
                case Personas.TipoPersona.Alumno:
                    mnuABMCEspecialidad.Enabled = false;
                    mnuABMCPlanes.Enabled = false;
                    mnuABMCUsuarios.Enabled = false;
                    mnuNotas.Enabled = false;
                    mnuReportes.Enabled = false;
                    break;
                case Personas.TipoPersona.Profesor:
                    mnuABMCEspecialidad.Enabled = false;
                    mnuABMCPlanes.Enabled = false;
                    mnuABMCUsuarios.Enabled = false;
                    mnuInscripcion.Enabled = false;
                    break;
                }
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

        private void cargarNotasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormularioNotasCursos fnc = new FormularioNotasCursos(this.personaActual);
            fnc.Show();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReportesPersonas rp = new ReportesPersonas();
            rp.Show();
        }
    }
}
