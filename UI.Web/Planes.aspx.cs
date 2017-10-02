using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace UI.Web
{
    public partial class Planes : System.Web.UI.Page
    {
        LogicaPlan _LogicaPlan;
        private Plan Plan
        {
            get;
            set;
        }

        private int IDSeleccionado
        {
            get
            {
                if (this.ViewState["IDSeleccionado"] != null)
                {
                    return (int)this.ViewState["IDSeleccionado"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["IDSeleccionado"] = value;
            }
        }

        private bool HayPlanSeleccionado
        {
            get
            {
                return (this.IDSeleccionado != 0);
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
            get { return (ModosFormulario)this.ViewState["ModoFormulario"]; }
            set { this.ViewState["ModoFormulario"] = value; }
        }

        public LogicaPlan LogicaPlan
        {
            get
            {
                if (_LogicaPlan == null)
                {
                    _LogicaPlan = new LogicaPlan();
                }
                return _LogicaPlan;
            }
        }


        private void CargarGrilla()
        {
            DataTable tblPlanes = new DataTable();
            tblPlanes.Columns.Add("ID", typeof(int));
            tblPlanes.Columns.Add("Plan", typeof(string));
            tblPlanes.Columns.Add("Especialidad", typeof(string));
            foreach (Plan plan in LogicaPlan.TraerTodos())
            {
                DataRow fila = tblPlanes.NewRow();
                fila["ID"] = plan.ID;
                fila["Plan"] = plan.Descripcion;
                fila["Especialidad"] = new LogicaEspecialidad().TraerUno(plan.IdEspecialidad).Descripcion;
                tblPlanes.Rows.Add(fila);
            }
            tblPlanes.DefaultView.Sort = "ID,Especialidad,Plan";
            gridViewPlanes.DataSource = tblPlanes;
            gridViewPlanes.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                CargarGrilla();
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

        protected void gridViewPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IDSeleccionado = (int)this.gridViewPlanes.SelectedValue;
        }

        private void CargarFormulario(int id)
        {
            this.Plan = LogicaPlan.TraerUno(id);
            this.idTextBox.Text = this.Plan.ID.ToString();
            this.descripcionTextBox.Text = this.Plan.Descripcion;
            this.ddlEspecialidad.SelectedValue = new LogicaEspecialidad().TraerUno(Plan.IdEspecialidad).Descripcion;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.HayPlanSeleccionado)
            {
                this.HabilitarFormulario(true);
                this.HabilitarBotones(true);
                this.formPanel.Visible = true;
                this.ModoFormulario = ModosFormulario.Modificacion;
                this.idTextBox.Enabled = false;
                this.CargarFormulario(this.IDSeleccionado);
            }
        }

        private void MapearAPlan(Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text.Trim();
            plan.IdEspecialidad = int.Parse(this.ddlEspecialidad.SelectedValue);
        }

        private void Guardar(Plan plan)
        {
            this.LogicaPlan.Guardar(plan);
        }

        private void HabilitarFormulario(bool enable)
        {
            idTextBox.Enabled = enable;
            descripcionTextBox.Enabled = enable;
            cargarEspecialidades();
            ddlEspecialidad.Enabled = enable;
        }

        private void HabilitarBotones(bool enable)
        {
            this.aceptarLinkButton.Visible = enable;
            this.cancelarLinkButton.Visible = enable;
        }

        private void cargarEspecialidades()
        {
            LogicaEspecialidad le = new LogicaEspecialidad();
            ddlEspecialidad.DataSource = le.TraerTodos();
            ddlEspecialidad.DataTextField = "Descripcion";
            ddlEspecialidad.DataValueField = "ID";
            ddlEspecialidad.DataBind();
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.ModoFormulario)
            {
                case ModosFormulario.Baja:
                    {
                        this.Borrar(this.IDSeleccionado);
                        this.CargarGrilla();
                        this.formPanel.Visible = false;
                        break;
                    }
                case ModosFormulario.Modificacion:
                    {
                            this.Plan = new Plan();
                            this.Plan.ID = this.IDSeleccionado;
                            this.Plan.Estado = Entidad.Estados.Modificado;
                            this.MapearAPlan(this.Plan);
                            this.Guardar(this.Plan);
                            this.CargarGrilla();
                            break;
                    }
                case ModosFormulario.Alta:
                    {
                        this.Plan = new Plan();
                        this.MapearAPlan(this.Plan);
                        this.Guardar(this.Plan);
                        this.CargarGrilla();
                        break;
                    }
                default: break;
            }
            this.formPanel.Visible = false;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.HayPlanSeleccionado)
            {
                this.formPanel.Visible = true;
                this.ModoFormulario = ModosFormulario.Baja;
                this.HabilitarFormulario(false);
                this.HabilitarBotones(true);
                this.CargarFormulario(this.IDSeleccionado);
            }
        }

        private void Borrar(int id)
        {
            this.LogicaPlan.Borrar(id);
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.ModoFormulario = ModosFormulario.Alta;
            this.LimpiarFormulario();
            this.HabilitarFormulario(true);
            this.HabilitarBotones(true);
            this.idTextBox.Enabled = false;
        }

        private void LimpiarFormulario()
        {
            this.idTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
            this.formPanel.Visible = false;
            this.CargarGrilla();
        }

        
    }
}