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
        private int idCursoActual;

        public int IdCursoActual
        {
            get
            {
                return idCursoActual;
            }
            set
            {
                idCursoActual= value;
            }
        }

        // Solo para notas
        public General(int curso)
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
            LogicaInscripcion logins = new LogicaInscripcion();
            IdCursoActual = curso;

            dgvUsuarios.Columns.Clear();
            DataGridViewTextBoxColumn ncolAlumno = new DataGridViewTextBoxColumn();
            ncolAlumno.Name = "Alumno";
            ncolAlumno.HeaderText = "Alumno";
            ncolAlumno.DataPropertyName = "Alumno";
            ncolAlumno.DisplayIndex = 0;
            ncolAlumno.Width = 140;
            dgvUsuarios.Columns.Add(ncolAlumno);
            DataGridViewTextBoxColumn ncolNota = new DataGridViewTextBoxColumn();
            ncolNota.Name = "Nota";
            ncolNota.HeaderText = "Nota";
            ncolNota.DataPropertyName = "Nota";
            ncolNota.DisplayIndex = 1;
            ncolNota.Width = 70;
            dgvUsuarios.Columns.Add(ncolNota);
            DataGridViewTextBoxColumn ncolCondicion = new DataGridViewTextBoxColumn();
            ncolCondicion.Name = "Condicion";
            ncolCondicion.HeaderText = "Condicion";
            ncolCondicion.DataPropertyName = "Condicion";
            ncolCondicion.DisplayIndex = 2;
            ncolCondicion.Width = 70;
            dgvUsuarios.Columns.Add(ncolCondicion);

            this.Text = "Notas";
            Listar("tNotas");
            tsbNuevo.Enabled = false;
            tsbEliminar.Enabled = false;
        }

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
                    DataGridViewTextBoxColumn icolMateria = new DataGridViewTextBoxColumn();
                    icolMateria.Name = "Materia";
                    icolMateria.HeaderText = "Materia";
                    icolMateria.DataPropertyName = "Materia";
                    icolMateria.DisplayIndex = 0;
                    icolMateria.Width = 70;
                    dgvUsuarios.Columns.Add(icolMateria);
                    DataGridViewTextBoxColumn icolComision = new DataGridViewTextBoxColumn();
                    icolComision.Name = "Comision";
                    icolComision.HeaderText = "Comision";
                    icolComision.DataPropertyName = "Comision";
                    icolComision.DisplayIndex = 1;
                    icolComision.Width = 70;
                    dgvUsuarios.Columns.Add(icolComision);
                    DataGridViewTextBoxColumn icolCondicion = new DataGridViewTextBoxColumn();
                    icolCondicion.Name = "Condicion";
                    icolCondicion.HeaderText = "Condicion";
                    icolCondicion.DataPropertyName = "Condicion";
                    icolCondicion.DisplayIndex = 2;
                    icolCondicion.Width = 70;
                    dgvUsuarios.Columns.Add(icolCondicion);

                    this.Text = "Inscripciones";
                    Listar(Tipo);
                    this.usuarioActual = usuario;
                    tsbEditar.Enabled = false;
                    break;
            }
        }

        public General()
        {
            
        }

        public void Listar(String Tipo)                                 
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
                    LogicaMateria lm = new LogicaMateria();
                    LogicaComision lc = new LogicaComision();
                    LogicaCurso lcu = new LogicaCurso();
                    LogicaInscripcion li = new LogicaInscripcion();
                    List<AlumnoInscripciones> ais = new List<AlumnoInscripciones>();
                    ais = li.TraerTodosPorIdPersona(this.usuarioActual.IDPersona);
                    List<InscripcionesEditado> ins = new List<InscripcionesEditado>();
                    foreach(AlumnoInscripciones ai in ais)
                    {
                        InscripcionesEditado i = new InscripcionesEditado();
                        i.ID = ai.ID;
                        i.Materia = lm.TraerUno(lcu.TraerUno(ai.IDCurso).IDMateria).Descripcion;
                        i.Comision = lc.TraerUno(lcu.TraerUno(ai.IDCurso).IDComision).Descripcion;
                        i.Nota = ai.Nota;
                        i.Condicion = ai.Condicion;
                        ins.Add(i);
                    }
                    dgvUsuarios.DataSource = ins;
                    break;
                case "tNotas":
                    LogicaMateria llm = new LogicaMateria();
                    LogicaPersona llp = new LogicaPersona();
                    LogicaCurso llcu = new LogicaCurso();
                    LogicaInscripcion lli = new LogicaInscripcion();
                    List<AlumnoInscripciones> aais = new List<AlumnoInscripciones>();
                    aais = lli.TraerTodosPorIdCurso(IdCursoActual);
                    List<InscripcionesEditado> iins = new List<InscripcionesEditado>();
                    foreach (AlumnoInscripciones ai in aais)
                    {
                        InscripcionesEditado i = new InscripcionesEditado();
                        i.ID = ai.ID;
                        i.Materia = llm.TraerUno(llcu.TraerUno(ai.IDCurso).IDMateria).Descripcion;
                        i.Alumno = llp.TraerUno(ai.IDAlumno).Nombre + " " + llp.TraerUno(ai.IDAlumno).Apellido;
                        i.Nota = ai.Nota;
                        i.Condicion = ai.Condicion;
                        iins.Add(i);
                    }
                    dgvUsuarios.DataSource = iins;
                    break;
            }
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
                case "tNotas":
                    Listar("tNotas");
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
                        FormularioInscripcion aBMinscripcion = new FormularioInscripcion(iID, FormularioAplicacion.ModosFormulario.Modificacion, this.usuarioActual);
                        aBMinscripcion.ShowDialog();
                        Listar("tInscripciones");
                        break;
                    case "Notas":
                        Entidades.InscripcionesEditado i = (Entidades.InscripcionesEditado)this.dgvUsuarios.SelectedRows[0].DataBoundItem;
                        FormularioNotasCarga fnc = new FormularioNotasCarga(i);
                        fnc.ShowDialog();
                        Listar("tNotas");
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
                        int iID = ((Entidades.InscripcionesEditado)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;
                        FormularioInscripcion aBMinscripcion = new FormularioInscripcion(iID, FormularioAplicacion.ModosFormulario.Baja, this.usuarioActual);
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