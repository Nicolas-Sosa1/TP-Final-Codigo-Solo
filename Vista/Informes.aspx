<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vista.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlVolverPanelAdmin" runat="server" NavigateUrl="~/PanelUsuarioAdministrador.aspx">Panel de Administrador</asp:HyperLink>
            <br /><br />
            <asp:Label ID="lblInformes" runat="server" Text="Informes" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            <asp:Button ID="btnInforme1" runat="server" Text="Informe ejemplo 1" />
            <br />
            <asp:GridView ID="gvInforme1" runat="server"></asp:GridView>
            <br /><br />
            <asp:Button ID="btnInforme2" runat="server" Text="Informe ejemplo 2" />
            <br />
            <asp:GridView ID="gvInforme2" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
