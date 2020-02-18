<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AutoPostBack.aspx.cs" Inherits="Practica_WebForms.AutoPostBack" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style>
    th{

        border:1px black solid;
        background-color: aquamarine;
        font-size: 30px;
    }

</style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <th>
                        Autores Argentinos
                    </th>
                    <th>
                        Seleccionados:
                    </th>
                </tr>
                <tr>
                    <td>
                        <asp:CheckBoxList runat="server" ID="ChckBoxListAutores" OnSelectedIndexChanged="ChckBoxListAutores_SelectedIndexChanged"/></td>

                    <td>
                        <asp:TextBox TextMode="MultiLine" runat="server" ID="TxtBoxSeleccionados"/></td>
                </tr>
            </table>


        </div>
    </form>
</body>
</html>
