using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Escritorio
{
    public partial class FormularioMenu : Form
    {
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

        }

        private void mnuABMCUsuarios_Click(object sender, EventArgs e)
        {
            Usuarios usrs = new Usuarios();
            usrs.Show();

        }
    }
}
