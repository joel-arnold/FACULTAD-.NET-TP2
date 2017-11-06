<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ABM-Inscripciones.aspx.cs" Inherits="UI.Web.ABM_Inscripciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>INSCRIPCION A MATERIAS</h2>
    <div class="text-center">
        <div class="table-responsive-md">
            <asp:Panel ID="pnlMaterias" runat="server" HorizontalAlign="Center">
                <h6>Seleccione la materia a inscribir al alumno
                <asp:Label ID="lblAlumno" runat="server" Text="alummno"></asp:Label></h6>
                <br />
                <asp:GridView ID="gvMaterias" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="El alumno no se puede inscribir a ninguna materia" OnSelectedIndexChanged="gvMaterias_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
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
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="pnlComision" HorizontalAlign="Center" runat="server">
                <br />
                <h6>Seleccione la comisión a inscribirse para la materia&nbsp<asp:Label ID="lblMateria" runat="server"></asp:Label></h6>
                <asp:GridView ID="gvComisiones" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" DataKeyNames="ID" EmptyDataText="No hay comisiones disponibles" OnSelectedIndexChanged="gvComisiones_SelectedIndexChanged" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Comisión" />
                        <asp:CommandField SelectText="Inscribir" ShowSelectButton="True" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#3399FF" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <asp:Label ID="etiqYaInscripto" runat="server" ForeColor="Red" Text="El alumno ya está inscripto a esta materia" Visible="False" Font-Bold="True"></asp:Label>
                <br />
            </asp:Panel>
            <asp:Panel ID="pnlInscripcion" runat="server" HorizontalAlign="Center">
                <asp:Label ID="lblInscripcion" runat="server" Font-Bold="True" ForeColor="Green"></asp:Label>
                <br />
                <asp:LinkButton ID="lbnInscribirseAOtraMateria" runat="server" OnClick="lbnInscribirseAOtraMateria_Click" >Inscribirse a otra materia</asp:LinkButton>
                <br />
                <asp:LinkButton ID="lbnCancelarComisiones" runat="server" OnClick="lbnCancelarComisiones_Click">Volver</asp:LinkButton>
            </asp:Panel>
        </div>
    </div>
</asp:Content>