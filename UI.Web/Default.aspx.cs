using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            //CONFIGURACION TEMPORAL PARA QUE NO HAYA QUE LOGUEARSE EN CADA EJECUCION
            //Session["idUsuario"] = 1009;
            //Session["usuario"] = "alumnoUsuario";
            //Session["nombre"] = "alumnoNombre";
            //Session["apellido"] = "alumnoApellido";
            //Session["idPersona"] = 1004;
            //Session["privilegio"] = "alumno";
            //CON ESTOS DATOS INICIA LOGUEADO
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ingreso.aspx");
        }
    }
}