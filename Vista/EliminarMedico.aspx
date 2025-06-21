<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarMedico.aspx.cs" Inherits="Vista.EliminarMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlListadoMedicos" runat="server" NavigateUrl="~/PanelMedicos.aspx">Listado de medicos</asp:HyperLink>
            <br /><br />
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" ForeColor="#006600"></asp:Label>&nbsp;
            <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="True"></asp:Label>
            <br /><br />
            <asp:Label ID="lblEliminar" runat="server" Text="Dar de baja un medico" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            Eliminar medico por legajo:&nbsp;&nbsp;
            <asp:TextBox ID="txtEliminarMedico" runat="server" Width="200px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvEliminar" runat="server" ErrorMessage="Debe ingresar un legajo" ControlToValidate="txtEliminarMedico" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revEliminar" runat="server" ErrorMessage="Debe ingresar 6 numeros" ControlToValidate="txtEliminarMedico" ForeColor="Red" ValidationExpression="^\d{6}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
            &nbsp;&nbsp;
            <asp:Button ID="btnEliminarMedico" runat="server" Text="Eliminar medico" ValidationGroup="1" OnClick="btnEliminarMedico_Click" />
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <asp:ValidationSummary ID="vsEliminar" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </form>
</body>
</html>
