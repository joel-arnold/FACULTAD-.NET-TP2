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
    public partial class ABM_Inscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Usuario usu = new Usuario();
                LogicaUsuario lu = new LogicaUsuario();
                ddlAlumnos.DataSource = lu.TraerTodos();
                ddlAlumnos.DataTextField = "Apellido";
                ddlAlumnos.DataValueField = "ID";
                ddlAlumnos.DataBind();
            }
        }

        protected void ddlAlumnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlAlumnos.SelectedIndex = 0;
            if (ddlAlumnos.SelectedValue != "")
            {
                Label2.Text = new LogicaUsuario().TraerUno(ddlAlumnos.SelectedIndex).Nombre;
                descripcionTextBox2.Text = new LogicaUsuario().TraerUno(ddlAlumnos.SelectedIndex).Nombre;
            }
        }
    }
}