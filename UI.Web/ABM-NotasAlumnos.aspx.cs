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
        private void CargarGrillaCursos()
        {
            DataTable dtCursos = new DataTable();
            dtCursos.Columns.Add("ID", typeof(int));
            dtCursos.Columns.Add("Comision", typeof(string));
            dtCursos.Columns.Add("Materia", typeof(string));
            foreach (Curso curso in LogicaCurso.TraerTodos())
            {
                DataRow fila = dtCursos.NewRow();
                fila["ID"] = curso.ID;
                fila["Comision"] = LogicaComision.TraerUno(curso.IDComision).Descripcion;
                fila["Materia"] = LogicaMateria.TraerUno(curso.IDMateria).Descripcion;
                dtCursos.Rows.Add(fila);
            }
            dtCursos.DefaultView.Sort = "ID,Comision,Materia";
            gvCursos.DataSource = dtCursos;
            gvCursos.DataBind();
            gvCursos.SelectedIndex = 0;
        }
    }
}