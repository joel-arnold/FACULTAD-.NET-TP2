<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Personas.aspx.cs" Inherits="UI.Web.ABM_Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Green"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="ID Persona" DataField="ID" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Tipo persona" DataField="Tipo" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
            <SelectedRowStyle BackColor="Green" ForeColor="White" />
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
    <asp:Label ID="etiquetaDireccion" runat="server" Text="Dirección: "></asp:Label>
    <asp:TextBox ID="direccionTextBox" runat="server"></asp:TextBox>
    <br />
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
