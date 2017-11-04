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
            List<CursoEditado> cursosE = new List<CursoEditado>();
            List<Curso> cursos = new List<Curso>();
            LogicaDocenteCurso ldc = new LogicaDocenteCurso();
            List<DocenteCurso> dictados = new List<DocenteCurso>();
            dictados = ldc.TraerTodos(profesorActual.ID);
            foreach (DocenteCurso dictado in dictados)
            {
                cursos.Add(lc.TraerUno(dictado.IDCurso));
            }
            LogicaMateria lmateria = new LogicaMateria();
            LogicaComision lcomision = new LogicaComision();
            foreach (Curso cc in cursos)
            {
                CursoEditado cursoE = new CursoEditado();
                cursoE.ID = cc.ID;
                cursoE.Materia = lmateria.TraerUno(cc.IDMateria).Descripcion;
                cursoE.Comision = lcomision.TraerUno(cc.IDComision).Descripcion + " - ";
                cursosE.Add(cursoE);
            }
            
            DataTable dtCursoE = new DataTable();
            dtCursoE.Columns.Add("Comision", typeof(string));
            dtCursoE.Columns.Add("Materia", typeof(string));
            dtCursoE.Columns.Add("ID", typeof(int));
            dtCursoE.Columns.Add("Combo", typeof(string), "Comision+''+Materia");
            foreach (CursoEditado ce in cursosE)
            {
                dtCursoE.Rows.Add(new object[] { ce.Comision, ce.Materia, ce.ID });
            }
            cbbxCurso.DataSource = dtCursoE;
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
