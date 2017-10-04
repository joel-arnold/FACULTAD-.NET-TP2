using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace UI.Escritorio
{
    public partial class FormularioLogin : Form
    {
        public FormularioLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usr = existeUsuario(this.txtUsuario.Text, this.txtContraseña.Text);
            if (usr != null)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.limpiaCampos();
            }

        }

        private void lnkOlvidePass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Metodo aun no desarrollado. Sepa ser paciente, muchas gracias", "Olvidé mi contraseña",
        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }

        private Usuario existeUsuario(string user, string pass)
        {
            Usuario usr;
            LogicaUsuario lu = new LogicaUsuario();
            usr = lu.existeUsuario(user, pass);
            return usr;
        }

        private void limpiaCampos()
        {
            this.txtUsuario.Text = "";
            this.txtContraseña.Text = "";
            this.txtUsuario.Focus();
        }
    }
}
