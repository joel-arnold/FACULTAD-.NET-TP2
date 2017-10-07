<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Inscripciones.aspx.cs" Inherits="UI.Web.ABM_InscMaterias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Inscripción de alumno a materias</h1>
    <div class="tablas">
        <div>
            <asp:Panel ID="pnlMaterias" runat="server">
                Seleccione la materia a inscribir al alumno
                <asp:Label ID="lblAlumno" runat="server"></asp:Label>
                <asp:GridView ID="gvMaterias" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="El alumno no se puede inscribir a ninguna materia" >
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Materia" />
                        <asp:BoundField DataField="HSSemanales" HeaderText="Horas Semanales">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HSTotales" HeaderText="Horas Totales">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="pnlComision" runat="server" Width="400px">
                Seleccione la comisión a inscribirse de la materia
                <asp:Label ID="lblMateria" runat="server"></asp:Label>
                &nbsp;<asp:GridView ID="gvComisiones" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="No hay comisiones disponibles" >
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Comisión" />
                        <asp:CommandField SelectText="Inscribir" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <asp:LinkButton ID="lbnCancelarComisiones" runat="server" >Volver</asp:LinkButton>
            </asp:Panel>
            <asp:Panel ID="pnlInscripcion" runat="server" Width="200px">
                <asp:Label ID="lblInscripcion" runat="server"></asp:Label>
                <br />
                <asp:LinkButton ID="lbnInscribirseAOtraMateria" runat="server" >Inscribirse a otra materia</asp:LinkButton>
            </asp:Panel>
        </div>
        <asp:ValidationSummary ID="vsAlumno" runat="server" style="margin-top: 0px" ValidationGroup="validacion" />
        <asp:Label ID="lblMensaje" runat="server" CssClass="mensajeError"></asp:Label>
    </div>
</asp:Content>