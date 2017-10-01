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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            LogicaUsuario ul = new LogicaUsuario();
            this.dgvUsuarios.DataSource = ul.TraerTodos();
            this.dgvUsuarios.ReadOnly = true;
            dgvUsuarios.Columns["Estado"].Visible = false;
            dgvUsuarios.Columns["Privilegio"].Visible = false;
            this.dgvUsuarios.AutoGenerateColumns = false;
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.AllowUserToDeleteRows = false;
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ESTO CREA UNA GRILLA PARA ALTAS (BOTONCITO +)
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            FormularioUsuario formABM = new FormularioUsuario(FormularioAplicacion.ModosFormulario.Alta);
            formABM.ShowDialog();
            this.Listar();
        }

        // ESTO CREA UNA GRILLA PARA MODIFICACIONES
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvUsuarios.SelectedRows.Count != 0)
            {
                int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                FormularioUsuario formABM = new FormularioUsuario(ID, FormularioAplicacion.ModosFormulario.Modificacion);
                formABM.ShowDialog();
                this.Listar();
            }
        }

        // ESTO CREA UNA GRILLA PARA BAJAS (BOTONCITO X)
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
          if (this.dgvUsuarios.SelectedRows.Count != 0)
            {
                int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                FormularioUsuario formABM = new FormularioUsuario(ID, FormularioAplicacion.ModosFormulario.Baja);
                formABM.ShowDialog();
                this.Listar();
            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}