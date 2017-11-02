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
    public partial class FormularioNotasCursos : FormularioAplicacion
    {
        private Personas profesorActual = new Personas();

        public FormularioNotasCursos()
        {
            InitializeComponent();
        }

        public FormularioNotasCursos(Personas p)
        {
            InitializeComponent();
            ProfesorActual = p;
            cargarCursos();
        }

        public Personas ProfesorActual
        {
            get
            {
                return profesorActual;
            }
            set
            {
                profesorActual = value;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cargarCursos()
        {
            LogicaCurso lc = new LogicaCurso();
            List<Curso> cursos = new List<Curso>();
            LogicaDocenteCurso ldc = new LogicaDocenteCurso();
            List<DocenteCurso> dictados = new List<DocenteCurso>();
            dictados = ldc.TraerTodos(profesorActual.ID);
            foreach (DocenteCurso dictado in dictados)
            {
                cursos.Add(lc.TraerUno(dictado.IDCurso));
            }
            
            DataTable dtCurso = new DataTable();
            dtCurso.Columns.Add("IDComision", typeof(int));
            dtCurso.Columns.Add("IDMateria", typeof(int));
            dtCurso.Columns.Add("ID", typeof(int));
            dtCurso.Columns.Add("Combo", typeof(int), "IDComision+''+IDMateria");
            foreach (Curso cu in cursos)
            {
                dtCurso.Rows.Add(new object[] { cu.IDComision, cu.IDMateria, cu.ID });
            }
            cbbxCurso.DataSource = dtCurso;
            cbbxCurso.ValueMember = "ID";
            cbbxCurso.DisplayMember = "Combo";
            cbbxCurso.SelectedIndex = -1;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            List<AlumnoInscripciones> inscripciones = new List<AlumnoInscripciones>();
            LogicaInscripcion li = new LogicaInscripcion();
            if(cbbxCurso.SelectedItem != null)
            {
                General gral = new General(Convert.ToInt32(cbbxCurso.SelectedValue));
                this.Dispose();
                gral.ShowDialog();
            }
            else
            {
                MessageBox.Show("No selecciono ningun curso");
            }
            
        }
    }
}
