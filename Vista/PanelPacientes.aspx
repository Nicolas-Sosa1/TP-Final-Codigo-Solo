<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelPacientes.aspx.cs" Inherits="Vista.PanelPacientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .auto-style1{
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
            <tr>
                <td>
                    <asp:HyperLink ID="hlVolverPanelAdmin" runat="server" NavigateUrl="~/PanelUsuarioAdministrador.aspx">Panel de Administrador</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="hlAgregarPaciente" runat="server" NavigateUrl="~/AgregarPaciente.aspx">Agregar Paciente</asp:HyperLink>
                </td>
                <td>
                    <asp:HyperLink ID="hlEliminarPaciente" runat="server" NavigateUrl="~/EliminarPaciente.aspx">Eliminar Paciente</asp:HyperLink>
                </td>
            </tr>
            </table>
            <br /><br />
            <asp:Label ID="lblPacientes" runat="server" Text="Listado de pacientes" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            Buscar paciente:&nbsp;&nbsp;
            <asp:TextBox ID="txtBuscar" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvBuscar" runat="server" ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtBuscar" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" ValidationGroup="1" />
            &nbsp;&nbsp;
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar Todos" />
            <br /><br />
            <asp:ValidationSummary ID="vsBuscar" runat="server" ForeColor="Red" ValidationGroup="1" />
            <br /><br />
            <asp:GridView ID="gvPacientes" runat="server"></asp:GridView>     
        </div>
    </form>
</body>
</html>
