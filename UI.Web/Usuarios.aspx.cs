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

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
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
            this.gridView.DataSource = this.Logic.GetAll();
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
            this.Entity = this.Logic.GetOne(id);
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
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
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
            this.Logic.Save(usuario);
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
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    {
                        this.DeleteEntity(this.SelectedID);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        break;
                    }
                case FormModes.Modificacion:
                    {
                        if (Validar())
                        {
                            this.Entity = new Usuario();
                            this.Entity.ID = this.SelectedID;
                            this.Entity.State = Entidad.States.Modified;
                            this.LoadEntity(this.Entity);
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
                            this.formPanel.Visible = false;
                            break;
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                case FormModes.Alta:
                    {
                        if (Validar())
                        {
                            this.Entity = new Usuario();
                            this.LoadEntity(this.Entity);
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
                            this.formPanel.Visible = false;
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
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
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
            this.formPanel.Visible = false;
            this.LoadGrid();
        }

        public bool Validar()
        {
            bool valida = true;
                         
            if (nombreTextBox.Text.Trim().Length == 0)
            {
                etiqErrorNombre.Text = "El nombre no puede estar vacío.";
                if(valida == true)
                {
                    valida = false;
                }
            }
            else
            {
                etiqErrorNombre.Text = "Ok";
                etiqErrorNombre.ForeColor = System.Drawing.Color.Green;
            }


            if (apellidoTextBox.Text.Trim().Length == 0)
            {
                etiqErrorApellido.Text = "El apellido no puede estar vacío.";
                if (valida == true)
                {
                    valida = false;
                }
            }
            else
            {
                etiqErrorApellido.Text = "Ok";
                etiqErrorApellido.ForeColor = System.Drawing.Color.Green;
            }

            if (nombreUsuarioTextBox.Text.Trim().Length == 0)
            {
                etiqErrorUsuario.Text = "El usuario no puede estar vacío.";
                if (valida == true)
                {
                    valida = false;
                }
            }
            else
            {
                etiqErrorUsuario.Text = "Ok";
                etiqErrorUsuario.ForeColor = System.Drawing.Color.Green;
            }

            if (emailTextBox.Text.Trim().Length == 0)
            {
                etiqErrorEmail.Text = "El correo electrónico no puede estar vacío.";
                if (valida == true)
                {
                    valida = false;
                }
            }
            else
            {
                etiqErrorEmail.Text = "Ok";
                etiqErrorEmail.ForeColor = System.Drawing.Color.Green;
            }

            if (!Validacion.clavesCoinciden(claveTextBox.Text, repetirClaveTextBox.Text))
            {
                etiqErrorClavesCoinciden.Text = "Las claves ingresadas no coinciden.";
                if (valida == true)
                {
                    valida = false;
                }
            }
            else
            {
                etiqErrorClavesCoinciden.Text = "";
            }

            if (!Validacion.esClaveValida(claveTextBox.Text))
            {
                etiqErrorClave.Text = "La clave debe contener al menos 8 caracteres.";
                if (valida == true)
                {
                    valida = false;
                }
            }
            else
            {
                etiqErrorClave.Text = "Ok";
                etiqErrorClave.ForeColor = System.Drawing.Color.Green;
            }
            

            if(emailTextBox.Text.Trim().Length == 0)
            {
                etiqErrorEmail.Text = "El correo electrónico no puede estar vacío.";
                if (valida == true)
                {
                    valida = false;
                }
            }
            else
            {
                etiqErrorEmail.Text = "";
            }

            if ((!Validacion.esMailValido(emailTextBox.Text)) && (emailTextBox.Text.Trim().Length != 0))
            {
                etiqErrorFormaEmail.Text = "El formato de email ingresado no es correcto.";
                if (valida == true)
                {
                    valida = false;
                }
            }
            else if(emailTextBox.Text.Trim().Length != 0)
            {
                etiqErrorFormaEmail.Text = "Ok";
                etiqErrorFormaEmail.ForeColor = System.Drawing.Color.Green;
            }
            
            return valida;
        }

    }
}