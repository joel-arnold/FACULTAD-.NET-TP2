<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-NotasAlumnos.aspx.cs" Inherits="UI.Web.ABM_NotasAlumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvCursos" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                    EmptyDataText="No hay cursos registrados"
                    SelectedRowStyle-BackColor="Green"
                    SelectedRowStyle-ForeColor="White" CellPadding="4" ForeColor="#333333" GridLines="None" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Comision" HeaderText="Comisión" />
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
        </Columns>
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />

<SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    <br />
    <asp:GridView ID="gvAlumnos" runat="server">
    </asp:GridView>
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Width="42px"></asp:TextBox>
</asp:Content>
