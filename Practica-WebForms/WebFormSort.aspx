<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormSort.aspx.cs" Inherits="Practica_WebForms.WebFormSort" %>

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
                        <asp:Label runat="server" ID="LblOrdenar" Text="Ordenar Por:" /></td>
                    <td>
                        <asp:DropDownList runat="server" ID="DropDownCampos" AutoPostBack="true" OnSelectedIndexChanged="DropDownCampos_SelectedIndexChanged" /></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView runat="server" ID="GWAutores" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="color: forestgreen;">
                        <asp:Label runat="server" ID="LblMensajeOrden" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
