using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace UI.Web
{
    public partial class Ingreso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IngresoAutenticacion(object sender, AuthenticateEventArgs e)
        {
            bool Autenticado = false;
            Autenticado = IngresoCorrecto(Login1.UserName, Login1.Password);
            e.Authenticated = Autenticado; if (Autenticado)
            {
                Response.Redirect("Default.aspx");
            }
        }
        private bool IngresoCorrecto(string usuario, string clave)
                {
                    LogicaUsuario lu = new LogicaUsuario();
                    if (lu.existeUsuario(usuario, clave))
                    return true;
                    return false;
                }

            }
        }