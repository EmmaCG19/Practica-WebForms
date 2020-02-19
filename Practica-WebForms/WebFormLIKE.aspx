<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormLIKE.aspx.cs" Inherits="Practica_WebForms.WebFormLIKE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="LblLibro" Text="Libro:"/></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtBoxLibro" /></td>
                    <td>
                        <asp:LinkButton runat="server" ID="LinkBtnBuscar" Text="Buscar" OnClick="LinkBtnBuscar_Click"/></td>
                </tr>
                <tr>
                    <td colspan="3"><asp:GridView runat="server" ID="GWAutores"/></td>
                </tr>
                <tr><td colspan="3"><asp:Label runat="server" ID="LblError"/></td></tr>
            </table>
        </div>
    </form>
</body>
</html>
