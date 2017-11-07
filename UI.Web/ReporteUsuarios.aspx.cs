using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class ReporteUsuarios1 : ABM
    {
        protected override void CargarPagina()
        {
            if ((string)Session["privilegio"] != "admin")
            {
                Response.Redirect("noCorrespondeSeccion.aspx");
            }
            else
            {
                ReportDocument cryRpt = new ReportDocument();
                TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
                TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
                ConnectionInfo crConnectionInfo = new ConnectionInfo();
                Tables CrTables;

                cryRpt.Load(@"D:\Usuario\TP2_Net\UI.Web\ReporteUsuarios.rpt");

                crConnectionInfo.ServerName = "Casa";
                crConnectionInfo.DatabaseName = "tp2_net";
                crConnectionInfo.UserID = "net";
                crConnectionInfo.Password = "net";

                CrTables = cryRpt.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
                {
                    crtableLogoninfo = CrTable.LogOnInfo;
                    crtableLogoninfo.ConnectionInfo = crConnectionInfo;
                    CrTable.ApplyLogOnInfo(crtableLogoninfo);
                }

                CrystalReportViewer1.ReportSource = cryRpt;
                CrystalReportViewer1.RefreshReport();
            }
        }
    }
}