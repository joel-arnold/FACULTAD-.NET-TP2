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

        protected virtual void CargarPagina()
        {
            //Se implementa en cada página en particular con un override.
        }

        protected int IDSeleccionado
        {
            get
            {
                if (ViewState["IDSeleccionado"] != null)
                {
                    return (int)ViewState["IDSeleccionado"];
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["IDSeleccionado"] = value; }
        }

        protected bool HayEntidadSeleccionada
        {
            get { return IDSeleccionado != 0; }
        }

        protected int IDUsuario
        {
            get
            {
                if (Session["idUsuario"] != null)
                {
                    return (int)Session["idUsuario"];
                }
                else
                {
                    return 0;
                }
            }
            set { Session["idUsuario"] = value; }
        }

        protected int IDPersona
        {
            get
            {
                if (Session["idPersona"] != null)
                {
                    return (int)Session["idPersona"];
                }
                else
                {
                    return -1;
                }
            }
            set { Session["idPersona"] = value; }
        }

        public bool UsuarioEstaLogueado
        {
            get { return IDUsuario != 0; }
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

        public bool EsAdministrador
        {
            get
            {
                try
                {
                    return new LogicaPersona().TraerUno(IDPersona).Tipo == Personas.TipoPersona.Administrativo;
                }
                catch (Exception Ex)
                {
                    MensajeError = Ex.Message;
                    Response.Redirect("Error.aspx");
                }
                return false;
            }
        }

        public bool EsDocente
        {
            get
            {
                if (!EsAdministrador)
                {
                    try
                    {
                        return new LogicaPersona().TraerUno(IDPersona).Tipo == Personas.TipoPersona.Profesor;
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
                        return new LogicaPersona().TraerUno(IDPersona).Tipo == Personas.TipoPersona.Alumno;
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
    }
}