using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.ToLower() == "admin" && this.txtClave.Text == "12345")
            {
                Response.Redirect("~/Usuarios.aspx");
            }
            else
            {
                Page.Response.Write("Usuario y/o contraseña incorrectos.");
            }
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }

    }
}