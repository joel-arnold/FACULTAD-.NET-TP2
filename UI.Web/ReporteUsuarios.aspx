<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteUsuarios.aspx.cs" Inherits="UI.Web.ReporteUsuarios1" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.3500.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center">
        <h1>REPORTE DE USUARIOS</h1>
        <br />
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True" GroupTreeImagesFolderUrl="" Height="1202px" ReportSourceID="crsReporteUsuarios" ToolbarImagesFolderUrl="" ToolPanelWidth="200px" Width="1104px" />
        <CR:CrystalReportSource ID="crsReporteUsuarios" runat="server">
            <Report FileName="ReporteUsuarios.rpt">
            </Report>
        </CR:CrystalReportSource>
    </div>
    <br />
    <br />
</asp:Content>
