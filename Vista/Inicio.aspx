<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="Vista.InicioAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Grupo 18</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblClinicaMedica" runat="server" Text="Sistema Clinica medica " Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            <asp:Label ID="lblLogin" runat="server" Text="Iniciar sesion:" Font-Bold="True" Font-Size="Large"></asp:Label>
            <br /><br />
            Usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Debe ingresar un usuario" ControlToValidate="txtUsuario" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Contraseña:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="Debe ingresar una contraseña" ControlToValidate="txtContra" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" ValidationGroup="1" OnClick="btnIngresar_Click" />
            <br />
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            <asp:ValidationSummary ID="vsLogin" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </form>
</body>
</html>
