using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace UI.Web {
    public partial class Usuarios : System.Web.UI.Page {

        LogicaUsuario _logic;

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
        }

        protected void Page_Load(object sender, EventArgs e) {
            LoadGrid();
        }
    }
}