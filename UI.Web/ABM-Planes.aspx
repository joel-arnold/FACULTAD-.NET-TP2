<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style1 {
        margin-left: 150;
    }
    .auto-style2 {
        width: 478px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
<asp:Panel ID="gridPanelPlanes" runat="server" >
    <h2>ALTA, BAJA Y MODIFICACION DE PLANES</h2>
    <br />
        <asp:GridView ID="gridViewPlanes" runat="server" HorizontalAlign="Center" AutoGenerateColumns ="False" class="tablas"
                    onselectedindexchanged="gridViewPlanes_SelectedIndexChanged" DataKeyNames="ID" 
                    EmptyDataText="No hay planes registrados"
                    SelectedRowStyle-BackColor="Green"
                    SelectedRowStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None" >
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ID" HeaderText="ID Plan"></asp:BoundField>
                        <asp:BoundField DataField="Especialidad" HeaderText="Especialidad"></asp:BoundField>
                        <asp:BoundField DataField="Plan" HeaderText="Plan" />
                        <asp:CommandField ShowSelectButton="True" />
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
<asp:Panel ID="gridActionsPanelPlanes" HorizontalAlign="center" runat="server" >
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar </asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click"> Eliminar </asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click"> Nuevo</asp:LinkButton>
</asp:Panel>
    <br />
<asp:Panel ID="formPanel" Visible="false" runat="server" >
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2" style="text-align: right">
                <asp:Label ID="etiqIdPlan" runat="server" Text="ID Plan: "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="idTextBox" runat="server" CssClass="auto-style1"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2" style="text-align: right">
                <asp:Label ID="etiqDescripcion" runat="server" Text="Descripción "></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="descripcionTextBox" runat="server" Width="114px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validadorDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Debe completar la descripción." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2" style="text-align: right">
                <asp:Label ID="etiqEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
            </td>
            <td style="text-align: left">
                <asp:DropDownList ID="ddlEspecialidad" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style2" style="text-align: right">
                <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click" ValidationGroup="validaciones">Aceptar</asp:LinkButton>
            </td>
            <td style="text-align: left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="formActionsPanel" runat="server">    
    <br />
    </asp:Panel>
</asp:Panel>
    
    
    <br />
    <asp:ValidationSummary ID="sumarioValidacione" runat="server" BorderStyle="Dotted" ForeColor="Red" ValidationGroup="validaciones" />
</div>
</asp:Content>