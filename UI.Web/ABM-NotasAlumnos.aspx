<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-NotasAlumnos.aspx.cs" Inherits="UI.Web.ABM_NotasAlumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelCursos" runat="server" CssClass="etiquetas">
                Seleccione el curso
    <asp:GridView ID="gvCursos" runat="server" DataKeyNames="ID" AutoGenerateColumns="False"
                    EmptyDataText="No hay cursos registrados"
                    CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvCursos_SelectedIndexChanged" >
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Comision" HeaderText="Comisión" />
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
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
</asp:Panel>
    <br />
<asp:Panel runat="server" ID="panelAlumnos" CssClass="etiquetas">
    Alumnos que cursan
    <asp:Label ID="etiqMateria" runat="server" Text="Materia" Font-Bold="true"></asp:Label>
    &nbsp; en la comisión &nbsp;
    <asp:Label ID="etiqComision" runat="server" Text="Comisión" Font-Bold="True"></asp:Label>
    <br />
    <asp:GridView ID="gvAlumnos" DataKeyNames="ID" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAlumnos_SelectedIndexChanged">
      <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
        <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
        <asp:BoundField DataField="Alumno" HeaderText="Alumno" />
        <asp:BoundField DataField="Condicion" HeaderText="Condición" />
        <asp:BoundField DataField="Nota" HeaderText="Nota" />
        <asp:CommandField SelectText="Poner nota" ShowSelectButton="True" />
      </Columns>
        <AlternatingRowStyle BackColor="White" />
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
</asp:Panel>

    <br />
<asp:Panel runat="server" ID="panelNota">
        <asp:Label ID="etiqNota" runat="server" Text="Nota"></asp:Label>
        &nbsp;
        <asp:TextBox ID="txtNota" runat="server" Width="42px"></asp:TextBox>
        &nbsp;
        <br />
        <asp:LinkButton ID="btnConfirmarNota" runat="server" OnClick="btnConfirmarNota_Click" Text="Confirmar nota"></asp:LinkButton>
        <br />
        <asp:Label ID="etiqValidacionNota" runat="server" ForeColor="Red" Text="La nota debe estar entre 1 y 10" Visible="False"></asp:Label>
</asp:Panel>
    <br />
    <asp:LinkButton ID="linkVolverAlInicio" runat="server" CssClass="etiquetas" OnClick="linkVolverAlInicio_Click">Volver al inicio</asp:LinkButton>

</asp:Content>
