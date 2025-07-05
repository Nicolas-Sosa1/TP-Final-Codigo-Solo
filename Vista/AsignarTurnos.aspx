<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTurnos.aspx.cs" Inherits="Vista.AsignarTurnos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Asignar Turnos</title>
    <style>
    body {
        background: #f0f4f8;
        font-family: Arial, sans-serif;
        margin: 0;
        padding: 0;
    }

    .container {
        max-width: 800px;
        margin: 50px auto;
        background: #ffffff;
        padding: 30px;
        border-radius: 12px;
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    }

    .form-group {
        margin-bottom: 20px;
    }

    label, .form-group label, .form-group asp\:label {
        display: block;
        font-weight: bold;
        color: #34495e;
        margin-bottom: 6px;
    }

    input[type="text"],
    input[type="email"],
    input[type="tel"],
    input[type="date"],
    select,
    .form-group asp\:textbox,
    .form-group asp\:dropdownlist {
        width: 100%;
        padding: 10px;
        border: 1px solid #ccc;
        border-radius: 6px;
        box-sizing: border-box;
    }

    .btn {
        background-color: #2980b9;
        color: white;
        font-weight: bold;
        border: none;
        padding: 12px 20px;
        border-radius: 6px;
        cursor: pointer;
    }

    .btn:hover {
        background-color: #1c5980;
    }

    .form-group asp\:requiredfieldvalidator,
    .form-group asp\:regularexpressionvalidator {
        color: red;
        font-size: 0.9em;
        display: inline;
        margin-left: 5px;
    }

    .form-group asp\:label[ID="lblMensaje"] {
        color: #e74c3c;
        font-weight: bold;
        text-align: center;
    }

    .form-group asp\:validationsummary {
        margin-top: 10px;
        font-size: 0.9em;
    }

    a {
        color: #2980b9;
        text-decoration: none;
        font-weight: bold;
    }

    a:hover {
        text-decoration: underline;
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
            <asp:Label ID="lblAsignacion" runat="server" Text="Asignación de turnos" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>

        <div class="form-group">
            <label>Seleccione la Fecha del turno:</label>
            <asp:TextBox ID="txtFechaTurno" runat="server" TextMode="Date" ValidationGroup="1" Width="200px"></asp:TextBox>
        &nbsp;
            <asp:RequiredFieldValidator ID="rfvEspecialidad0" runat="server" ErrorMessage="Debe seleccionar una Fecha" ControlToValidate="txtFechaTurno" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Seleccione una especialidad:</label>
            <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ErrorMessage="Debe seleccionar una especialidad" ControlToValidate="ddlEspecialidades" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Seleccione un médico:</label>
            <asp:DropDownList ID="ddlMedicos" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlMedicos_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvMedicos" runat="server" ControlToValidate="ddlMedicos" ErrorMessage="Debe seleccionar un medico" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Seleccione un día:</label>
            <asp:DropDownList ID="ddlDias" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvDias" runat="server" ControlToValidate="ddlDias" ErrorMessage="Debe seleccionar un dia" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Seleccione un horario:</label>
            <asp:DropDownList ID="ddlHorarios" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlHorarios_SelectedIndexChanged"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvHorarios" runat="server" ControlToValidate="ddlHorarios" ErrorMessage="Debe seleccionar un horario" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Seleccione la hora:</label>
            <asp:DropDownList ID="ddlHora" runat="server" Width="200px"></asp:DropDownList>
        &nbsp;<asp:RequiredFieldValidator ID="rfvHorarios0" runat="server" ControlToValidate="ddlHora" ErrorMessage="Debe seleccionar una hora" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Seleccione un paciente:</label>
            <asp:DropDownList ID="ddlPacientes" runat="server" Width="200px"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvPacientes" runat="server" ControlToValidate="ddlPacientes" ErrorMessage="Debe seleccionar un paciente" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar turno" ValidationGroup="1" OnClick="btnAsignar_Click" CssClass="btn" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </div>

        <div class="form-group">
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </div>
</form>
</body>
</html>
