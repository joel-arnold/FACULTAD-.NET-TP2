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
            Usuario usu = new Usuario();
            LogicaUsuario lu = new LogicaUsuario();
            ddlAlumnos.DataSource = lu.TraerTodos();
            ddlAlumnos.DataTextField = "Apellido";
            ddlAlumnos.DataValueField = "Legajo";
            ddlAlumnos.DataBind();
        }
    }
}