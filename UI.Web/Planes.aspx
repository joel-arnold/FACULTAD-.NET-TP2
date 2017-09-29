<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Planes.aspx.cs" Inherits="UI.Web.Planes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="gridPanelPlanes" runat="server">
        <asp:GridView ID="gridViewPlanes" runat="server" AutoGenerateColumns="false"
        SelectedRowStyle-BackColor="Blue"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" OnSelectedIndexChanged="gridViewPlanes_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="ID Plan" DataField="ID" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Especialidad" DataField="Descripcion" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
        </Columns>
    </asp:GridView>
</asp:Panel>
    
    
    <br />

<asp:Panel ID="gridActionsPanelPlanes" runat="server">
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" OnClick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>
    
    <br />

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <asp:Label ID="etiqIdPlan" runat="server" Text="ID Plan: "></asp:Label>
    <asp:TextBox ID="idTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="etiqDescripcion" runat="server" Text="Descripción "></asp:Label>
    <asp:TextBox ID="descripcionTextBox" runat="server" Width="114px"></asp:TextBox>
    <br />
<asp:Panel ID="formActionsPanel" runat="server">
    <asp:Label ID="etiqEspecialidad" runat="server" Text="Especialidad:"></asp:Label>
    <asp:TextBox ID="especialidadTextBox" runat="server"></asp:TextBox>
</asp:Panel>
</asp:Panel>
    <br />
    <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
    <asp:LinkButton ID="cancelarLinkButton" runat="server" OnClick="cancelarLinkButton_Click">Cancelar</asp:LinkButton>
    <br />
</asp:Content>
