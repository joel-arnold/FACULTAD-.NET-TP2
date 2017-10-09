using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace UI.Web
{
    public partial class ABM_Inscripciones : ABM
    {
        #region Propiedades y campos
        public Personas Alumno
        {
            get;
            set;
        }

        public Materia Materia
        {
            get;
            set;
        }

        public Curso Curso
        {
            get;
            set;
        }

        public AlumnoInscripciones InscripcionAlumno
        {
            get;
            set;
        }

        private LogicaAlumnoInscripciones _LogicaInscripcion;
        public LogicaAlumnoInscripciones InscripcionLogic
        {
            get
            {
                if (_LogicaInscripcion == null)
                {
                    _LogicaInscripcion = new LogicaAlumnoInscripciones();
                }
                return _LogicaInscripcion;
            }
        }

        private LogicaMateria _LogicaMateria;
        public LogicaMateria LogicaMateria
        {
            get
            {
                if (_LogicaMateria == null)
                {
                    _LogicaMateria = new LogicaMateria();
                }
                return _LogicaMateria;
            }
        }

        private LogicaPersona _LogicaAlumno;
        public LogicaPersona LogicaAlumno
        {
            get
            {
                if (_LogicaAlumno == null)
                {
                    _LogicaAlumno = new LogicaPersona();
                }
                return _LogicaAlumno;
            }
        }

        private LogicaCurso _LogicaCurso;
        public LogicaCurso CursoLogic
        {
            get
            {
                if (_LogicaCurso == null)
                {
                    _LogicaCurso = new LogicaCurso();
                }
                return _LogicaCurso;
            }
        }

        #endregion

        protected override void CargarPagina()
        {
            if ((string)Session["privilegio"] != "alumno")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            pnlComision.Visible = false;
            pnlMaterias.Visible = true;
            Usuario usuario = new Usuario();
            Personas persona = new Personas();
            usuario = new LogicaUsuario().TraerUno(IDUsuario);
            persona = LogicaAlumno.TraerUno(usuario.IDPersona);
            lblAlumno.Text = IDPersona.ToString();
            etiqueta2.Text = persona.Apellido;
        }
    }
}