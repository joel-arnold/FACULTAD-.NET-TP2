<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <h2>ESTADO ACADEMICO</h2>   
        <h6>
        <asp:Label ID="etiqTitulo" runat="server" Text="Estado académico del alumno " ></asp:Label>
        <asp:Label ID="etiqAlumno" runat="server" Text="Alumno" Font-Bold="True"></asp:Label>
        <asp:Label ID="etiqX" runat="server" Text="al"></asp:Label>
        <asp:Label ID="etiqFecha" runat="server" Font-Bold="True" Text="DiaMesAño"></asp:Label>
        </h6>
        <br />
        

                    <div class="col-sm-auto text-center"> 
                    <div class="center-block text-center" aria-autocomplete="none" aria-expanded="undefined" aria-flowto="center">
                    
                        
<asp:Panel ID="panelGrilla" runat="server">
<div>
<asp:GridView ID="gvEstadoAcademico" runat="server" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" EmptyDataText="El alumno no está inscripto a ninguna materia">
    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    <SortedAscendingCellStyle BackColor="#F7F7F7" />
    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
    <SortedDescendingCellStyle BackColor="#E5E5E5" />
    <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
</div>
</asp:Panel>

                        
                    </div>
                    </div>

        
        <br />
        <br />
        <asp:LinkButton ID="btnVolver" runat="server" OnClick="btnVolver_Click">Volver al inicio</asp:LinkButton>

</asp:Content>
