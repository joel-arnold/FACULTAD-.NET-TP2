<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Inscripciones.aspx.cs" Inherits="UI.Web.ABM_Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" DataKeyNames="id_inscripcion" DataSourceID="SqlOrigenDatos" GridLines="Horizontal">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="id_inscripcion" HeaderText="id_inscripcion" InsertVisible="False" ReadOnly="True" SortExpression="id_inscripcion" />
            <asp:BoundField DataField="id_alumno" HeaderText="id_alumno" SortExpression="id_alumno" />
            <asp:BoundField DataField="id_curso" HeaderText="id_curso" SortExpression="id_curso" />
            <asp:BoundField DataField="condicion" HeaderText="condicion" SortExpression="condicion" />
            <asp:BoundField DataField="nota" HeaderText="nota" SortExpression="nota" />
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlOrigenDatos" runat="server" ConnectionString="Data Source=localhost;Initial Catalog=tp2_net;Integrated Security=False;User ID=net;Password=net" DeleteCommand="DELETE FROM [alumnos_inscripciones] WHERE [id_inscripcion] = @id_inscripcion" InsertCommand="INSERT INTO [alumnos_inscripciones] ([id_alumno], [id_curso], [condicion], [nota]) VALUES (@id_alumno, @id_curso, @condicion, @nota)" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [alumnos_inscripciones]" UpdateCommand="UPDATE [alumnos_inscripciones] SET [id_alumno] = @id_alumno, [id_curso] = @id_curso, [condicion] = @condicion, [nota] = @nota WHERE [id_inscripcion] = @id_inscripcion">
        <DeleteParameters>
            <asp:Parameter Name="id_inscripcion" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="id_alumno" Type="Int32" />
            <asp:Parameter Name="id_curso" Type="Int32" />
            <asp:Parameter Name="condicion" Type="String" />
            <asp:Parameter Name="nota" Type="Int32" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="id_alumno" Type="Int32" />
            <asp:Parameter Name="id_curso" Type="Int32" />
            <asp:Parameter Name="condicion" Type="String" />
            <asp:Parameter Name="nota" Type="Int32" />
            <asp:Parameter Name="id_inscripcion" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    
</asp:Content>
