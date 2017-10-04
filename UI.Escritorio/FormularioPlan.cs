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
    public partial class FormularioPlan : FormularioAplicacion
    {
        //CONSTRUCTOR POR DEFECTO
        public FormularioPlan()
        {
            InitializeComponent();
            CargarEspecialidades();
        }

        //CONSTRUCTOR PARA ALTAS
        public FormularioPlan(ModosFormulario modo) : this()
        {
            this.Modo = modo;
            this.txtID.ReadOnly = true;
        }

        //CONSTRUCTOR PARA MODIFICACION, BAJA Y CONSULTA
        public FormularioPlan(int ID, ModosFormulario modo) : this()
        {
            this.Modo = modo;
            Negocio.LogicaPlan plan = new Negocio.LogicaPlan();
            PlanActual = plan.TraerUno(ID);
            MapearDeDatos();
            this.txtID.ReadOnly = true;
            if (this.Modo == ModosFormulario.Baja)
            {
                this.txtDescripcion.ReadOnly = true;
                this.txtID.ReadOnly = true;
                //combobox especialidad en readonly (crear un controlador durante el proceso?)
            }
        }

        private Plan planActual = new Plan();

        public Plan PlanActual
        {
            get
            {
                return planActual;
            }
            set
            {
                planActual = value;
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
                Plan planActual = new Plan();
                PlanActual.Estado = Entidad.Estados.Nuevo;
            }
            else if (Modo == ModosFormulario.Modificacion)
            {
                PlanActual.ID = int.Parse(txtID.Text);
                PlanActual.Estado = Entidad.Estados.Modificado;
            }
            else if (Modo == ModosFormulario.Baja)
            {
                PlanActual.ID = int.Parse(txtID.Text);
                PlanActual.Estado = Entidad.Estados.Borrado;
            }
            else if (Modo == ModosFormulario.Consulta)
            {
                PlanActual.ID = int.Parse(txtID.Text);
                PlanActual.Estado = Entidad.Estados.SinModificar;
            }
            PlanActual.Descripcion = this.txtDescripcion.Text;
            PlanActual.IdEspecialidad = Convert.ToInt32(this.cbbxEspecialidad.SelectedValue);
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cbbxEspecialidad.SelectedValue = PlanActual.IdEspecialidad;

            //Acá configuro el texto del botón aceptar según sea el modo con el que se llamó al formulario
            switch (Modo)
            {
                case ModosFormulario.Alta:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModosFormulario.Modificacion:
                    btnAceptar.Text = "Guardar";
                    break;

                case ModosFormulario.Baja:
                    btnAceptar.Text = "Eliminar";
                    break;

                case ModosFormulario.Consulta:
                    btnAceptar.Text = "Aceptar";
                    break;
            }
        }

        private void CargarEspecialidades()
        {
            LogicaEspecialidad oEspecialidad = new LogicaEspecialidad();
            try
            {
                DataTable dtEspecialidad = new DataTable();
                dtEspecialidad.Columns.Add("Descripción", typeof(string));
                dtEspecialidad.Columns.Add("ID", typeof(int));
                foreach (Especialidad especialidad in oEspecialidad.TraerTodos())
                {
                    dtEspecialidad.Rows.Add(new object[] { especialidad.Descripcion, especialidad.ID });
                }
                cbbxEspecialidad.ValueMember = "ID";
                cbbxEspecialidad.DisplayMember = "Descripción";
                cbbxEspecialidad.DataSource = dtEspecialidad;
            }
            catch (Exception Ex)
            {
                Notificar(Ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override void GuardarCambios()
        {
            MapearADatos();
            LogicaPlan logicaPlanActual = new LogicaPlan();
            logicaPlanActual.Guardar(PlanActual);
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

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
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