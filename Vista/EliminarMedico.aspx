<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarMedico.aspx.cs" Inherits="Vista.EliminarMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Eliminar Medico</title>
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

    asp\:label {
        font-size: 16px;
    }
</style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="form-group">
            <asp:HyperLink ID="hlListadoMedicos" runat="server" NavigateUrl="~/PanelMedicos.aspx">Listado de médicos</asp:HyperLink>
        </div>

        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" ForeColor="#006600"></asp:Label>
            <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblEliminar" runat="server" Text="Dar de baja un médico" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>

        <div class="form-group">
            <label>Eliminar médico por legajo:</label>
            <asp:TextBox ID="txtEliminarMedico" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEliminar" runat="server" ControlToValidate="txtEliminarMedico" ErrorMessage="Debe ingresar un legajo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEliminar" runat="server" ControlToValidate="txtEliminarMedico" ErrorMessage="Debe ingresar 6 números" ForeColor="Red" ValidationExpression="^\d{6}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="btnEliminarMedico" runat="server" Text="Eliminar médico" ValidationGroup="1" OnClick="btnEliminarMedico_Click" CssClass="btn" />
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
