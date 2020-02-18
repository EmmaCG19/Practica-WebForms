<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormSPA.aspx.cs" Inherits="Practica_WebForms.WebFormSPA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>SPA: Single-Page Application</h1>
            <asp:Panel runat="server" ID="PanelLogin">
                <asp:Label runat="server" ID="LblClave" Text="Clave:" />
                <asp:TextBox runat="server" ID="TxtBoxClave" />
                <asp:Button runat="server" ID="BtnLogin" Text="Iniciar Sesion" OnClick="BtnLogin_Click" />
                <br />
                <asp:Label runat="server" ID="LblLoginValido"></asp:Label>
            </asp:Panel>
            <asp:Panel runat="server" ID="PanelBase64">
                <asp:LinkButton runat="server" ID="LinkBtnCerrar" Text="Cerrar Sesión" OnClick="LinkBtnCerrar_Click" />
                <br />
                <table>
                    <tr>
                        <td><asp:Label runat="server" ID="LblTextSinCodif" Text="Texto Sin Codificar." /></td>
                        <td></td>
                        <td><asp:Label runat="server" ID="LblTextCodif" Text="Texto Codificado." /></td>
                    </tr>
                    <tr>
                        <td><asp:TextBox runat="server" ID="TxtBoxSinCodif"/></td>
                        <td><asp:Button runat="server" ID="BtnCodificar" Text="Codificar a Base64" OnClick="BtnCodificar_Click" /></td>
                        <td><asp:TextBox runat="server" ID="TxtBoxCodif"/></td>
                    </tr>
                </table>
                
            </asp:Panel>
        </div>
    </form>
</body>
</html>
