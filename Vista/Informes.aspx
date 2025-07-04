<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="Vista.Informes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Informes Medicos</title>
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

    h3 {
        color: #2c3e50;
        margin-top: 30px;
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

    .gridview {
        width: 100%;
        border-collapse: collapse;
        margin-top: 10px;
    }

    .gridview th, .gridview td {
        padding: 8px;
        border: 1px solid #ccc;
        text-align: center;
    }

    .gridview th {
        background-color: #ecf0f1;
        font-weight: bold;
    }
</style>

</head>
<body>
   <form id="form1" runat="server">
    <div class="container">
        <div class="form-group">
            <asp:HyperLink ID="hlVolverPanelAdmin" runat="server" NavigateUrl="~/PanelUsuarioAdministrador.aspx">Panel de Administrador</asp:HyperLink>
        </div>

        <div class="form-group">
            <asp:Label ID="lblUsuarios" runat="server" ForeColor="#006600" Text="Usuario:" Font-Bold="True"></asp:Label>
            <asp:Label ID="lblUsuario" runat="server" ForeColor="Black" Font-Bold="True"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblInformes" runat="server" Text="Informes" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>

        <div class="form-group">
            <h3>Elija un rango de fechas para saber la cantidad de turnos:</h3>
            <asp:Label ID="lblDesde" runat="server" Text="Desde:" Font-Bold="True"></asp:Label>&nbsp;
            <asp:TextBox ID="txtFechaDesde" runat="server" TextMode="Date"></asp:TextBox>&nbsp;
            <asp:Label ID="lblHasta" runat="server" Text="Hasta:" Font-Bold="True"></asp:Label>&nbsp;
            <asp:TextBox ID="txtFechaHasta" runat="server" TextMode="Date"></asp:TextBox>&nbsp;
            <asp:Button ID="btnInforme1" runat="server" Text="Recibir informe" OnClick="btnInforme1_Click" />
            <br /><br />
            <asp:GridView ID="gvInforme1" runat="server"></asp:GridView>
        </div>

        <div class="form-group">
            <h3>Cantidad de Medicos por Especialidad</h3>
            <asp:GridView ID="gvInformeEspecialidad" runat="server"></asp:GridView>
        </div>
    </div>
</form>
</body>
</html>
