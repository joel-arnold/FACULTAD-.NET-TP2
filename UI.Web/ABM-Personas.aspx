<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Personas.aspx.cs" Inherits="UI.Web.ABM_Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style8 {
            width: 511px;
        }
        .auto-style9 {
            width: 587px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="gridPanel" runat="server">
            <asp:Label runat="server">Alta, Baja y Modificación de Personas</asp:Label>
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Green"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="ID Persona" DataField="ID" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Dirección" DataField="Direccion" />
            <asp:BoundField HeaderText="Correo electrónico" DataField="Email" />
            <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
            <asp:BoundField HeaderText="Fecha de nacimiento" DataField="FechaNacimiento" DataFormatString="{0:d}" />
            <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
            <asp:BoundField HeaderText="Tipo de persona" DataField="Tipo" />
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
    <table style="text-align: right; margin-right: 300px;">
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqNombre" runat="server" Text="Nombre: "></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqApellido" runat="server" Text="Apellido: "></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqCorreoE" runat="server" Text="Correo electrónico:"></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:TextBox ID="txtCorreoE" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="validadorCorreoFormato" runat="server" ControlToValidate="txtCorreoE" ErrorMessage="El correo electrónico ingresado es inválido." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validaciones">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="validadorCorreoVacio" runat="server" ControlToValidate="txtCorreoE" ErrorMessage="El correo eléctronico no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqDireccion" runat="server" Text="Dirección: "></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqTelefono" runat="server" Text="Teléfono:"></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqFechaNac" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqLegajo" runat="server" Text="Legajo:"></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqTipoPersona" runat="server" Text="Tipo de persona:"></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:DropDownList ID="ddlTipoPersona" runat="server">
                    <asp:ListItem Value="1">Alumno</asp:ListItem>
                    <asp:ListItem Value="2">Profesor</asp:ListItem>
                    <asp:ListItem Value="3">Administrativo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="etiqPlan" runat="server" Text="Plan"></asp:Label>
            </td>
            <td class="auto-style9" style="text-align: left">
                <asp:DropDownList ID="ddlPlan" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                <br />
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="validaciones">Aceptar</asp:LinkButton>
            </td>
            <td class="auto-style9" style="text-align: left">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </td>
        </tr>
    </table>
    <br />
<asp:Panel ID="formActionsPanel" runat="server">
</asp:Panel>
</asp:Panel>
    <br />
    <asp:ValidationSummary ID="sumarioDeValidacion" runat="server" ForeColor="Red" BorderStyle="Dotted" HeaderText="Listado de errorres:" ValidationGroup="validaciones" />
    <br />
</asp:Content>
