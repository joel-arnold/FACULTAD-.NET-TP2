using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;
using Data.Database;
using System.Globalization;
using System.Text.RegularExpressions;
using Util;

namespace UI.Escritorio
{
    public partial class FormularioUsuario : FormularioAplicacion
    {
        //CONSTRUCTOR POR DEFECTO
        public FormularioUsuario()
        {
            InitializeComponent();
        }

        //CONSTRUCTOR PARA ALTAS
        public FormularioUsuario(ModoForm modo) :this()
        {
            this.Modo = modo;
            this.txtID.ReadOnly = true;
        }

        //CONSTRUCTOR PARA MODIFICACION, BAJA Y CONSULTA
        public FormularioUsuario(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            Negocio.LogicaUsuario usuario = new Negocio.LogicaUsuario();
            UsuarioActual = usuario.GetOne(ID);
            MapearDeDatos();
            this.txtID.ReadOnly = true;
            if(this.Modo == ModoForm.Baja)
            {
                this.txtNombre.ReadOnly = true;
                this.txtApellido.ReadOnly = true;
                this.txtClave.ReadOnly = true;
                this.txtConfirmarClave.ReadOnly = true;
                this.txtID.ReadOnly = true;
                this.txtCorreoE.ReadOnly = true;
                this.txtUsuario.ReadOnly = true;
                this.chkHabilitado.Enabled = true;
            }
        }

        Validacion validador = new Validacion();
        private Usuario usuarioActual = new Usuario();

        public Usuario UsuarioActual
        {
            get
            {
                return usuarioActual;
            }
            set
            {
                usuarioActual = value;
            }
        }

        public Validacion Validador
        {
            get
            {
                return validador;
            }

            set
            {
                validador = value;
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            


        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //SOBRE-ESCRITURA DE LOS METODOS DE LA CLASE PADRE
        public override void MapearADatos()
        {
            if (Modo == ModoForm.Alta)
            {
                Usuario usuarioActual = new Usuario();
                UsuarioActual.State = Entidad.States.New;
            }
            else if (Modo == ModoForm.Modificacion)
            {
                UsuarioActual.ID = int.Parse(txtID.Text);
                UsuarioActual.State = Entidad.States.Modified;
            }
            else if (Modo == ModoForm.Baja)
            {
                UsuarioActual.ID = int.Parse(txtID.Text);
                UsuarioActual.State = Entidad.States.Deleted;
            }
            else if (Modo == ModoForm.Consulta)
            {
                UsuarioActual.ID = int.Parse(txtID.Text);
                UsuarioActual.State = Entidad.States.Unmodified;
            }
            UsuarioActual.Habilitado = this.chkHabilitado.Checked;
            UsuarioActual.Nombre = this.txtNombre.Text;
            UsuarioActual.Apellido = this.txtApellido.Text;
            UsuarioActual.Email = this.txtCorreoE.Text;
            UsuarioActual.NombreUsuario = this.txtUsuario.Text;
            UsuarioActual.Clave = this.txtClave.Text;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtCorreoE.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;

            //Acá configuro el texto del botón aceptar según sea el modo con el que se llamó al formulario
            switch (Modo)
            {
                case  ModoForm.Alta: btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Modificacion: btnAceptar.Text = "Guardar";
                    break;

                case ModoForm.Baja: btnAceptar.Text = "Eliminar";
                break;

                case ModoForm.Consulta: btnAceptar.Text = "Aceptar";
                break;
            }
        }

        public override void GuardarCambios() {
            MapearADatos();
            LogicaUsuario logicaUsuarioActual = new LogicaUsuario();
            logicaUsuarioActual.Save(UsuarioActual);
        }

        public override bool Validar()
        {
            bool valida = false;
            string mensaje = "";

            if (txtApellido.Text.Trim().Length == 0 || txtNombre.Text.Trim().Length == 0 || txtCorreoE.Text.Trim().Length == 0
                || txtUsuario.Text.Trim().Length == 0 || txtClave.Text.Trim().Length == 0 || txtConfirmarClave.Text.Trim().Length == 0)
                mensaje += "Debe completar todos los campos" + "\n";
            if (!Validador.esClaveValida(txtClave.Text))
                mensaje += "La clave debe contener al menos 8 caracteres" + "\n";
            if (!validador.clavesCoinciden(txtClave.Text, txtConfirmarClave.Text))
                mensaje += "Las claves no coinciden" + "\n";
            if (!Validador.esMailValido(txtCorreoE.Text))
                mensaje += "El correo electrónico ingresado no es válido";

            if (!String.IsNullOrEmpty(mensaje))
            {
                this.Notificar(mensaje, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                valida = true;
            }

            return valida;
        }

        public override void Notificar(string titulo, string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            MessageBox.Show(mensaje, titulo, botones, icono);
        }

        public override void Notificar(string mensaje, MessageBoxButtons botones, MessageBoxIcon icono)
        {
            this.Notificar(this.Text, mensaje, botones, icono);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
          if(this.Modo != ModoForm.Baja)
            {
                if (Validar())
                {
                    GuardarCambios();
                    this.Close();
                }
            }
          else
            {
                GuardarCambios();
                this.Close();
            }
                    
        }
    }
}