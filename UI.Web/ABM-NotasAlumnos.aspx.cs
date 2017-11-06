using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ABM_NotasAlumnos : ABM
    {
        #region Acciones de formulario
        protected void gvCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            Curso = LogicaCurso.TraerUno((int)gvCursos.SelectedValue);
            CargarGrillaAlumnos(Curso.ID);
            panelAlumnos.Visible = true;
            etiqComision.Text = LogicaComision.TraerUno(Curso.IDComision).Descripcion;
            etiqMateria.Text = LogicaMateria.TraerUno(Curso.IDMateria).Descripcion;
            etiqValidacionNota.Visible = false;
            panelNota.Visible = false;
        }

        protected void gvAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNota.Text = String.Empty;
            etiqValidacionNota.Visible = false;
            panelNota.Visible = true;
            panelAlumnos.Visible = true;
        }

        protected void btnConfirmarNota_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtNota.Text)>0 && Convert.ToInt32(txtNota.Text) < 11)
            {
                ModificarNota(Convert.ToInt32(txtNota.Text.Trim()), LogicaInscripcion.TraerUno((int)gvAlumnos.SelectedValue));
                panelNota.Visible = false;
                panelAlumnos.Visible = true;
                CargarGrillaAlumnos((int)gvCursos.SelectedValue);
                etiqValidacionNota.Visible = false;
                txtNota.Text = String.Empty;
            }
            else
            {
                etiqValidacionNota.Visible = true;
            }
        }

        protected void linkVolverAlInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        #endregion

        #region Métodos
        protected override void CargarPagina()
        {
            if ((string)Session["privilegio"] != "profesor")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            else
            {
                CargarGrillaCursos();
                panelAlumnos.Visible = false;
                panelNota.Visible = false;
            }
        }

        private void CargarGrillaCursos()
        {
            int idDocente = (int)Session["idPersona"];
            DataTable dtAlumnos = new DataTable();
            dtAlumnos.Columns.Add("ID", typeof(int));
            dtAlumnos.Columns.Add("Comision", typeof(string));
            dtAlumnos.Columns.Add("Materia", typeof(string));
            
            foreach (DocenteCurso ldc in LogicaDocenteCurso.TraerTodos(idDocente))
            {
                foreach (Curso curso in LogicaCurso.TraerTodos())
                {
                    if(curso.ID == ldc.IDCurso)
                    {
                        DataRow fila = dtAlumnos.NewRow();
                        fila["ID"] = curso.ID;
                        fila["Comision"] = LogicaComision.TraerUno(curso.IDComision).Descripcion;
                        fila["Materia"] = LogicaMateria.TraerUno(curso.IDMateria).Descripcion;
                        dtAlumnos.Rows.Add(fila);
                    }
                }
            }
            dtAlumnos.DefaultView.Sort = "ID,Comision,Materia";
            gvCursos.DataSource = dtAlumnos;
            gvCursos.DataBind();
        }

        private void CargarGrillaAlumnos(int idCurso)
        {
            DataTable dtCursos = new DataTable();
            dtCursos.Columns.Add("ID", typeof(int));
            dtCursos.Columns.Add("Legajo", typeof(int));
            dtCursos.Columns.Add("Alumno", typeof(string));
            dtCursos.Columns.Add("Nota", typeof(int));
            dtCursos.Columns.Add("Condicion", typeof(string));
            foreach (AlumnoInscripciones alumno in LogicaInscripcion.TraerTodosPorIdCurso(idCurso))
            {
                DataRow fila = dtCursos.NewRow();
                fila["ID"] = alumno.ID;
                fila["Legajo"] = LogicaPersona.TraerUno(alumno.IDAlumno).Legajo;
                fila["Alumno"] = LogicaPersona.TraerUno(alumno.IDAlumno).Apellido + ", " + LogicaPersona.TraerUno(alumno.IDAlumno).Nombre;
                fila["Condicion"] = alumno.Condicion;
                fila["Nota"] = alumno.Nota;
                dtCursos.Rows.Add(fila);
            }
            dtCursos.DefaultView.Sort = "Alumno, Legajo, Nota, ID";
            gvAlumnos.DataSource = dtCursos;
            gvAlumnos.DataBind();
            gvAlumnos.SelectedIndex = 0;
        }

        protected void ModificarNota(int nota, AlumnoInscripciones alumno)
        {
            alumno.Nota = nota;
            if (nota >= 8)
            {
                alumno.Condicion = "Aprobado";
            }
            else if(nota >= 6)
            {
                alumno.Condicion = "Regular";
            }
            else
            {
                alumno.Condicion = "Aplazado";
            }
            
            LogicaInscripcion.Actualizar(alumno);
        }
        #endregion
    }
}