<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormParcial.aspx.cs" Inherits="Practica_WebForms.WebFormParcial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Parcial PII - WebForms</title>
    <style>
        .botones {
            width:auto;
            display:inline-block;
        }

        .error{
            color: red;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="botones">
            <asp:LinkButton runat="server" ID="LinkBtnGuardar" Text="Guardar" OnClick="LinkBtnGuardar_Click" />
            <asp:LinkButton runat="server" ID="LinkBtnCargar" Text="Cargar Ficha por Id" OnClick="LinkBtnCargar_Click" />
            <asp:LinkButton runat="server" ID="LinkBtnEliminar" Text="Eliminar por Id" OnClick="LinkBtnEliminar_Click" />
            <asp:LinkButton runat="server" ID="LinkBtnBuscar" Text="Buscar por apellido" OnClick="LinkBtnBuscar_Click" />
            <asp:LinkButton runat="server" ID="LinkBtnInicializar" Text="Inicializar con (Sadosky, Balseiro)" OnClick="LinkBtnInicializar_Click" />
            <asp:LinkButton runat="server" ID="LinkBtnRenumerar" Text="Renumerar por Id" />
        </div>
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="LblId" Text="Id:"/></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtBoxId" /></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label runat="server" ID="LblApellido" Text="Apellido"/></td>
                    <td>
                        <asp:TextBox runat="server" ID="TxtBoxApellido" /></td>
                </tr>
            </table>
        </div>
        <div>
            <asp:GridView ID="GWCientificos" runat="server" />
        </div>
        <span class="error"><asp:Label runat="server" ID="LblError"/></span>
        <div>
            <h1>Apellido, Nombre</h1>
        </div>
    </form>
</body>
</html>
