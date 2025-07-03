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
            &nbsp;<strong><asp:Label ID="lblUsuarios" runat="server" ForeColor="#006600" Text="Usuario:"></asp:Label>
            </strong>&nbsp;<strong><asp:Label ID="lblUsuario" runat="server" ForeColor="Black"></asp:Label>
            </strong>
            <br /><br />
            <asp:Label ID="lblInformes" runat="server" Text="Informes" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <h3>Cantidad de ausentes en el año 2025</h3>
            <asp:GridView ID="gvInforme1" runat="server"></asp:GridView>
            <br />
            <br />
            <h3>Cantidad de Medicos por Especialidad</h3>
            <asp:GridView ID="gvInformeEspecialidad" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
