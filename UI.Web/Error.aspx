<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="UI.Web.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert-warning">
        <h1>HA OCURRIDO UN ERRROR AL RECUPERAR LOS DATOS:</h1>
        <asp:Label runat="server" ID="etiqError" ></asp:Label>
        <h1>Por favor, contactese con el Administrador del Sistema.</h1>
        <asp:Button id="vuelveInicio" runat="server" Text="Volver al inicio" OnClick="vuelveInicio_Click" />
    </div>
</asp:Content>
