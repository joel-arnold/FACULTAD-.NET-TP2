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
    public partial class Usuarios : System.Web.UI.Page {

        LogicaUsuario _logic;
        private Usuario Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
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

        public LogicaUsuario Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new LogicaUsuario();
                }
                return _logic;
            }
        }


        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.TraerTodos();
            this.gridView.DataBind();
            this.gridView.SelectedIndex = 999999;
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (Session["usuario"] != null)
            {
                LoadGrid();
                if ((string)Session["privilegio"] != "admin")
                {
                    this.nuevoLinkButton.Visible = false;
                    this.eliminarLinkButton.Visible = false;
                    this.editarLinkButton.Visible = false;
                }
            }
            else
            {
                Response.Redirect("noInicioSesion.aspx");
            }
            
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.TraerUno(id);
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.panelFormulario.Visible = true;
                this.ModoFormulario = ModosFormulario.Modificacion;
                this.LoadForm(this.SelectedID);
                Console.WriteLine(Entity.Apellido);
            }
        }

        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.Email = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Guardar(usuario);
        }

        private void EnableForm(bool enable)
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
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        this.panelFormulario.Visible = false;
                        break;
                    }
                case ModosFormulario.Modificacion:
                    {
                        if (Page.IsValid)
                        {
                            this.Entity = new Usuario();
                            this.Entity.ID = this.SelectedID;
                            this.Entity.Estado = Entidad.Estados.Modificado;
                            this.LoadEntity(this.Entity);
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
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
                            this.Entity = new Usuario();
                            this.LoadEntity(this.Entity);
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
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
            if (this.IsEntitySelected)
            {
                this.panelFormulario.Visible = true;
                this.ModoFormulario = ModosFormulario.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Borrar(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.panelFormulario.Visible = true;
            this.ModoFormulario = ModosFormulario.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.panelFormulario.Visible = false;
            this.LoadGrid();
        }

    }
}