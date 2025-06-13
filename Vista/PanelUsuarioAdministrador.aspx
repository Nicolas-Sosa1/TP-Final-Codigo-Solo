<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelAdministrador.aspx.cs" Inherits="Vista.PanelAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblAdmin" runat="server" Text="Panel de Administrador" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            Usuario:&nbsp;&nbsp;
            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
            <br /><br />
            <asp:Button ID="btnPacientes" runat="server" Text="ABML Pacientes" Width="200px" OnClick="btnPacientes_Click" />
            <br /><br />
            <asp:Button ID="btnMedicos" runat="server" Text="ABML Medicos" Width="200px" OnClick="btnMedicos_Click" />
            <br /><br />
            <asp:Button ID="btnTurnos" runat="server" Text="Asignación de turnos" Width="200px" OnClick="btnTurnos_Click" />
            <br /><br />
            <asp:Button ID="btnInformes" runat="server" Text="Informes" Width="200px" OnClick="btnInformes_Click" />
            <br /><br /><br />
            <asp:HyperLink ID="hlLogOut" runat="server" NavigateUrl="~/Inicio.aspx">Cerrar sesion</asp:HyperLink>
        </div>
    </form>
</body>
</html>
