using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Web.SessionState;
using Entidades;

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
            LogicaPersona lp = new LogicaPersona();
            Usuario usuarioActual = lu.existeUsuario(usuario, clave);
            if (usuarioActual != null)
            {
                Session["idUsuario"] = (int)usuarioActual.ID;
                Session["usuario"] = (string)usuarioActual.NombreUsuario;
                Session["nombre"] = (string)usuarioActual.Nombre;
                Session["apellido"] = (string)usuarioActual.Apellido;
                Session["email"] = (string)usuarioActual.NombreUsuario;
                Session["idPersona"] = (int)lp.TraerUno(usuarioActual.IDPersona).ID;
                Session["privilegio"] = (string)usuarioActual.Privilegio;

                return true;
            }
            else
            {
                return false;
            }    
        }

    }
}