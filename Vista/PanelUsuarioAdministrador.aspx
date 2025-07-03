<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelAdministrador.aspx.cs" Inherits="Vista.PanelAdministrador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Panel Administrador</title>
    <style>
    body {
        background: #f0f4f8;
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
    }

    .container {
        width: 800px;
        margin: 50px auto;
        padding: 30px;
        background: #ffffff;
        border-radius: 12px;
        box-shadow: 0 4px 10px rgba(0,0,0,0.1);
    }

    .form-group {
        margin-bottom: 25px;
    }

    label {
        font-weight: bold;
        color: #34495e;
        margin-right: 10px;
    }

    .btn {
        padding: 10px 20px;
        background-color: #2980b9;
        color: white;
        border: none;
        border-radius: 6px;
        cursor: pointer;
        font-weight: bold;
    }

    .btn:hover {
        background-color: #1c5980;
    }

    a {
        color: #2980b9;
        font-weight: bold;
        text-decoration: none;
    }

    a:hover {
        text-decoration: underline;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="form-group">
            <asp:Label ID="lblAdmin" runat="server" Text="Panel de Administrador" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" ForeColor="#006600"></asp:Label>
            <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Button ID="btnPacientes" runat="server" Text="ABML Pacientes" CssClass="btn" Width="200px" OnClick="btnPacientes_Click" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnMedicos" runat="server" Text="ABML Medicos" CssClass="btn" Width="200px" OnClick="btnMedicos_Click" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnTurnos" runat="server" Text="Asignación de turnos" CssClass="btn" Width="200px" OnClick="btnTurnos_Click" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnInformes" runat="server" Text="Informes" CssClass="btn" Width="200px" OnClick="btnInformes_Click" />
        </div>

        <div class="form-group">
            <asp:HyperLink ID="hlLogOut" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar sesión</asp:HyperLink>
        </div>
    </div>
</form>

</body>
</html>
