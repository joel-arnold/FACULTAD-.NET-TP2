<%@ Page Title="Usuarios" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
        margin-left: 108;
    }
    .auto-style4 {
        width: 467px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>ALTA, BAJA Y MODIFICACION DE USUARIOS</h2>
    <br />
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" HorizontalAlign="Center" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Green"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
            <asp:BoundField HeaderText="Email" DataField="Email" />
            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
            <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    </asp:Panel>
    
    
    <br />

<asp:Panel ID="gridActionsPanel" HorizontalAlign="Center" runat="server">
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar </asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click"> Eliminar </asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click"> Nuevo</asp:LinkButton>
</asp:Panel>
    
    <br />

<asp:Panel ID="panelFormulario" Visible="false" runat="server">
    <table style="text-align:right; width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorNombre" runat="server" ControlToValidate="nombreTextBox" ErrorMessage="El nombre no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorApellido" runat="server" ControlToValidate="apellidoTextBox" ErrorMessage="El apellido no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="emailLabel" runat="server" Text="Email: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorCorreoVacio" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El correo eléctronico no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="validadorCorreoFormato" runat="server" ControlToValidate="emailTextBox" ErrorMessage="El correo electrónico ingresado es inválido." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validaciones">*</asp:RegularExpressionValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:CheckBox ID="habilitadoCheckBox" runat="server" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorUsuario" runat="server" ControlToValidate="nombreUsuarioTextBox" ErrorMessage="El nombre de usuario no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="etiqPersona" runat="server" Text="Persona: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlPersonas" runat="server" DataSourceID="SqlDataSourcePersonas" DataTextField="apellido" DataValueField="id_persona">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="etiqPrivilegio" runat="server" Text="Privilegio"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlPrivilegio" runat="server">
                    <asp:ListItem Value="alumno">Alumno</asp:ListItem>
                    <asp:ListItem Value="profesor">Profesor</asp:ListItem>
                    <asp:ListItem Value="admin">Administrativo</asp:ListItem>
                    <asp:ListItem>Seleccionar</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="claveTextBox" runat="server" TextMode="Password" Width="157px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorClaveVacia" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
                <asp:CustomValidator ID="validadorTamanioClave" runat="server" ControlToValidate="claveTextBox" ErrorMessage="La clave debe contener al menos 8 caracteres" ForeColor="Red" OnServerValidate="validadorTamanioClave_ServerValidate" ValidationGroup="validaciones">*</asp:CustomValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:Label ID="repetirClaveLabel" runat="server" Text="Repetir clave: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="repetirClaveTextBox" runat="server" TextMode="Password" CssClass="auto-style2"></asp:TextBox>
                <asp:CompareValidator ID="validadorClavesCoinciden" runat="server" ControlToCompare="repetirClaveTextBox" ControlToValidate="claveTextBox" ErrorMessage="Las claves ingresadas no coinciden." ForeColor="Red" ValidationGroup="validaciones">*</asp:CompareValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td dir="auto" class="auto-style4">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="validaciones">Aceptar</asp:LinkButton>
            </td>
            <td style="text-align: left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:SqlDataSource ID="SqlDataSourcePersonas" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringLocal %>" SelectCommand="SELECT [id_persona], [apellido], [nombre] FROM [personas]"></asp:SqlDataSource>
    <br />
<asp:Panel ID="formActionsPanel" runat="server">
</asp:Panel>
</asp:Panel >
    <br />
    <asp:ValidationSummary ID="sumarioDeValidacion" runat="server" ForeColor="Red" BorderStyle="Dotted" HeaderText="Listado de errorres:" ValidationGroup="validaciones" />
    <br />
</asp:Content>