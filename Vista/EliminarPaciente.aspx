<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarPaciente.aspx.cs" Inherits="Vista.EliminarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Paciente</title>
    <style>
    body {
        background-color: #f4f4f4;
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
    }

    .container {
        max-width: 500px;
        margin: 80px auto;
        padding: 40px;
        background-color: #fff;
        border-radius: 10px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.15);
    }

    .form-group {
        margin-bottom: 25px;
    }

    .btn {
        background-color: #c0392b;
        color: white;
        padding: 10px 20px;
        font-size: 16px;
        border: none;
        border-radius: 6px;
        cursor: pointer;
    }

    .btn:hover {
        background-color: #a93226;
    }
</style>

</head>
<body>
   <form id="form1" runat="server">
    <div class="container">
        <div class="form-group">
            <asp:HyperLink ID="hlListadoPacientes" runat="server" NavigateUrl="~/PanelPacientes.aspx">Listado de pacientes</asp:HyperLink>
        </div>

        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" ForeColor="#006600"></asp:Label>
            <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblEliminar" runat="server" Text="Dar de baja un paciente" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>

        <div class="form-group">
            <label>Eliminar paciente por DNI:</label>
            <asp:TextBox ID="txtEliminarPaciente" runat="server" Width="200px" MaxLength="8"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEliminar" runat="server" ErrorMessage="Debe ingresar un DNI" ControlToValidate="txtEliminarPaciente" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEliminar" runat="server" ErrorMessage="Debe ingresar 8 números" ControlToValidate="txtEliminarPaciente" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="btnEliminarPaciente" runat="server" Text="Eliminar paciente" ValidationGroup="1" OnClick="btnEliminarPaciente_Click" CssClass="btn" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

        <div class="form-group">
            <asp:ValidationSummary ID="vsEliminar" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </div>
</form>

</body>
</html>
