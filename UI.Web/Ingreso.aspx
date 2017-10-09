<%@ Page Title="Ingreso de usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="UI.Web.Ingreso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="etiqNombre" runat="server" Text="No trajo nada"></asp:Label>
    <asp:Login ID="Login1" runat="server" onauthenticate="IngresoAutenticacion" LoginButtonText="Ingresar" PasswordLabelText="Contraseña:" RememberMeText="Recordarme la proxima vez." TitleText=""
    UserNameLabelText="Usuario:"> </asp:Login>
</asp:Content>
