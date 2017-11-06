<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Personas.aspx.cs" Inherits="UI.Web.ABM_Personas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style12 {
            width: 605px;
        }
        .auto-style19 {
            width: 1404px;
        }
    .auto-style20 {
        width: 687px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="gridPanel" runat="server">
            <h2>ALTA, BAJA Y MODIFICACION DE PERSONAS</h2>
            <br />
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Green"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridView_SelectedIndexChanged" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
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
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    </asp:Panel>   
     
    <br />

<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>
    
    <br />

<asp:Panel ID="panelFormulario" HorizontalAlign="Center" Visible="false" runat="server">
    <table  style="text-align: right; margin:0 auto;">
        <tr >
            <td class="auto-style19">
                <asp:Label ID="etiqNombre" runat="server" Text="Nombre: "></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqApellido" runat="server" Text="Apellido: "></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="El apellido no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqCorreoE" runat="server" Text="Correo electrónico:"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="txtCorreoE" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="validadorCorreoFormato" runat="server" ControlToValidate="txtCorreoE" ErrorMessage="El correo electrónico ingresado es inválido." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="validaciones">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="validadorCorreoVacio" runat="server" ControlToValidate="txtCorreoE" ErrorMessage="El correo eléctronico no puede estar en blanco." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqDireccion" runat="server" Text="Dirección: "></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqTelefono" runat="server" Text="Teléfono:"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqFechaNac" runat="server" Text="Fecha de Nacimiento:"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" ></asp:TextBox>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqLegajo" runat="server" Text="Legajo:"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:TextBox ID="txtLegajo" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqTipoPersona" runat="server" Text="Tipo de persona:"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:DropDownList ID="ddlTipoPersona" runat="server">
                    <asp:ListItem Value="1">Alumno</asp:ListItem>
                    <asp:ListItem Value="2">Profesor</asp:ListItem>
                    <asp:ListItem Value="3">Administrativo</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <asp:Label ID="etiqPlan" runat="server" Text="Plan"></asp:Label>
            </td>
            <td class="auto-style20" style="text-align: left">
                <asp:DropDownList ID="ddlPlan" runat="server">
                </asp:DropDownList>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style19">
                <br />
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="validaciones">Aceptar</asp:LinkButton>
            </td>
            <td class="auto-style20" style="text-align: left">
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </td>
            <td class="auto-style12" style="text-align: left">&nbsp;</td>
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
