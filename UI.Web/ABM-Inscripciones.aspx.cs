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
        #region Acciones de formulario

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
            if(!estaInscripto())
            {
                Inscribir();
                pnlInscripcion.Visible = true;
                pnlComision.Visible = false;
                pnlMaterias.Visible = false;
                etiqYaInscripto.Visible = false;
                lblInscripcion.Text = "Inscripción exitosa";
            }
            else
            {
                etiqYaInscripto.Visible = true;
            }
            
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
        #endregion

        #region Métodos
        protected override void CargarPagina()
        {
            if ((string)Session["privilegio"] != "alumno")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            else
            {
                pnlComision.Visible = false;
                pnlMaterias.Visible = true;
                pnlInscripcion.Visible = false;
                Alumno = LogicaAlumno.TraerUno((int)Session["idPersona"]);
                GuardarAlumno();
                lblAlumno.Text = Alumno.Apellido + ", " + Alumno.Nombre;
                CargarGrillaMaterias();
            }
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

        protected void Inscribir()
        {
            Materia = LogicaMateria.TraerUno((int)gvMaterias.SelectedValue);
            int comision = (int)gvComisiones.SelectedValue;
            Curso = LogicaCurso.TraerUnoPorMateriaYComision(Materia.ID, comision);
            InscripcionAlumno = new AlumnoInscripciones();
            InscripcionAlumno.Condicion = "Inscripto";
            InscripcionAlumno.IDAlumno = IDSeleccionado;
            InscripcionAlumno.IDCurso = Curso.ID;
            LogicaInscripcion.Guardar(InscripcionAlumno);
        }

        public bool estaInscripto()
        {
            bool inscripto = false;
            List<AlumnoInscripciones> inscripcionesPropias = new List<AlumnoInscripciones>();
            inscripcionesPropias = LogicaInscripcion.TraerTodosPorIdPersona(IDPersona);
            foreach (AlumnoInscripciones ip in inscripcionesPropias)
            {
                Curso curso;
                curso = LogicaCurso.TraerUno(ip.IDCurso);
                if (curso.IDMateria == (int)gvMaterias.SelectedValue)
                {
                    inscripto = true;
                }
            }
            return inscripto;
        }
        #endregion
    }
}