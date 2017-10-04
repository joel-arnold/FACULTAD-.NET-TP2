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
    public partial class General : Form
    {

        public General(string Tipo)                                         //INCOMPLETO
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            switch (Tipo)
            {
                case "tUsuarios":

                    dgvUsuarios.Columns.Clear();
                    DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                    colId.Name = "Id";
                    colId.HeaderText = "ID";
                    colId.DataPropertyName = "ID";
                    colId.DisplayIndex = 0;
                    colId.Width = 30;
                    dgvUsuarios.Columns.Add(colId);
                    DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
                    colNombre.Name = "Nombre";
                    colNombre.HeaderText = "Nombre";
                    colNombre.DataPropertyName = "Nombre";
                    colNombre.DisplayIndex = 1;
                    dgvUsuarios.Columns.Add(colNombre);
                    DataGridViewTextBoxColumn colApellido = new DataGridViewTextBoxColumn();
                    colApellido.Name = "Apellido";
                    colApellido.HeaderText = "Apellido";
                    colApellido.DataPropertyName = "Apellido";
                    colApellido.DisplayIndex = 2;
                    dgvUsuarios.Columns.Add(colApellido);
                    DataGridViewTextBoxColumn colUsuario = new DataGridViewTextBoxColumn();
                    colUsuario.Name = "Usuario";
                    colUsuario.HeaderText = "Usuario";
                    colUsuario.DataPropertyName = "NombreUsuario";
                    colUsuario.DisplayIndex = 3;
                    dgvUsuarios.Columns.Add(colUsuario);
                    DataGridViewTextBoxColumn colEmail = new DataGridViewTextBoxColumn();
                    colEmail.Name = "Email";
                    colEmail.HeaderText = "Email";
                    colEmail.DataPropertyName = "Email";
                    colEmail.DisplayIndex = 4;
                    dgvUsuarios.Columns.Add(colEmail);
                    DataGridViewCheckBoxColumn colHabilitado = new DataGridViewCheckBoxColumn();
                    colHabilitado.Name = "Habilitado";
                    colHabilitado.HeaderText = "Habilitado";
                    colHabilitado.DataPropertyName = "Habilitado";
                    colHabilitado.DisplayIndex = 5;
                    colHabilitado.Width = 60;
                    dgvUsuarios.Columns.Add(colHabilitado);

                    this.Text = "Usuarios";
                    Listar(Tipo);
                    break;

                case "tPlanes":
                    //falta desarrollo

                    this.Text = "Planes";
                    Listar(Tipo);
                    break;

                case "tEspecialidades":

                    dgvUsuarios.Columns.Clear();
                    DataGridViewTextBoxColumn colIdd = new DataGridViewTextBoxColumn();
                    colIdd.Name = "Id";
                    colIdd.HeaderText = "ID";
                    colIdd.DataPropertyName = "ID";
                    colIdd.DisplayIndex = 0;
                    colIdd.Width = 30;
                    dgvUsuarios.Columns.Add(colIdd);
                    DataGridViewTextBoxColumn colDescripcion = new DataGridViewTextBoxColumn();
                    colDescripcion.Name = "Descripcion";
                    colDescripcion.HeaderText = "Descripción";
                    colDescripcion.DataPropertyName = "Descripcion";
                    colDescripcion.DisplayIndex = 1;
                    colDescripcion.Width = 150;
                    dgvUsuarios.Columns.Add(colDescripcion);

                    this.Text = "Especialidades";
                    Listar(Tipo);
                    break;
            }
        }

        public General()
        {
            
        }

        public void Listar(String Tipo)                                     //COMPLETO
        {
            switch (Tipo)
            {
                case "tUsuarios":
                    LogicaUsuario lu = new LogicaUsuario();
                    dgvUsuarios.DataSource = lu.TraerTodos();
                    break;
                case "tPlanes":
                    LogicaPlan lp = new LogicaPlan();
                    dgvUsuarios.DataSource = lp.TraerTodos();
                    break;
                case "tEspecialidades":
                    LogicaEspecialidad le = new LogicaEspecialidad();
                    dgvUsuarios.DataSource = le.TraerTodos();
                    break;
            }
            /* LogicaUsuario ul = new LogicaUsuario();
             this.dgvUsuarios.DataSource = ul.TraerTodos();
             this.dgvUsuarios.ReadOnly = true;
             //dgvUsuarios.Columns["Estado"].Visible = false;
             //dgvUsuarios.Columns["Privilegio"].Visible = false;
             this.dgvUsuarios.AutoGenerateColumns = false;
             this.dgvUsuarios.AllowUserToAddRows = false;
             this.dgvUsuarios.AllowUserToDeleteRows = false;*/
        }

        private void btnActualizar_Click(object sender, EventArgs e)        //COMPLETO
        {
            switch (this.Text)
            {
                case "Usuarios":
                    Listar("tUsuarios");
                    break;
                case "Planes":
                    Listar("tPlanes");
                    break;
                case "Especialidades":
                    Listar("tEspecialidades");
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ESTO CREA UNA GRILLA PARA ALTAS (BOTONCITO +)
        private void tsbNuevo_Click(object sender, EventArgs e)             //INCOMPLETO
        {
            switch (this.Text)
            {
                case "Usuarios":
                    FormularioUsuario aBMusuario = new FormularioUsuario(FormularioAplicacion.ModosFormulario.Alta);
                    aBMusuario.ShowDialog();
                    Listar("tUsuarios");
                    break;
                case "Planes":
                    FormularioPlan aBMplan = new FormularioPlan(FormularioAplicacion.ModosFormulario.Alta);
                    aBMplan.ShowDialog();
                    Listar("tPlanes");
                    break;
                case "Especialidades":
                    //falta desarrollo y crear formulario
                    Listar("tEspecialidades");
                    break;
            }
        }

        // ESTO CREA UNA GRILLA PARA MODIFICACIONES                         //INCOMPLETO
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvUsuarios.SelectedRows.Count != 0)
            {
                switch (this.Text)
                {
                    case "Usuarios":
                        int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioUsuario formABM = new FormularioUsuario(ID, FormularioAplicacion.ModosFormulario.Modificacion);
                        formABM.ShowDialog();
                        Listar("tUsuarios");
                        break;
                    case "Planes":
                        //falta desarrollo y crear formulario
                        Listar("tPlanes");
                        break;
                    case "Especialidades":
                        //falta desarrollo y crear formulario
                        Listar("tEspecialidades");
                        break;
                }
            }
        }

        // ESTO CREA UNA GRILLA PARA BAJAS (BOTONCITO X)                    //INCOMPLETO
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
          if (this.dgvUsuarios.SelectedRows.Count != 0)
            {
                switch (this.Text)
                {
                    case "Usuarios":
                        int ID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioUsuario formABM = new FormularioUsuario(ID, FormularioAplicacion.ModosFormulario.Baja);
                        formABM.ShowDialog();
                        Listar("tUsuarios");
                        break;
                    case "Planes":
                        //falta desarrollo y crear formulario
                        Listar("tPlanes");
                        break;
                    case "Especialidades":
                        //falta desarrollo y crear formulario
                        Listar("tEspecialidades");
                        break;
                }

            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}