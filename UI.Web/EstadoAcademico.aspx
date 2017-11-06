<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EstadoAcademico.aspx.cs" Inherits="UI.Web.EstadoAcademico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server">
        <asp:Label ID="etiqTitulo" runat="server" Text="Estado académico del alumno " ></asp:Label>
        <asp:Label ID="etiqAlumno" runat="server" Text="Alumno" Font-Bold="True"></asp:Label>
        <asp:Label ID="etiqX" runat="server" Text="al"></asp:Label>
        <asp:Label ID="etiqFecha" runat="server" Font-Bold="True" Text="DiaMesAño"></asp:Label>
        <br />
        
        <div class="clearfix">
            <div class="justify-content-center text-center">
                <asp:GridView ID="gvEstadoAcademico" runat="server"></asp:GridView>
            </div>
        </div>
                
        <br />
        <br />
        <asp:LinkButton ID="btnVolver" runat="server" CssClass="etiquetas">Volver al inicio</asp:LinkButton>

    </asp:Panel>
</asp:Content>
