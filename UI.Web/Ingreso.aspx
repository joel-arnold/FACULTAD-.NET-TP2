<%@ Page Title="Ingreso de usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ingreso.aspx.cs" Inherits="UI.Web.Ingreso" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

      <form class="form-signin">
        <h2 class="form-signin-heading">Inicie Sesión</h2>
        <label for="inputEmail" class="sr-only">Usuario</label>
        <asp:TextBox runat="server" id="correoE" class="form-control" placeholder="Nombre de usuario" required autofocus></asp:TextBox>
        <label for="inputPassword" class="sr-only">Contraseña</label>
        <asp:TextBox runat="server" type="password" id="contrasena" class="form-control" placeholder="Password" required></asp:TextBox>
        <div class="checkbox">
            <asp:Label ID="etiqIngresoIncorrecto" Visible="false" runat="server" ForeColor="Red" Text="Usuario y/o contraseña incorrectos"></asp:Label>
            <br />
          <label>
            <input type="checkbox" value="remember-me"> Recordarme
          </label>
        </div>
        <asp:Button runat="server" class="btn btn-lg btn-primary btn-block"  Text="Iniciar sesión" ID="btnIniciarSesion" OnClick="btnIniciarSesion_Click" />
      </form>

    </div>

</asp:Content>
