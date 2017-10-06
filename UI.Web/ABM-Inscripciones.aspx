<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Inscripciones.aspx.cs" Inherits="UI.Web.ABM_Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>
    
    <br />

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="etiqIdInscripcion" runat="server" Text="ID Inscripción: "></asp:Label>
    <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="nombre" runat="server" Text="Descripción "></asp:Label>
    <asp:TextBox ID="descripcionTextBox" runat="server" Width="114px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="validadorDescripcion" runat="server" ControlToValidate="descripcionTextBox" ErrorMessage="Debe completar la descripción." ForeColor="Red" ValidationGroup="validaciones">*</asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="etiqEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
    <asp:DropDownList ID="ddlEspecialidad" runat="server">
    </asp:DropDownList>
    <br />
    <asp:Panel ID="formActionsPanel" runat="server">    
    <asp:LinkButton ID="aceptarLinkButton" ValidationGroup="validaciones" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    <br />
    </asp:Panel>
</asp:Panel>
    
    <br />
    
    <asp:ValidationSummary ID="sumarioValidacione" runat="server" BorderStyle="Dotted" ForeColor="Red" ValidationGroup="validaciones" />

</asp:Content>
