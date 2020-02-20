<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormMayus.aspx.cs" Inherits="Practica_WebForms.WebFormMayus" %>

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
                    <td><asp:Button ID="BtnConvertir" runat="server" Text="Pasar a mayúsculas los apellidos con DNI == CantidadAdeudada " OnClick="BtnConvertir_Click" /></td>
                </tr>
                <tr>
                    <td><asp:GridView ID="GWEstudiantes" runat="server" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
