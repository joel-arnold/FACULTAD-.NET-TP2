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

<asp:Panel ID="panelFormulario" Visible="false" runat="server">
    <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
    <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validadorNombre" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar en blanco." ValidationGroup="validaciones" ForeColor="Red">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
    <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validadorApellido" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="validadorCorreoFormato" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El correo electrónico ingresado es inválido." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validaciones">*</asp:RegularExpressionValidator>
    <asp:RequiredFieldValidator ID="validadorCorreoVacio" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El correo eléctronico no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
    <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
    <br />
    <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
    <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validadorUsuario" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
    <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server" Width="157px"></asp:TextBox>
    <asp:CustomValidator ID="validadorTamanioClave" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave debe contener al menos 8 caracteres" ForeColor="Red" OnServerValidate="validadorTamanioClave_ServerValidate" ValidationGroup="validaciones">*</asp:CustomValidator>
    <asp:RequiredFieldValidator ID="validadorClaveVacia" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
    <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
    <asp:CompareValidator ID="validadorClavesCoinciden" runat="server" ControlToCompare="repetirClaveTextBox" ControlToValidate="claveTextBox" ErrorMessage="Las claves ingresadas no coinciden." ForeColor="Red" ValidationGroup="validaciones">*</asp:CompareValidator>
    <br />
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:LinkButton ID="aceptarLinkButton" runat="server" ValidationGroup="validaciones" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
</asp:Panel>
</asp:Panel>
    <br />
    <asp:ValidationSummary ID="sumarioDeValidacion" runat="server" ForeColor="Red" BorderStyle="Dotted" HeaderText="Listado de errorres:" ValidationGroup="validaciones" />
    <br />
</asp:Content>