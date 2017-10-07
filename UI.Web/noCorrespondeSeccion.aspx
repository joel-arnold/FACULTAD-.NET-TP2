<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="noCorrespondeSeccion.aspx.cs" Inherits="UI.Web.noCorrespondeSeccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="noCorrespondeSeccion">
        <h1>LA SECCION A LA QUE INTENTA ACCEDER NO ESTA HABILITADA PARA EL USUARIO REGISTRADO.</h1>
        <h1>Elija otra sección en el menú de arriba o regrese a la página principal.</h1>
        <asp:Button id="vuelveInicio" runat="server" Text="Volver al inicio" OnClick="vuelveInicio_Click" />
    </div>
</asp:Content>