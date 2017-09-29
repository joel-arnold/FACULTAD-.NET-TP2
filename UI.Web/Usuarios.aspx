<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="false"
        SelectedRowStyle-BackColor="Green"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
</asp:Panel>
    
    
    <br />

<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>
    
    <br />

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
<%--<asp:RequiredFieldValidator id="ValidadorNombre" runat="server"
      ControlToValidate="nombreTextBox"
      ErrorMessage="El nombre es un campo obligatorio."
      ForeColor="Red">
    </asp:RequiredFieldValidator>--%>
    <asp:Label ID="etiqErrorNombre" runat="server" ForeColor="Red" Text="*"></asp:Label>
    <br />
    <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
    <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="etiqErrorApellido" runat="server" ForeColor="Red" Text="*"></asp:Label>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="etiqErrorEmail" runat="server" ForeColor="Red" Text="*"></asp:Label>
    <asp:Label ID="etiqErrorFormaEmail" runat="server" ForeColor="Red"></asp:Label>
    <br />
    <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
    <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
    <br />
    <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
    <asp:Label ID="etiqErrorUsuario" runat="server" ForeColor="Red" Text="*"></asp:Label>
    <br />
    <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Label ID="etiqErrorClave" runat="server" ForeColor="Red" Text="*"></asp:Label>
    <br />
    <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
    <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <asp:Label ID="etiqErrorClavesCoinciden" runat="server" ForeColor="Red" Text="*"></asp:Label>
    <br />
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
</asp:Panel>
</asp:Panel>
    <br />
    <br />
</asp:Content>