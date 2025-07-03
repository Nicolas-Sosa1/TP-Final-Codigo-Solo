<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarPaciente.aspx.cs" Inherits="Vista.AgregarPaciente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <title>Agregar Paciente</title>
    <style>
        body {
            font-family: 'Segoe UI', sans-serif;
            background-color: #f2f6fc;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 900px;
            margin: 40px auto;
            background-color: #fff;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 15px rgba(0, 0, 0, 0.1);
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            color: #34495e;
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"],
        input[type="password"],
        input[type="email"],
        input[type="date"],
        select {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 6px;
            width: 100%;
        }

        .btn {
            background-color: #2980b9;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 6px;
            font-weight: bold;
            cursor: pointer;
        }

        .btn:hover {
            background-color: #1c5980;
        }

        .error {
            color: red;
            font-size: 0.9em;
            display: inline-block;
            margin-left: 10px;
        }

        .section-title {
            font-size: 1.2em;
            color: #2c3e50;
            margin-top: 30px;
            margin-bottom: 10px;
            border-bottom: 1px solid #ccc;
            padding-bottom: 5px;
        }

        .error::before {
            content: '* ';
            color: red;
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
            <asp:Label ID="lblAgregar" runat="server" Text="Registrar nuevo paciente" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>

        <div class="form-group">
            <label>DNI:</label>
            <asp:TextBox ID="txtDNI" runat="server" Width="200px" ValidationGroup="1" MaxLength="8"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe ingresar un dni" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe ingresar 8 numeros en el Dni" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar solo letras en el nombre" ForeColor="Red" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <label>Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar un apellido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar solo letras en el Apellido " ForeColor="Red" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <label>Sexo:</label>
            <asp:DropDownList ID="ddlSexo" runat="server" Width="200px" ValidationGroup="1"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Debe seleccionar un sexo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Nacionalidad:</label>
            <asp:TextBox ID="txtNacionalidad" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Debe ingresar una nacionalidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Debe ingresar solo letras en la nacionalidad" ForeColor="Red" ValidationExpression="[A-Za-z]+" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <label>Fecha de nacimiento:</label>
            <asp:TextBox ID="txtFechaNac" runat="server" Width="200px" TextMode="Date" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="txtFechaNac" ErrorMessage="Debe ingresar un fecha de nacimiento" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Dirección:</label>
            <asp:TextBox ID="txtDireccion" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Debe ingresar una direccion" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Provincia:</label>
            <asp:DropDownList ID="ddlProvincia" runat="server" Width="200px" ValidationGroup="1" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="Debe ingresar una provincia" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Localidad:</label>
            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="200px" ValidationGroup="1"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="Debe seleccionar una localidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Correo electrónico:</label>
            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Debe ingresar un correo electronico" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" TextMode="Phone" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Debe ingresar un telefono" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="btnAgregarPaciente" runat="server" Text="Agregar paciente" ValidationGroup="1" OnClick="btnAgregarPaciente_Click" CssClass="btn" />
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
