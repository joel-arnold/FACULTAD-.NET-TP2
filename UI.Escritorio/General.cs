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
        public Usuario usuarioActual;

        public General(string Tipo, Usuario usuario)                                         
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            this.usuarioActual = usuario;
            switch (Tipo)
            {
                case "tUsuarios":

                    dgvUsuarios.Columns.Clear();
                    DataGridViewTextBoxColumn ucolId = new DataGridViewTextBoxColumn();
                    ucolId.Name = "Id";
                    ucolId.HeaderText = "ID";
                    ucolId.DataPropertyName = "ID";
                    ucolId.DisplayIndex = 0;
                    ucolId.Width = 30;
                    dgvUsuarios.Columns.Add(ucolId);
                    DataGridViewTextBoxColumn ucolNombre = new DataGridViewTextBoxColumn();
                    ucolNombre.Name = "Nombre";
                    ucolNombre.HeaderText = "Nombre";
                    ucolNombre.DataPropertyName = "Nombre";
                    ucolNombre.DisplayIndex = 1;
                    dgvUsuarios.Columns.Add(ucolNombre);
                    DataGridViewTextBoxColumn ucolApellido = new DataGridViewTextBoxColumn();
                    ucolApellido.Name = "Apellido";
                    ucolApellido.HeaderText = "Apellido";
                    ucolApellido.DataPropertyName = "Apellido";
                    ucolApellido.DisplayIndex = 2;
                    dgvUsuarios.Columns.Add(ucolApellido);
                    DataGridViewTextBoxColumn ucolUsuario = new DataGridViewTextBoxColumn();
                    ucolUsuario.Name = "Usuario";
                    ucolUsuario.HeaderText = "Usuario";
                    ucolUsuario.DataPropertyName = "NombreUsuario";
                    ucolUsuario.DisplayIndex = 3;
                    dgvUsuarios.Columns.Add(ucolUsuario);
                    DataGridViewTextBoxColumn ucolEmail = new DataGridViewTextBoxColumn();
                    ucolEmail.Name = "Email";
                    ucolEmail.HeaderText = "Email";
                    ucolEmail.DataPropertyName = "Email";
                    ucolEmail.DisplayIndex = 4;
                    dgvUsuarios.Columns.Add(ucolEmail);
                    DataGridViewCheckBoxColumn ucolHabilitado = new DataGridViewCheckBoxColumn();
                    ucolHabilitado.Name = "Habilitado";
                    ucolHabilitado.HeaderText = "Habilitado";
                    ucolHabilitado.DataPropertyName = "Habilitado";
                    ucolHabilitado.DisplayIndex = 5;
                    ucolHabilitado.Width = 60;
                    dgvUsuarios.Columns.Add(ucolHabilitado);
                    DataGridViewTextBoxColumn ucolPrivilegio = new DataGridViewTextBoxColumn();
                    ucolPrivilegio.Name = "Privilegio";
                    ucolPrivilegio.HeaderText = "Privilegio";
                    ucolPrivilegio.DataPropertyName = "Privilegio";
                    ucolPrivilegio.DisplayIndex = 6;
                    ucolPrivilegio.Width = 80;
                    dgvUsuarios.Columns.Add(ucolPrivilegio);

                    this.Text = "Usuarios";
                    Listar(Tipo);
                    break;

                case "tPlanes":

                    dgvUsuarios.Columns.Clear();
                    DataGridViewTextBoxColumn pcolId = new DataGridViewTextBoxColumn();
                    pcolId.Name = "Id";
                    pcolId.HeaderText = "ID";
                    pcolId.DataPropertyName = "ID";
                    pcolId.DisplayIndex = 0;
                    pcolId.Width = 30;
                    dgvUsuarios.Columns.Add(pcolId);
                    DataGridViewTextBoxColumn pcolDescripcion = new DataGridViewTextBoxColumn();
                    pcolDescripcion.Name = "Descripcion";
                    pcolDescripcion.HeaderText = "Descripción";
                    pcolDescripcion.DataPropertyName = "Descripcion";
                    pcolDescripcion.DisplayIndex = 1;
                    pcolDescripcion.Width = 70;
                    dgvUsuarios.Columns.Add(pcolDescripcion);
                    DataGridViewTextBoxColumn pcolIdEspecialidad = new DataGridViewTextBoxColumn();     //id o nombre especialidad?
                    pcolIdEspecialidad.Name = "IdEspecialidad";
                    pcolIdEspecialidad.HeaderText = "ID Especialidad";
                    pcolIdEspecialidad.DataPropertyName = "IdEspecialidad";
                    pcolIdEspecialidad.DisplayIndex = 2;
                    pcolIdEspecialidad.Width = 70;
                    dgvUsuarios.Columns.Add(pcolIdEspecialidad);
                    
                    this.Text = "Planes";
                    Listar(Tipo);
                    break;

                case "tEspecialidades":

                    dgvUsuarios.Columns.Clear();
                    DataGridViewTextBoxColumn ecolId = new DataGridViewTextBoxColumn();
                    ecolId.Name = "Id";
                    ecolId.HeaderText = "ID";
                    ecolId.DataPropertyName = "ID";
                    ecolId.DisplayIndex = 0;
                    ecolId.Width = 30;
                    dgvUsuarios.Columns.Add(ecolId);
                    DataGridViewTextBoxColumn ecolDescripcion = new DataGridViewTextBoxColumn();
                    ecolDescripcion.Name = "Descripcion";
                    ecolDescripcion.HeaderText = "Descripción";
                    ecolDescripcion.DataPropertyName = "Descripcion";
                    ecolDescripcion.DisplayIndex = 1;
                    ecolDescripcion.Width = 150;
                    dgvUsuarios.Columns.Add(ecolDescripcion);                    

                    this.Text = "Especialidades";
                    Listar(Tipo);
                    break;

                case "tInscripciones":

                    dgvUsuarios.Columns.Clear();
                    DataGridViewTextBoxColumn icolId = new DataGridViewTextBoxColumn();
                    icolId.Name = "Id";
                    icolId.HeaderText = "ID";
                    icolId.DataPropertyName = "ID";
                    icolId.DisplayIndex = 0;
                    icolId.Width = 30;
                    dgvUsuarios.Columns.Add(icolId);
                    DataGridViewTextBoxColumn icolIdAlumno = new DataGridViewTextBoxColumn();
                    icolIdAlumno.Name = "IdAlumno";
                    icolIdAlumno.HeaderText = "ID Alumno";
                    icolIdAlumno.DataPropertyName = "IdAlumno";
                    icolIdAlumno.DisplayIndex = 1;
                    icolIdAlumno.Width = 70;
                    dgvUsuarios.Columns.Add(icolIdAlumno);
                    DataGridViewTextBoxColumn icolIdCurso = new DataGridViewTextBoxColumn();
                    icolIdCurso.Name = "IdCurso";
                    icolIdCurso.HeaderText = "ID Curso";
                    icolIdCurso.DataPropertyName = "IdCurso";
                    icolIdCurso.DisplayIndex = 2;
                    icolIdCurso.Width = 70;
                    dgvUsuarios.Columns.Add(icolIdCurso);
                    //DataGridViewTextBoxColumn icolAnioCalendario = new DataGridViewTextBoxColumn();
                    //icolAnioCalendario.Name = "AnioCalendario";
                    //icolAnioCalendario.HeaderText = "Año Calendario";
                    //icolAnioCalendario.DataPropertyName = "AnioCalendario";
                    //icolAnioCalendario.DisplayIndex = 3;
                    //icolAnioCalendario.Width = 70;
                    //dgvUsuarios.Columns.Add(icolAnioCalendario);
                    //DataGridViewTextBoxColumn icolCupo = new DataGridViewTextBoxColumn();
                    //icolCupo.Name = "Cupo";
                    //icolCupo.HeaderText = "Cupo";
                    //icolCupo.DataPropertyName = "Cupo";
                    //icolCupo.DisplayIndex = 4;
                    //icolCupo.Width = 30;
                    //dgvUsuarios.Columns.Add(icolCupo);

                    this.Text = "Inscripciones";
                    Listar(Tipo);
                    this.usuarioActual = usuario;
                    break;
            }
        }

        public General()
        {
            
        }

        public void Listar(String Tipo)                                     //INCOMPLETO (TRAER COLUMNA PRIVILEGIO DE USUARIOS)
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
                case "tInscripciones":
                    LogicaInscripcion li = new LogicaInscripcion();
                    dgvUsuarios.DataSource = li.TraerTodosPorIdPersona(this.usuarioActual.IDPersona);
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
                case "tInscripciones":
                    Listar("tInscripciones");
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ESTO CREA UNA GRILLA PARA ALTAS (BOTONCITO +)
        private void tsbNuevo_Click(object sender, EventArgs e)             //COMPLETO
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
                    FormularioEspecialidad aBMespecialidad = new FormularioEspecialidad(FormularioAplicacion.ModosFormulario.Alta);
                    aBMespecialidad.ShowDialog();
                    Listar("tEspecialidades");
                    break;
                case "Inscripciones":
                    FormularioInscripcion aBMinscripcion = new FormularioInscripcion(FormularioAplicacion.ModosFormulario.Alta, this.usuarioActual);
                    aBMinscripcion.ShowDialog();
                    Listar("tInscripciones");
                    break;
            }
        }

        // ESTO CREA UNA GRILLA PARA MODIFICACIONES                         
        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvUsuarios.SelectedRows.Count != 0)
            {
                switch (this.Text)
                {
                    case "Usuarios":
                        int uID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioUsuario aBMusuario = new FormularioUsuario(uID, FormularioAplicacion.ModosFormulario.Modificacion);
                        aBMusuario.ShowDialog();
                        Listar("tUsuarios");
                        break;
                    case "Planes":
                        int pID = ((Entidades.Plan)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioPlan aBMplan = new FormularioPlan(pID, FormularioAplicacion.ModosFormulario.Modificacion);
                        aBMplan.ShowDialog();
                        Listar("tPlanes");
                        break;
                    case "Especialidades":
                        int eID = ((Entidades.Especialidad)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioEspecialidad aBMespecialidad = new FormularioEspecialidad(eID, FormularioAplicacion.ModosFormulario.Modificacion);
                        aBMespecialidad.ShowDialog();
                        Listar("tEspecialidades");
                        break;
                    case "Inscripciones":
                        int iID = ((Entidades.AlumnoInscripciones)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioInscripcion aBMinscripcion = new FormularioInscripcion(FormularioAplicacion.ModosFormulario.Modificacion, this.usuarioActual);
                        aBMinscripcion.ShowDialog();
                        Listar("tInscripciones");
                        break;
                }
            }
        }

        // ESTO CREA UNA GRILLA PARA BAJAS (BOTONCITO X)                    
        private void tsbEliminar_Click(object sender, EventArgs e)
        {
          if (this.dgvUsuarios.SelectedRows.Count != 0)
            {
                switch (this.Text)
                {
                    case "Usuarios":
                        int uID = ((Entidades.Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioUsuario aABMusuario = new FormularioUsuario(uID, FormularioAplicacion.ModosFormulario.Baja);
                        aABMusuario.ShowDialog();
                        Listar("tUsuarios");
                        break;
                    case "Planes":
                        int pID = ((Entidades.Plan)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioPlan aBMplan = new FormularioPlan(pID, FormularioAplicacion.ModosFormulario.Baja);
                        aBMplan.ShowDialog();
                        Listar("tPlanes");
                        break;
                    case "Especialidades":
                        int eID = ((Entidades.Especialidad)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioEspecialidad aBMespecialidad = new FormularioEspecialidad(eID, FormularioAplicacion.ModosFormulario.Baja);
                        aBMespecialidad.ShowDialog();
                        Listar("tEspecialidades");
                        break;
                    case "Inscripciones":
                        int iID = ((Entidades.AlumnoInscripciones)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioInscripcion aBMinscripcion = new FormularioInscripcion(FormularioAplicacion.ModosFormulario.Baja, this.usuarioActual);
                        aBMinscripcion.ShowDialog();
                        Listar("tInscripciones");
                        break;
                }

            }
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}