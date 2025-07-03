<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vista.InicioAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Grupo 18 - Clínica Médica</title>
    <style>
        body {
            background: #f0f4f8;
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
        }

        .login-container {
            width: 400px;
            margin: 100px auto;
            padding: 30px;
            background: #ffffff;
            border-radius: 12px;
            box-shadow: 0 4px 10px rgba(0,0,0,0.1);
        }

        .login-container h1 {
            text-align: center;
            color: #2c3e50;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            display: block;
            margin-bottom: 6px;
            font-weight: bold;
            color: #34495e;
        }

        input[type="text"], input[type="password"] {
            width: 100%;
            padding: 10px;
            border-radius: 6px;
            border: 1px solid #ccc;
            box-sizing: border-box;
        }

        .btn-submit {
            width: 100%;
            padding: 10px;
            background-color: #2980b9;
            color: white;
            font-weight: bold;
            border: none;
            border-radius: 6px;
            cursor: pointer;
        }

        .btn-submit:hover {
            background-color: #1c5980;
        }

        .error-message {
            color: red;
            font-size: 0.9em;
            margin-top: 4px;
        }

        .message-label {
            text-align: center;
            margin-top: 20px;
            color: #e74c3c;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h1>Sistema Clínica Médica</h1>

            <asp:Label ID="lblLogin" runat="server" Text="Accedé al sistema" 
           Font-Size="Medium" 
           Style="display:block; text-align:center; color:#2980b9; margin-bottom:25px;" />
            <div class="form-group">
                <label for="txtUsuario">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Debe ingresar un usuario" ControlToValidate="txtUsuario" ForeColor="Red" ValidationGroup="1" CssClass="error-message" Display="Dynamic" >*</asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="txtContra">Contraseña</label>
                <asp:TextBox ID="txtContra" runat="server" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="Debe ingresar una contraseña" ControlToValidate="txtContra" ForeColor="Red" ValidationGroup="1" CssClass="error-message" Display="Dynamic" >*</asp:RequiredFieldValidator>
            </div>

            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn-submit" ValidationGroup="1" OnClick="btnIngresar_Click" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="message-label" />
            <asp:ValidationSummary ID="vsLogin" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </form>
</body>
</html>
