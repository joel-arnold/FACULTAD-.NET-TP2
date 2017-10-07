using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Error : ABM
    {
        protected override void CargarPagina()
        {
            etiqError.Text = MensajeError;
        }

        protected void vuelveInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}