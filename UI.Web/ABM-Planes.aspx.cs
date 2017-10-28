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
    public partial class Planes : ABM
    {

        #region Acciones de formulario
        protected void gridViewPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.IDSeleccionado = (int)this.gridViewPlanes.SelectedValue;
            formPanel.Visible = false;
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.HayEntidadSeleccionada)
            {
                this.HabilitarFormulario(true);
                this.HabilitarBotones(true);
                this.formPanel.Visible = true;
                this.ModoFormulario = ModosFormulario.Modificacion;
                this.idTextBox.Enabled = false;
                this.CargarFormulario(this.IDSeleccionado);
            }
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
                        if (Page.IsValid)
                        {
                            this.Plan = new Plan();
                            this.Plan.ID = this.IDSeleccionado;
                            this.Plan.Estado = Entidad.Estados.Modificado;
                            this.MapearAPlan(this.Plan);
                            this.Guardar(this.Plan);
                            this.CargarGrilla();
                            this.formPanel.Visible = false;
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
                            this.Plan = new Plan();
                            this.MapearAPlan(this.Plan);
                            this.Guardar(this.Plan);
                            this.CargarGrilla();
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
            if (this.HayEntidadSeleccionada)
            {
                this.formPanel.Visible = true;
                this.ModoFormulario = ModosFormulario.Baja;
                this.HabilitarFormulario(false);
                this.HabilitarBotones(true);
                this.CargarFormulario(this.IDSeleccionado);
            }
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

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LimpiarFormulario();
            this.formPanel.Visible = false;
            this.CargarGrilla();
        }
        #endregion

        #region Métodos
        protected override void CargarPagina()
        {
            CargarGrilla();
            if ((string)Session["privilegio"] != "admin")
            {
                this.nuevoLinkButton.Visible = false;
                this.eliminarLinkButton.Visible = false;
                this.editarLinkButton.Visible = false;
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
            gridViewPlanes.SelectedIndex = 0;
        }

        private void CargarFormulario(int id)
        {
            this.Plan = LogicaPlan.TraerUno(id);
            this.idTextBox.Text = this.Plan.ID.ToString();
            this.descripcionTextBox.Text = this.Plan.Descripcion;
            this.ddlEspecialidad.SelectedValue = new LogicaEspecialidad().TraerUno(Plan.IdEspecialidad).ID.ToString();
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
            ddlEspecialidad.Enabled = enable;
            cargarEspecialidades();
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

        private void Borrar(int id)
        {
            this.LogicaPlan.Borrar(id);
        }

        private void LimpiarFormulario()
        {
            this.idTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }
        #endregion
    }
}