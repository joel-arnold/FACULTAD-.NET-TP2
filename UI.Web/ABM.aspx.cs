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
    public partial class ABM : System.Web.UI.Page
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioEstaLogueado)
            {
                if (!IsPostBack)
                {
                    CargarPagina();
                }
            }
            else
            {
                Response.Redirect("noInicioSesion.aspx");
            }
        }

        #region Atributos y Propiedades
        public Personas Alumno
        {
            get;
            set;
        }

        public Comision Comision
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

        public Personas persona = new Personas();
        protected Personas PersonaActual
        {
            get;
            set;
        }

        protected Plan Plan
        {
            get;
            set;
        }

        public enum ModosFormulario
        {
            Alta,
            Baja,
            Modificacion
        }

        public ModosFormulario ModoFormulario
        {
            get { return (ModosFormulario)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        LogicaUsuario _LogicaUsuario;
        protected Usuario UsuarioActual
        {
            get;
            set;
        }

        public LogicaUsuario LogicaUsuario
        {
            get
            {
                if (_LogicaUsuario == null)
                {
                    _LogicaUsuario = new LogicaUsuario();
                }
                return _LogicaUsuario;
            }
        }

        LogicaPlan _LogicaPlan;
        public LogicaPlan LogicaPlan
        {
            get
            {
                if (_LogicaPlan == null)
                {
                    _LogicaPlan = new LogicaPlan();
                }
                return _LogicaPlan;
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

        protected int IDSeleccionado
        {
            get
            {
                if (ViewState["IDSeleccionado"] != null)
                {
                    return (int)ViewState["IDSeleccionado"];
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["IDSeleccionado"] = value; }
        }

        protected bool HayEntidadSeleccionada
        {
            get { return IDSeleccionado != 0; }
        }

        LogicaPersona _LogicaPersona;
        public LogicaPersona LogicaPersona
        {
            get
            {
                if (_LogicaPersona == null)
                {
                    _LogicaPersona = new LogicaPersona();
                }
                return _LogicaPersona;
            }
        }

        private LogicaComision _LogicaComision;
        public LogicaComision LogicaComision
        {
            get
            {
                if (_LogicaComision == null)
                {
                    _LogicaComision = new LogicaComision();
                }
                return _LogicaComision;
            }
        }

        private LogicaInscripcion _LogicaInscripcion;
        public LogicaInscripcion LogicaInscripcion
        {
            get
            {
                if (_LogicaInscripcion == null)
                {
                    _LogicaInscripcion = new LogicaInscripcion();
                }
                return _LogicaInscripcion;
            }
        }

        LogicaCurso _LogicaCurso;
        public LogicaCurso LogicaCurso
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

        LogicaDocenteCurso _LogicaDocenteCurso;
        public LogicaDocenteCurso LogicaDocenteCurso
        {
            get
            {
                if (_LogicaDocenteCurso == null)
                {
                    _LogicaDocenteCurso = new LogicaDocenteCurso();
                }
                return _LogicaDocenteCurso;
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

        protected int IDUsuario
        {
            get
            {
                if (Session["idUsuario"] != null)
                {
                    return (int)Session["idUsuario"];
                }
                else
                {
                    return 0;
                }
            }
            set { Session["idUsuario"] = value; }
        }

        protected int IDPersona
        {
            get
            {
                if (Session["idPersona"] != null)
                {
                    return (int)Session["idPersona"];
                }
                else
                {
                    return -1;
                }
            }
            set { Session["idPersona"] = value; }
        }

        public string MensajeError
        {
            get
            {
                if (Session["MensajeError"] != null)
                {
                    return (string)Session["MensajeError"];
                }
                return null;
            }
            set { Session["MensajeError"] = value; }
        }
        #endregion

        #region Métodos
        protected virtual void CargarPagina()
        {
            //Se implementa en cada página en particular con un override.
        }

        public bool UsuarioEstaLogueado
        {
            get { return IDUsuario != 0; }
        }

        //public bool EsAdministrador
        //{
        //    get
        //    {
        //        try
        //        {
        //            return new LogicaPersona().TraerUno(IDPersona).Tipo == Personas.TipoPersona.Administrativo;
        //        }
        //        catch (Exception Ex)
        //        {
        //            MensajeError = Ex.Message;
        //            Response.Redirect("Error.aspx");
        //        }
        //        return false;
        //    }
        //}

        //public bool EsDocente
        //{
        //    get
        //    {
        //        if (!EsAdministrador)
        //        {
        //            try
        //            {
        //                return new LogicaPersona().TraerUno(IDPersona).Tipo == Personas.TipoPersona.Profesor;
        //            }
        //            catch (Exception Ex)
        //            {
        //                MensajeError = Ex.Message;
        //                Response.Redirect("Error.aspx");
        //            }
        //        }
        //        return false;
        //    }
        //}

        //public bool EsAlumno
        //{
        //    get
        //    {
        //        if (!EsAdministrador)
        //        {
        //            try
        //            {
        //                return new LogicaPersona().TraerUno(IDPersona).Tipo == Personas.TipoPersona.Alumno;
        //            }
        //            catch (Exception Ex)
        //            {
        //                MensajeError = Ex.Message;
        //                Response.Redirect("Error.aspx");
        //            }
        //        }
        //        return false;
        //    }
        //}
        #endregion
    }
}