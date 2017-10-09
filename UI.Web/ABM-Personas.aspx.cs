using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ABM_Personas : ABM
    {
        protected override void CargarPagina()
        {
            CargarGrilla();
            if ((string)Session["privilegio"] != "admin")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
        }

        LogicaPersona _LogicaPersona;
        Personas personita = new Personas();
        private Personas PersonaActual
        {
            get;
            set;
        }

        public enum ModosFormulario
        {
            Alta,
            Baja,
            Modificacion
        }

        public ModosFormulario ModoFormulario
        {
            get { return (ModosFormulario)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }

        public LogicaPersona LogicaPersona
        {
            get
            {
                if (_LogicaPersona == null)
                {
                    _LogicaPersona = new LogicaPersona();
                }
                return _LogicaPersona;
            }
        }


        private void CargarGrilla()
        {
            this.gridView.DataSource = this.LogicaPersona.TraerTodos();
            this.gridView.DataBind();
            this.gridView.SelectedIndex = 0;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IDSeleccionado = (int)this.gridView.SelectedValue;
        }

        private void CargarFormulario(int id)
        {
            this.personita = this.LogicaPersona.TraerUno(id);
            this.nombreTextBox.Text = this.personita.Nombre;
            this.apellidoTextBox.Text = this.personita.Apellido;
            this.emailTextBox.Text = this.personita.Email;
            this.direccionTextBox.Text = this.personita.Direccion;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.HayEntidadSeleccionada)
            {
                this.HabilitarFormulario(true);
                this.panelFormulario.Visible = true;
                this.ModoFormulario = ModosFormulario.Modificacion;
                this.CargarFormulario(this.IDSeleccionado);
            }
        }

        private void MapearAPersona(Personas persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
        }

        private void Guardar(Personas persona)
        {
            this.LogicaPersona.Guardar(persona);
        }

        private void HabilitarFormulario(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.ModoFormulario)
            {
                case ModosFormulario.Baja:
                    {
                        this.BorrarUsuario(this.IDSeleccionado);
                        this.CargarGrilla();
                        this.panelFormulario.Visible = false;
                        this.sumarioDeValidacion.ShowValidationErrors = false;
                        break;
                    }
                case ModosFormulario.Modificacion:
                    {
                        if (Page.IsValid)
                        {
                            this.PersonaActual = new Personas();
                            this.PersonaActual.ID = this.IDSeleccionado;
                            this.PersonaActual.Estado = Entidad.Estados.Modificado;
                            this.MapearAPersona(this.PersonaActual);
                            this.Guardar(this.PersonaActual);
                            this.CargarGrilla();
                            this.panelFormulario.Visible = false;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    }
                case ModosFormulario.Alta:
                    {
                        if (Page.IsValid)
                        {
                            this.PersonaActual = new Personas();
                            this.MapearAPersona(this.PersonaActual);
                            this.Guardar(this.PersonaActual);
                            this.CargarGrilla();
                            this.panelFormulario.Visible = false;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                default: break;
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.HayEntidadSeleccionada)
            {
                this.panelFormulario.Visible = true;
                this.ModoFormulario = ModosFormulario.Baja;
                this.HabilitarFormulario(false);
                this.CargarFormulario(this.IDSeleccionado);
            }
        }

        private void BorrarUsuario(int id)
        {
            this.LogicaPersona.Borrar(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.panelFormulario.Visible = true;
            this.ModoFormulario = ModosFormulario.Alta;
            this.LimpiarFormulario();
            this.HabilitarFormulario(true);
        }

        private void LimpiarFormulario()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
            this.panelFormulario.Visible = false;
            this.CargarGrilla();
        }
    }
}