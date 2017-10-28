using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class EstadoAcademico : ABM
    {
        #region Acciones de formulario

        #endregion

        #region Métodos
        protected override void CargarPagina()
        {
            CargarEstadoAcademico();
        }

        private void CargarEstadoAcademico()
        {
            int idAlumno = (int)Session["idPersona"];
            DataTable dtEstadoAlumno = new DataTable();
            dtEstadoAlumno.Columns.Add("Materia", typeof(string));
            dtEstadoAlumno.Columns.Add("Situación", typeof(string));
            dtEstadoAlumno.Columns.Add("Nota", typeof(int));

            foreach (AlumnoInscripciones ai in LogicaInscripcion.TraerTodosPorIdPersona(idAlumno))
            {
                DataRow fila = dtEstadoAlumno.NewRow();
                fila["Materia"] = LogicaMateria.TraerUno(ai.IDCurso).Descripcion;
                fila["Situación"] = ai.Condicion;
                fila["Nota"] = ai.Nota;
                dtEstadoAlumno.Rows.Add(fila);
            }
            dtEstadoAlumno.DefaultView.Sort = "Situación, Nota";
            gvEstadoAcademico.DataSource = dtEstadoAlumno;
            gvEstadoAcademico.DataBind();
        }
        #endregion
    }
}