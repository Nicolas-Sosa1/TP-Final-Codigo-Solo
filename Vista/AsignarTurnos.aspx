<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTurnos.aspx.cs" Inherits="Vista.AsignarTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="hlVolverPanelAdmin" runat="server" NavigateUrl="~/PanelUsuarioAdministrador.aspx">Panel de Administrador</asp:HyperLink>
            <br /><br />
            Usuario:&nbsp;&nbsp;
            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
            <br /><br />
            <asp:Label ID="lblAsignacion" runat="server" Text="Asignación de turnos" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            Seleccione la Fecha del turno: &nbsp;<asp:TextBox ID="txtFechaTurno" runat="server" TextMode="Date" ValidationGroup="1" Width="184px"></asp:TextBox>
            <br /><br />
            Seleccione una especialidad:&nbsp;&nbsp;
            <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ErrorMessage="*" ControlToValidate="ddlEspecialidades" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            <br /><br />
            Seleccione un medico:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlMedicos" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvMedicos" runat="server" ControlToValidate="ddlMedicos" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            <br /><br />
            Seleccione un dia:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlDias" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvDias" runat="server" ControlToValidate="ddlDias" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            <br />
            <br />
            Seleccione un horario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlHorarios" runat="server" Width="200px" OnSelectedIndexChanged="ddlHorarios_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvHorarios" runat="server" ControlToValidate="ddlHorarios" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            <br />
            <br />
            Seleccione la hora:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:DropDownList ID="ddlHora" runat="server" Width="200px"></asp:DropDownList>
            &nbsp;<br /><br />
            Seleccione un paciente:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlPacientes" runat="server" Width="200px"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvPacientes" runat="server" ControlToValidate="ddlPacientes" ErrorMessage="*" ForeColor="Red" ValidationGroup="1"></asp:RequiredFieldValidator>
            <br /><br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar turno" ValidationGroup="1" OnClick="btnAsignar_Click" />
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </form>
</body>
</html>
