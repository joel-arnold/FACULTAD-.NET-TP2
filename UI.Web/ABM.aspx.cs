using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ABM : System.Web.UI.Page
    {
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (UsuarioEstaLogueado)
            {
                if (!IsPostBack)
                {
                    CargarPagina();
                }
            }
            else
            {
                Response.Redirect("noInicioSesion.aspx");
            }
        }

        public EstadoFormulario.ModoForm FormMode
        {
            get { return (EstadoFormulario.ModoForm)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        protected int SelectedID
        {
            get
            {
                if (ViewState["SelectedID"] != null)
                {
                    return (int)ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["SelectedID"] = value; }
        }

        protected bool IsEntitySelected
        {
            get { return SelectedID != 0; }
        }

        protected int IDUsuario
        {
            get
            {
                if (Session["IDUsuario"] != null)
                {
                    return (int)Session["IDUsuario"];
                }
                else
                {
                    return 0;
                }
            }
            set { Session["IDUsuario"] = value; }
        }

        protected int IDPersona
        {
            get
            {
                if (Session["IDPersona"] != null)
                {
                    return (int)Session["IDPersona"];
                }
                else
                {
                    return -1;
                }
            }
            set { Session["IDPersona"] = value; }
        }

        public bool EstaUsuarioLogueado
        {
            get { return IDUsuario != 0; }
        }

        public string NombreUsuario
        {
            get
            {
                if (Session["NombreUsuario"] != null)
                {
                    return Session["NombreUsuario"].ToString();
                }
                else
                {
                    return string.Empty;
                }
            }
            set { Session["NombreUsuario"] = value; }
        }

        public bool EsAdministrador
        {
            get { return IDPersona == 0; }
        }

        public bool EsDocente
        {
            get
            {
                if (!EsAdministrador)
                {
                    try
                    {
                        return new PersonaLogic().GetOne(IDPersona).TipoPersona == TiposPersonas.Tipos.Profesor;
                    }
                    catch (Exception Ex)
                    {
                        MensajeError = Ex.Message;
                        Response.Redirect("Error.aspx");
                    }
                }
                return false;
            }
        }

        public bool EsAlumno
        {
            get
            {
                if (!EsAdministrador)
                {
                    try
                    {
                        return new PersonaLogic().GetOne(IDPersona).TipoPersona == TiposPersonas.Tipos.Alumno;
                    }
                    catch (Exception Ex)
                    {
                        MensajeError = Ex.Message;
                        Response.Redirect("Error.aspx");
                    }
                }
                return false;
            }
        }

        public string MensajeError
        {
            get
            {
                if (Session["MensajeError"] != null)
                {
                    return (string)Session["MensajeError"];
                }
                return null;
            }
            set { Session["MensajeError"] = value; }
        }

        //public void Desloguear()
        //{
        //    IDUsuario = 0;
        //    IDPersona = -1;
        //    NombreUsuario = null;
        //    MensajeError = null;
        //}

        protected virtual void CargarPagina()
        {

        }
    }
}