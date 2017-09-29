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
        LogicaPlan _logic;
        private Plan Entity
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
            set { this.ViewState["FormMode"] = value; }
        }

        public LogicaPlan Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new LogicaPlan();
                }
                return _logic;
            }
        }


        private void LoadGrid()
        {
            this.gridViewPlanes.DataSource = this.Logic.GetAll();
            this.gridViewPlanes.DataBind();
            this.gridViewPlanes.SelectedIndex = 999999;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void gridViewPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridViewPlanes.SelectedValue;
        }

        private void LoadForm(int id)
        {
            DataTable tblPlanes = new DataTable();
            tblPlanes.Columns.Add("ID", typeof(int));
            tblPlanes.Columns.Add("Plan", typeof(string));
            tblPlanes.Columns.Add("Especialidad", typeof(string));
            foreach (Plan plan in Logic.GetAll())
            {
                DataRow fila = tblPlanes.NewRow();
                fila["ID"] = plan.ID;
                fila["Plan"] = plan.Descripcion;
                fila["Especialidad"] = new LogicaEspecialidad().GetOne(plan.IdEspecialidad).Descripcion;
                tblPlanes.Rows.Add(fila);
            }
            tblPlanes.DefaultView.Sort = "Especialidad,Plan";
            gridViewPlanes.DataSource = tblPlanes;
            gridViewPlanes.DataBind();
        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IdEspecialidad = Int32.Parse(this.especialidadTextBox.Text);
        }

        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
        }

        private void EnableForm(bool enable)
        {
            this.idTextBox.Enabled = enable;
            this.descripcionTextBox.Enabled = enable;
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
                            this.Entity = new Plan();
                            this.Entity.ID = this.SelectedID;
                            this.Entity.State = Entidad.States.Modified;
                            this.LoadEntity(this.Entity);
                            this.SaveEntity(this.Entity);
                            this.LoadGrid();
                            break;
                    }
                case FormModes.Alta:
                    {
                        this.Entity = new Plan();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        break;
                    }
                default: break;
            }
            this.formPanel.Visible = false;
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
            this.idTextBox.Text = string.Empty;
            this.descripcionTextBox.Text = string.Empty;
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.ClearForm();
            this.formPanel.Visible = false;
            this.LoadGrid();
        }

    }
}