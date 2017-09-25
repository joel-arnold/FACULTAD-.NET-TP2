<%@ Page Title="Sistema Academia (TP2 .NET)" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI.Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
    
        <asp:Label ID="lblBienvenido" runat="server" Text="Bienvenido al sistema"></asp:Label>
                </td>
                <td dir="rtl">
        <asp:Label ID="lblUsuario" runat="server" Text="Usuario"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="txtUsuario" runat="server" BorderStyle="Groove"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td dir="rtl">
        <asp:Label ID="lblClave" runat="server" Text="Clave"></asp:Label>
                </td>
                <td style="margin-left: 80px">
        <asp:TextBox ID="txtClave" runat="server" BorderStyle="Solid"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
        <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar" />
                </td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
                <td>
        <asp:LinkButton ID="lnkRecordarClave" runat="server" OnClick="lnkRecordarClave_Click">Olvidé mi clave</asp:LinkButton>    
                </td>
            </tr>
        </table>

</asp:Content>
