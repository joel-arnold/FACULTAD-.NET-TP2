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
    public partial class FormularioInscripcion : FormularioAplicacion
    {
        public Usuario usuarioActual;
        Personas personaActual;

        //CONSTRUCTOR POR DEFECTO
        public FormularioInscripcion()
        {
            InitializeComponent();

        }

        private void FormularioInscripcion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'tp2_netDataSet2.comisiones' Puede moverla o quitarla según sea necesario.
            this.comisionesTableAdapter.Fill(this.tp2_netDataSet2.comisiones);

        }

        private AlumnoInscripciones inscripcionActual = new AlumnoInscripciones();

        public AlumnoInscripciones InscripcionActual
        {
            get
            {
                return inscripcionActual;
            }
            set
            {
                inscripcionActual = value;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //CONSTRUCTOR PARA ALTAS
        public FormularioInscripcion(ModosFormulario modo, Usuario usuario) : this()
        {
            this.usuarioActual = usuario;
            this.lblLoguinTexto.Text = usuarioActual.Nombre + " " + usuarioActual.Apellido;
            this.Modo = modo;
            this.txtID.ReadOnly = true;
            //cargarMateriasYComisiones();
        }

        //CONSTRUCTOR PARA MODIFICACION, BAJA Y CONSULTA
        public FormularioInscripcion(int ID, ModosFormulario modo, Usuario usuario) : this()
        {
            this.usuarioActual = usuario;
            this.lblLoguinTexto.Text = usuarioActual.Nombre + " " + usuarioActual.Apellido;
            this.Modo = modo;
            Negocio.LogicaInscripcion li = new Negocio.LogicaInscripcion();
            InscripcionActual = li.TraerUno(ID);
            MapearDeDatos();
            this.txtID.ReadOnly = true;
            if (this.Modo == ModosFormulario.Baja)
            {
                this.txtID.ReadOnly = true;
            }
        }

        //private void asignarDatos()
        //{
            
        //    List<Materia> materiasActuales;
        //    List<Comision> comisionesActuales;
            
        //    materiasActuales = new List<Materia>();
        //    comisionesActuales = new List<Comision>();
        //    //LogicaUsuario lu = new LogicaUsuario();
        //    LogicaPersona lp = new LogicaPersona();
        //    personaActual = lp.TraerUno(usuarioActual.IDPersona);
            
        //    materiasActuales = 
            
        //    comisionesActuales = lc.TraerTodosPorIdPlan(personaActual.IDPlan);
            
        }

    //public void carga()
    //{
    //    LogicaPersona lp = new LogicaPersona();
    //    personaActual = lp.TraerUno(usuarioActual.IDPersona);
    //    LogicaMateria lm = new LogicaMateria();
    //    LogicaComision lc = new LogicaComision();

    //DataTable dtMateria = new DataTable();
    //dtMateria.Columns.Add("Descripción", typeof(string));
    //        dtMateria.Columns.Add("ID", typeof(int));
    //        foreach (Materia materia in lm.TraerTodos())
    //        {
    //        dtMateria.Rows.Add(new object[] { materia.Descripcion, materia.ID});
    //        }
    //        this.cbbxMateria.ValueMember = "ID";
    //        cbbxMateria.DisplayMember = "Descripción";
    //        cbbxMateria.DataSource = dtMateria;

    //    DataTable dtComision = new DataTable();
    //    dtComision.Columns.Add("Descripción", typeof(string));
    //    dtComision.Columns.Add("ID", typeof(int));
    //    foreach (Comision comision in lc.TraerTodosPorIdPlan(personaActual.IDPlan))
    //    {
    //        dtComision.Rows.Add(new object[] { comision.Descripcion, comision.ID });
    //    }
    //    this.cbbxComision.ValueMember = "ID";
    //    cbbxComision.DisplayMember = "Descripción";
    //    cbbxComision.DataSource = dtComision;
    //}



}

