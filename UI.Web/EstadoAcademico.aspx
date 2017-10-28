<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server">
        <asp:Label ID="etiqTitulo" runat="server" Text="Estado académico del alumno " CssClass="etiquetas" Font-Bold="False"></asp:Label>
        <asp:Label ID="etiqAlumno" runat="server" Text="Alumno" CssClass="etiquetas" Font-Bold="True"></asp:Label>
        &nbsp;<asp:Label ID="etiqX" runat="server" CssClass="etiquetas" Text="al"></asp:Label>&nbsp;
        <asp:Label ID="etiqFecha" runat="server" CssClass="etiquetas" Font-Bold="True" Text="DiaMesAño"></asp:Label>
        <br />
        <asp:GridView ID="gvEstadoAcademico" runat="server" CssClass="etiquetas">
        </asp:GridView>
        <br />
        <br />
        <asp:LinkButton ID="btnVolver" runat="server" CssClass="etiquetas">Volver al inicio</asp:LinkButton>

    </asp:Panel>
</asp:Content>
