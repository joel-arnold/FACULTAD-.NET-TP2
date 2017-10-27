﻿using System;
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

        private LogicaAlumnoInscripciones _LogicaInscripcion;
        public LogicaAlumnoInscripciones LogicaInscripciones
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

        #endregion

        protected override void CargarPagina()
        {
            if ((string)Session["privilegio"] != "alumno")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            pnlComision.Visible = false;
            pnlMaterias.Visible = true;
            pnlInscripcion.Visible = false;
            Alumno = LogicaAlumno.TraerUno((int)Session["idPersona"]);
            GuardarAlumno();
            lblAlumno.Text = Alumno.Apellido + ", " + Alumno.Nombre;
            CargarGrillaMaterias();
        }

        protected void gvMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            Materia = LogicaMateria.TraerUno((int)gvMaterias.SelectedValue);
            gvComisiones.DataSource = LogicaComision.TraerComisiones(Materia.ID, DateTime.Now.Year);
            gvComisiones.DataBind();
            pnlComision.Visible = true;
            pnlInscripcion.Visible = false;
            lblMateria.Text = Materia.Descripcion;
        }

        protected void gvComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            Curso = LogicaCurso.TraerUno((int)gvComisiones.SelectedValue);
            InscripcionAlumno = new AlumnoInscripciones();
            InscripcionAlumno.Condicion = "Inscripto";
            InscripcionAlumno.IDAlumno = IDSeleccionado;
            InscripcionAlumno.IDCurso = Curso.ID;
            LogicaInscripciones.Guardar(InscripcionAlumno);
            pnlInscripcion.Visible = true;
            pnlComision.Visible = false;
            pnlMaterias.Visible = false;
            lblInscripcion.Text = "Inscripción exitosa";
        }

        private void CargarGrillaMaterias()
        {
            this.gvMaterias.DataSource = this.LogicaMateria.TraerTodos(Alumno.IDPlan);
            this.gvMaterias.DataBind();
            this.gvMaterias.SelectedIndex = 0;
        }

        private void GuardarAlumno()
        {
            IDSeleccionado = Alumno.ID;
        }

        protected void lbnInscribirseAOtraMateria_Click(object sender, EventArgs e)
        {
            pnlMaterias.Visible = true;
            pnlInscripcion.Visible = false;
        }

        protected void lbnCancelarComisiones_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}