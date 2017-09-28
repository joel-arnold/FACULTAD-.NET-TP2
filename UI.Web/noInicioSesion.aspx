<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="noInicioSesion.aspx.cs" Inherits="UI.Web.noInicioSesion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="noInicioSesion">
        <h1>USTED NO HA INICIADO SESION O NO TIENE LOS PRIVILEGIOS SUFICIENTES PARA ESTA SECCION.</h1>
        <h1>Por favor, si no ha iniciado sesión aún, hágalo ahora.</h1>
        <asp:Button id="inicioSesion" runat="server" Text="Inicio de sesión" OnClick="inicioSesion_Click"/>
    </div>
</asp:Content>
