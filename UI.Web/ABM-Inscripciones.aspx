<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Inscripciones.aspx.cs" Inherits="UI.Web.ABM_Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style6 {
            width: 100%;
            margin-right: 0px;
        }
        .auto-style8 {
            text-align: right;
            width: 154px;
        }
        .auto-style9 {
            text-align: left;
            width: 186px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanelInscripciones" runat="server">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="358px" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID Inscripcion" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                <asp:BoundField DataField="Materia" HeaderText="Materia" />
                <asp:BoundField DataField="Comision" HeaderText="Comision" />
                <asp:BoundField DataField="Anio" HeaderText="Año de cursado" />
                <asp:CommandField ButtonType="Button" ShowSelectButton="true" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="gridActionsPanelInscripciones" runat="server">
    <asp:LinkButton ID="editarLinkButton" runat="server" CssClass="botones" >Editar</asp:LinkButton>
        &nbsp;
    <asp:LinkButton ID="eliminarLinkButton" runat="server" CssClass="botones" >Eliminar</asp:LinkButton>
        &nbsp;
    <asp:LinkButton ID="nuevoLinkButton" runat="server" CssClass="botones" >Nuevo</asp:LinkButton>
        <br />
        <br />
</asp:Panel>
    
    <table class="auto-style6">
        <tr>
            <td aria-atomic="False" aria-autocomplete="none" class="auto-style8" colspan="1" dir="ltr" rowspan="1">
    <asp:Label ID="etiqIdInscripcion" runat="server" Text="ID Inscripción: " CssClass="etiquetas"></asp:Label>
            </td>
            <td class="auto-style9">
    <asp:TextBox ID="idTextBox" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="1" dir="ltr" rowspan="1">
    <asp:Label ID="etiqAlumno" runat="server" Text="Alumno: " CssClass="etiquetas"></asp:Label>
            </td>
            <td class="auto-style9">
                <asp:DropDownList ID="ddlAlumnos" runat="server" >
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="1" dir="ltr" rowspan="1">
    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="etiquetas"></asp:Label>
            </td>
            <td class="auto-style9">
    <asp:TextBox ID="descripcionTextBox3" runat="server" Width="114px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="1" dir="ltr">
    <asp:Label ID="Label4" runat="server" Text="Label" CssClass="etiquetas"></asp:Label>
            </td>
            <td class="auto-style9">
    <asp:TextBox ID="descripcionTextBox4" runat="server" Width="114px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="1" dir="ltr">&nbsp;</td>
            <td class="auto-style9">
    <asp:TextBox ID="descripcionTextBox2" runat="server" Width="114px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="1" dir="ltr">&nbsp;</td>
            <td class="auto-style9">
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8" colspan="1" dir="ltr">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

<asp:Panel ID="formPanel" Visible="true" runat="server">
    <asp:Panel ID="formActionsPanel" runat="server">    
    <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="validaciones" runat="server" CssClass="botones" >Aceptar</asp:LinkButton>
        &nbsp;<asp:LinkButton ID="cancelarLinkButton" runat="server" CssClass="botones" >Cancelar</asp:LinkButton>
    <br />
    </asp:Panel>
</asp:Panel>
    
    <br />
    
    <%--<asp:ValidationSummary ID="sumarioValidacione" runat="server" BorderStyle="Dotted" ForeColor="Red" ValidationGroup="validaciones" />--%>

</asp:Content>
