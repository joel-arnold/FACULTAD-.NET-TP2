using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using Util;

namespace UI.Web {
    public partial class Usuarios : ABM {

        protected override void CargarPagina()
        {
            CargarGrilla();
            if ((string)Session["privilegio"] != "admin")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
        }

        LogicaUsuario _LogicaUsuario;
        private Usuario UsuarioActual
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
            set { this.ViewState["FormMode"]=value; }
        }

        public LogicaUsuario LogicaUsuario
        {
            get
            {
                if (_LogicaUsuario == null)
                {
                    _LogicaUsuario = new LogicaUsuario();
                }
                return _LogicaUsuario;
            }
        }


        private void CargarGrilla()
        {
            this.gridView.DataSource = this.LogicaUsuario.TraerTodos();
            this.gridView.DataBind();
            this.gridView.SelectedIndex = 0;
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IDSeleccionado = (int)this.gridView.SelectedValue;
        }

        private void CargarFormulario(int id)
        {
            this.UsuarioActual = this.LogicaUsuario.TraerUno(id);
            this.nombreTextBox.Text = this.UsuarioActual.Nombre;
            this.apellidoTextBox.Text = this.UsuarioActual.Apellido;
            this.emailTextBox.Text = this.UsuarioActual.Email;
            this.habilitadoCheckBox.Checked = this.UsuarioActual.Habilitado;
            this.nombreUsuarioTextBox.Text = this.UsuarioActual.NombreUsuario;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.HayEntidadSeleccionada)
            {
                this.HabilitarFormulario(true);
                this.panelFormulario.Visible = true;
                this.ModoFormulario = ModosFormulario.Modificacion;
                this.CargarFormulario(this.IDSeleccionado);
                Console.WriteLine(UsuarioActual.Apellido);
            }
        }

        private void MapearAUsuario(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.Email = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
        }

        private void Guardar(Usuario usuario)
        {
            this.LogicaUsuario.Guardar(usuario);
        }

        private void HabilitarFormulario(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
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
                            this.UsuarioActual = new Usuario();
                            this.UsuarioActual.ID = this.IDSeleccionado;
                            this.UsuarioActual.Estado = Entidad.Estados.Modificado;
                            this.MapearAUsuario(this.UsuarioActual);
                            this.Guardar(this.UsuarioActual);
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
                            this.UsuarioActual = new Usuario();
                            this.MapearAUsuario(this.UsuarioActual);
                            this.Guardar(this.UsuarioActual);
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
            this.LogicaUsuario.Borrar(id);
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
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
            this.panelFormulario.Visible = false;
            this.CargarGrilla();
        }

        protected void validadorTamanioClave_ServerValidate(object source, ServerValidateEventArgs args) {
            if (claveTextBox.Text.Trim().Length < 8) {
                args.IsValid = false;
            }
        }

    }
}