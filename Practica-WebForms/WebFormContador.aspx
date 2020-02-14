<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormContador.aspx.cs" Inherits="Practica_WebForms.WebFormContador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label runat="server" ID="LblContador" Enabled="false"/>
            <br/>
            <asp:LinkButton runat="server" ID="BtnIncrementar">Guardar en base de datos e incrementar</asp:LinkButton>
        </div>
    </form>
</body>
</html>
