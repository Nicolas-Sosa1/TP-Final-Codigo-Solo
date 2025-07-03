<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CerrarSesion.aspx.cs" Inherits="Vista.CerrarSesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Cerrar Sesión</title>
    <style>
    body {
        background-color: #f9f9f9;
        font-family: Arial, sans-serif;
        padding: 0;
        margin: 0;
    }

    .container {
        max-width: 500px;
        margin: 100px auto;
        padding: 40px;
        background-color: #ffffff;
        border-radius: 12px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
        text-align: center;
    }

    .form-group {
        margin-bottom: 30px;
    }

    .btn {
        background-color: #2980b9;
        color: white;
        padding: 12px 20px;
        border: none;
        border-radius: 8px;
        font-size: 16px;
        font-weight: bold;
        cursor: pointer;
    }

    .btn:hover {
        background-color: #21618c;
    }

    asp\:label {
        font-size: 18px;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="form-group">
            <asp:Label ID="lblSaludo" runat="server" Text="Hola " Font-Size="Large" Font-Bold="True"></asp:Label>
            <asp:Label ID="lblUsuario" runat="server" Font-Size="Large" Font-Bold="True"></asp:Label>
            <asp:Label ID="lblPregunta" runat="server" Text=", ¿estás seguro que deseas cerrar sesión?" Font-Size="Large"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Button ID="btnSi" runat="server" OnClick="btnSi_Click" Text="Sí, cerrar sesión" CssClass="btn" Width="200px" />
        </div>

        <div class="form-group">
            <asp:Button ID="btnNo" runat="server" OnClick="btnNo_Click" Text="No, volver al sistema" CssClass="btn" Width="200px" />
        </div>
    </div>
</form>

</body>
</html>
