<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-NotasAlumnos.aspx.cs" Inherits="UI.Web.ABM_NotasAlumnos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:Panel ID="panelCursos" runat="server" >
    <h2>SITUACION ALUMNOS</h2>            
    <h6>Seleccione el curso</h6>
    <asp:GridView ID="gvCursos" runat="server" HorizontalAlign="Center" DataKeyNames="ID" AutoGenerateColumns="False"
                    EmptyDataText="No hay cursos registrados"
                    CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="gvCursos_SelectedIndexChanged" >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Comision" HeaderText="Comisión" />
            <asp:BoundField DataField="Materia" HeaderText="Materia" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="True" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />

<SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Panel>
    <br />
<asp:Panel runat="server" ID="panelAlumnos" >
    <h6>Alumnos que cursan
    <asp:Label ID="etiqMateria" runat="server" Text="Materia" Font-Bold="true"></asp:Label>
    en la comisión
    <asp:Label ID="etiqComision" runat="server" Text="Comisión" Font-Bold="True"></asp:Label>
    <br />
    </h6>
    <asp:GridView ID="gvAlumnos" EmptyDataText="No hay alumnos inscriptos en este curso" DataKeyNames="ID" HorizontalAlign="Center" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnSelectedIndexChanged="gvAlumnos_SelectedIndexChanged">
      <Columns>
        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false" />
        <asp:BoundField DataField="Legajo" HeaderText="Legajo" />
        <asp:BoundField DataField="Alumno" HeaderText="Alumno" />
        <asp:BoundField DataField="Condicion" HeaderText="Condición" />
        <asp:BoundField DataField="Nota" HeaderText="Nota" />
        <asp:CommandField SelectText="Poner nota" ShowSelectButton="True" />
      </Columns>
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
    <asp:LinkButton ID="linkVolverAlInicio" runat="server" OnClick="linkVolverAlInicio_Click">Volver al inicio</asp:LinkButton>

</asp:Content>
