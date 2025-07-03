<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Vista.AgregarMedicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Agregar Medicos</title>
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

        h2 {
            text-align: center;
            color: #2c3e50;
            margin-bottom: 30px;
        }

        .form-group {
            display: flex;
            flex-direction: column;
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            color: #34495e;
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
            width: 250px;
        }

        .form-inline {
            display: flex;
            flex-wrap: wrap;
            gap: 40px;
        }

        .form-inline .form-group {
            flex: 1 1 300px;
        }

        .btn {
            background-color: #2980b9;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 6px;
            font-weight: bold;
            cursor: pointer;
            margin-top: 20px;
        }

        .btn:hover {
            background-color: #1c5980;
        }

        .error {
            color: red;
            font-size: 0.9em;
        }

        .section-title {
            font-size: 1.2em;
            color: #2c3e50;
            margin-top: 30px;
            margin-bottom: 10px;
            border-bottom: 1px solid #ccc;
            padding-bottom: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">

        <div class="form-group">
            <asp:HyperLink ID="hlListadoMedicos" runat="server" NavigateUrl="~/PanelMedicos.aspx">Listado de medicos</asp:HyperLink>
        </div>

        <div class="form-group">
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" ForeColor="#006600"></asp:Label>
            <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="True"></asp:Label>
        </div>

        <div class="form-group">
            <asp:Label ID="lblAgregar" runat="server" Text="Registrar nuevo medico" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        </div>

        <div class="form-group">
            Legajo:
            <asp:TextBox ID="txtLegajo" runat="server" Width="200px" ValidationGroup="1" MaxLength="6" />
            <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Debe ingresar un legajo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Debe ingresar 6 numeros en el legajo" ForeColor="Red" ValidationExpression="^\d{6}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            DNI:
            <asp:TextBox ID="txtDNI" runat="server" Width="200px" ValidationGroup="1" MaxLength="8" />
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe ingresar un dni" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revDni0" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe ingresar 8 numeros en el Dni" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            Nombre:
            <asp:TextBox ID="txtNombre" runat="server" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar solo letras en el nombre" ForeColor="Red" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            Apellido:
            <asp:TextBox ID="txtApellido" runat="server" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar un apellido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar solo letras en el Apellido " ForeColor="Red" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+$" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            Sexo:
            <asp:DropDownList ID="ddlSexo" runat="server" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Debe seleccionar un sexo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Nacionalidad:
            <asp:TextBox ID="txtNacionalidad" runat="server" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Debe ingresar una nacionalidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Debe ingresar solo letras en la nacionalidad" ForeColor="Red" ValidationExpression="[A-Za-z]+" ValidationGroup="1">*</asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            Fecha de nacimiento:
            <asp:TextBox ID="txtFechaNac" runat="server" Width="200px" TextMode="Date" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="txtFechaNac" ErrorMessage="Debe ingresar una fecha de nacimiento" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Dirección:
            <asp:TextBox ID="txtDireccion" runat="server" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Debe ingresar una direccion" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Provincia:
            <asp:DropDownList ID="ddlProvincia" runat="server" Width="200px" ValidationGroup="1" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" />
            <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="Debe ingresar una provincia" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Localidad:
            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="200px" />
            <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="Debe ingresar una localidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Correo electrónico:
            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Debe ingresar un correo electronico" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Teléfono:
            <asp:TextBox ID="txtTelefono" runat="server" TextMode="Phone" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Debe ingresar un telefono" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Especialidad:
            <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" ErrorMessage="Debe seleccionar una especialidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Días de atención:
            <asp:CheckBoxList ID="cblDias" runat="server" />
        </div>

        <div class="form-group">
            Horario de atención:
            <asp:DropDownList ID="ddlHorarioAtencion" runat="server" Width="200px" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvHorarios" runat="server" ControlToValidate="ddlHorarioAtencion" ErrorMessage="Debe seleccionar un horario" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Crear usuario:
            <asp:TextBox ID="txtUsuario" runat="server" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Debe ingresar un Usuario" ControlToValidate="txtUsuario" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Crear contraseña:
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="Debe ingresar una contraseña" ControlToValidate="txtContra" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            Repetir contraseña:
            <asp:TextBox ID="txtRepetirContra" runat="server" TextMode="Password" ValidationGroup="1" />
            <asp:RequiredFieldValidator ID="rfvRepetirContra" runat="server" ErrorMessage="Debe ingresar nuevamente  la contraseña" ControlToValidate="txtRepetirContra" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvContra" runat="server" ErrorMessage="Las contraseñas ingresadas deben coincidir" ControlToCompare="txtRepetirContra" ControlToValidate="txtContra" ForeColor="Red" ValidationGroup="1">*</asp:CompareValidator>
        </div>

        <div class="form-group">
            <asp:Button ID="btnAgregarMedico" runat="server" Text="Agregar medico" ValidationGroup="1" OnClick="btnAgregarMedico_Click" CssClass="btn" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>

        <div class="form-group">
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>

    </div>  
    </form>
</body>
</html>
