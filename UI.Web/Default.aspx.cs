using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            /*CONFIGURACION TEMPORAL PARA QUE NO HAYA QUE LOGUEARSE EN CADA EJECUCION
            Session["idUsuario"] = 1029;
            Session["usuario"] = "admin";
            Session["nombre"] = "Administrador";
            Session["apellido"] = "Supremo";
            Session["idPersona"] = 6;
            Session["privilegio"] = "admin";
            CON ESTOS DATOS INICIA LOGUEADO EL ADMINISTRADOR*/

            if (Session["usuario"] != null)
            {
                panelcito.Visible = false;
            }
                
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingreso.aspx");
        }
    }
}