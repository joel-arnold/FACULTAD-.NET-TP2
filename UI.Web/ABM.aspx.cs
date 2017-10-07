using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

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

        public bool UsuarioEstaLogueado
        {
            get { return IDUsuario != 0; }
        }

        public bool EsAdministrador
        {
            get { return IDPersona == 0; }
        }

        //public bool EsDocente
        //{
        //    get
        //    {
        //        if (!EsAdministrador)
        //        {
        //            try
        //            {
        //                return new LogicaPersona().TraerUno(IDPersona). == TiposPersonas.Tipos.Profesor;
        //            }
        //            catch (Exception Ex)
        //            {
        //                MensajeError = Ex.Message;
        //                Response.Redirect("Error.aspx");
        //            }
        //        }
        //        return false;
        //    }
        //}

        //public bool EsAlumno
        //{
        //    get
        //    {
        //        if (!EsAdministrador)
        //        {
        //            try
        //            {
        //                return new PersonaLogic().GetOne(IDPersona).TipoPersona == TiposPersonas.Tipos.Alumno;
        //            }
        //            catch (Exception Ex)
        //            {
        //                Response.Redirect();
        //            }
        //        }
        //        return false;
        //    }
        //}
    }
}