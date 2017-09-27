<%@ Page Title="Sistema Academia (TP2 .NET)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="pagPrincipal">
        <h1>BIENVENIDO AL SISTEMA ACADEMIA</h1>
        <h3>(Trabajo Práctico Nº 2 de la materia .NET)</h3>
        <br />
        <br />
        <h5>Haga clic en el botón <span id="ingresar">Ingresar</span> para iniciar sesión y poder acceder a toda la funcionalidad el sistema.</h5>
        <asp:Button id="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar"/>
    </div>
</asp:Content>
