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
    public partial class ABM_NotasAlumnos : ABM
    {
        protected override void CargarPagina()
        {
            CargarGrillaCursos();
            CargarGrillaAlumnos(7);
        }

        private void CargarGrillaCursos()
        {
            DataTable dtAlumnos = new DataTable();
            dtAlumnos.Columns.Add("ID", typeof(int));
            dtAlumnos.Columns.Add("Comision", typeof(string));
            dtAlumnos.Columns.Add("Materia", typeof(string));
            foreach (Curso curso in LogicaCurso.TraerTodos())
            {
                DataRow fila = dtAlumnos.NewRow();
                fila["ID"] = curso.ID;
                fila["Comision"] = LogicaComision.TraerUno(curso.IDComision).Descripcion;
                fila["Materia"] = LogicaMateria.TraerUno(curso.IDMateria).Descripcion;
                dtAlumnos.Rows.Add(fila);
            }
            dtAlumnos.DefaultView.Sort = "ID,Comision,Materia";
            gvCursos.DataSource = dtAlumnos;
            gvCursos.DataBind();
            gvCursos.SelectedIndex = 0;
        }

        private void CargarGrillaAlumnos(int idCurso)
        {
            DataTable dtCursos = new DataTable();
            dtCursos.Columns.Add("Legajo", typeof(int));
            dtCursos.Columns.Add("Alumno", typeof(string));
            foreach (AlumnoInscripciones alumno in LogicaInscripcion.TraerTodos(idCurso))
            {
                DataRow fila = dtCursos.NewRow();
                fila["Legajo"] = LogicaPersona.TraerUno(alumno.IDAlumno).Legajo;
                fila["Alumno"] = LogicaPersona.TraerUno(alumno.IDAlumno).Apellido + ", " + LogicaPersona.TraerUno(alumno.IDAlumno).Nombre;
                dtCursos.Rows.Add(fila);
            }
            dtCursos.DefaultView.Sort = "Alumno, Legajo";
            gvCursos.DataSource = dtCursos;
            gvCursos.DataBind();
            gvCursos.SelectedIndex = 0;
        }
    }
}