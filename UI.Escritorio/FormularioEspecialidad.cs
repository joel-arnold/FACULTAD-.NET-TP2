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
    public partial class FormularioEspecialidad : FormularioAplicacion
    {
        //CONSTRUCTOR POR DEFECTO
        public FormularioEspecialidad()
        {
            InitializeComponent();
        }

        //CONSTRUCTOR PARA ALTAS
        public FormularioEspecialidad(ModosFormulario modo) : this()
        {
            this.Modo = modo;
            this.txtID.ReadOnly = true;
        }

        //CONSTRUCTOR PARA MODIFICACION, BAJA Y CONSULTA
        public FormularioEspecialidad(int ID, ModosFormulario modo) : this()
        {
            this.Modo = modo;
            Negocio.LogicaEspecialidad le = new Negocio.LogicaEspecialidad();
            EspecialidadActual = le.TraerUno(ID);
            MapearDeDatos();
            this.txtID.ReadOnly = true;
            if (this.Modo == ModosFormulario.Baja)
            {
                this.txtDescripcion.ReadOnly = true;
                this.txtID.ReadOnly = true;
            }
        }

        private Especialidad especialidadActual = new Especialidad();

        public Especialidad EspecialidadActual
        {
            get
            {
                return especialidadActual;
            }
            set
            {
                especialidadActual = value;
            }
        }
        
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        //SOBRE-ESCRITURA DE LOS METODOS DE LA CLASE PADRE
        public override void MapearADatos()
        {
            if (Modo == ModosFormulario.Alta)
            {
                Especialidad especialidadActual = new Especialidad();
                especialidadActual.Estado = Entidad.Estados.Nuevo;
            }
            else if (Modo == ModosFormulario.Modificacion)
            {
                especialidadActual.ID = int.Parse(txtID.Text);
                especialidadActual.Estado = Entidad.Estados.Modificado;
            }
            else if (Modo == ModosFormulario.Baja)
            {
                especialidadActual.ID = int.Parse(txtID.Text);
                especialidadActual.Estado = Entidad.Estados.Borrado;
            }
            else if (Modo == ModosFormulario.Consulta)
            {
                especialidadActual.ID = int.Parse(txtID.Text);
                especialidadActual.Estado = Entidad.Estados.SinModificar;
            }
            especialidadActual.Descripcion = this.txtDescripcion.Text;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.especialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.especialidadActual.Descripcion;

            //Acá configuro el texto del botón aceptar según sea el modo con el que se llamó al formulario
            switch (Modo)
            {
                case ModosFormulario.Alta:
                    btnGuardar.Text = "Guardar";
                    break;

                case ModosFormulario.Modificacion:
                    btnGuardar.Text = "Guardar";
                    break;

                case ModosFormulario.Baja:
                    btnGuardar.Text = "Eliminar";
                    break;

                case ModosFormulario.Consulta:
                    btnGuardar.Text = "Aceptar";
                    break;
            }
        }

        

        public override void GuardarCambios()
        {
            MapearADatos();
            LogicaEspecialidad logicaespecialidadActual = new LogicaEspecialidad();
            logicaespecialidadActual.Guardar(especialidadActual);
        }

        public override bool Validar()
        {
            bool valida = false;
            string mensaje = "";

            if (txtDescripcion.Text.Trim().Length == 0)
                mensaje += "Debe completar el campo Descripcion" + "\n";
            //validaciones del combobox solo con selectedIndex -1 y empty (no necesario)

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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (this.Modo != ModosFormulario.Baja)
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
