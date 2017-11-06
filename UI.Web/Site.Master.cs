using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web {
    public partial class Site1 : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            if (Session["usuario"] != null)
            {
                etiqSesion.Text = (string)Session["usuario"];
                etiqSesion.ForeColor = System.Drawing.Color.White;
            }

            if (Session["usuario"] == null)
            {
                btnIngresar.Text = "Ingresar";
            }
            else
            {
                btnIngresar.Text = "Cerrar sesión";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Ingreso.aspx");
            }
            else
            {
                Session.Abandon();
                Response.Redirect("Default.aspx");
            }
        }
    }
}