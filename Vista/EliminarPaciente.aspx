<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarPaciente.aspx.cs" Inherits="Vista.EliminarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlListadoPacientes" runat="server" NavigateUrl="~/PanelPacientes.aspx">Listado de pacientes</asp:HyperLink>
            <br /><br />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" ForeColor="#006600"></asp:Label>&nbsp;
            <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="True"></asp:Label>
            <br /><br />
            <asp:Label ID="lblEliminar" runat="server" Text="Dar de baja un paciente" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            Eliminar paciente por DNI:&nbsp;&nbsp;
            <asp:TextBox ID="txtEliminarPaciente" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvEliminar" runat="server" ErrorMessage="Debe ingresar un DNI" ControlToValidate="txtEliminarPaciente" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revEliminar" runat="server" ErrorMessage="Debe ingresar 8 numeros" ControlToValidate="txtEliminarPaciente" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
            &nbsp;&nbsp;
            <asp:Button ID="btnEliminarPaciente" runat="server" Text="Eliminar paciente" ValidationGroup="1" OnClick="btnEliminarPaciente_Click" />
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <asp:ValidationSummary ID="vsEliminar" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </form>
</body>
</html>
