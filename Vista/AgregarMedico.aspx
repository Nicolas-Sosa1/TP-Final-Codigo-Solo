<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMedico.aspx.cs" Inherits="Vista.AgregarMedicos" %>

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
            <asp:Label ID="lblAgregar" runat="server" Text="Registrar nuevo medico" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            Legajo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtLegajo" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvLegajo" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Debe ingresar un legajo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revDni" runat="server" ControlToValidate="txtLegajo" ErrorMessage="Debe ingresar 6 numeros en el legajo" ForeColor="Red" ValidationExpression="^\d{6}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
            <br /><br />
            DNI:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDNI" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDNI" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe ingresar un dni" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revDni0" runat="server" ControlToValidate="txtDNI" ErrorMessage="Debe ingresar 8 numeros en el Dni" ForeColor="Red" ValidationExpression="^\d{8}$" ValidationGroup="1">*</asp:RegularExpressionValidator>
            <br /><br />
            Nombre:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNombre" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar un nombre" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Debe ingresar solo letras en el nombre" ForeColor="Red" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+$" ValidationGroup="1">*</asp:RegularExpressionValidator>
            <br /><br />
            Apellido:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtApellido" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar un apellido" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Debe ingresar solo letras en el Apellido " ForeColor="Red" ValidationExpression="^[A-Za-zÁÉÍÓÚáéíóúÑñ]+$" ValidationGroup="1">*</asp:RegularExpressionValidator>
            <br /><br />
            Sexo:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSexo" runat="server" Width="200px" ValidationGroup="1"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvSexo" runat="server" ControlToValidate="ddlSexo" ErrorMessage="Debe seleccionar un sexo" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Nacionalidad:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtNacionalidad" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Debe ingresar una nacionalidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revNacionalidad" runat="server" ControlToValidate="txtNacionalidad" ErrorMessage="Debe ingresar solo letras en la nacionalidad" ForeColor="Red" ValidationExpression="[A-Za-z]+" ValidationGroup="1">*</asp:RegularExpressionValidator>
            <br /><br />
            Fecha de nacimiento:&nbsp;
            <asp:TextBox ID="txtFechaNac" runat="server" Width="200px" TextMode="Date" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvFechaNac" runat="server" ControlToValidate="txtFechaNac" ErrorMessage="Debe ingresar una fecha de nacimiento" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Direccion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDireccion" runat="server" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Debe ingresar una direccion" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Provincia:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProvincia" runat="server" Width="200px" ValidationGroup="1" AutoPostBack="True" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvProvincia" runat="server" ControlToValidate="ddlProvincia" ErrorMessage="Debe ingresar una provincia" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br />
            <br />
            Localidad:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlLocalidad" runat="server" Width="200px"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvLocalidad" runat="server" ControlToValidate="ddlLocalidad" ErrorMessage="Debe ingresar una localidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Correo electronico:&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Debe ingresar un correo electronico" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Telefono:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTelefono" runat="server" TextMode="Phone" Width="200px" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Debe ingresar un telefono" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Especialidad:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlEspecialidades" runat="server" Width="200px" ValidationGroup="1"></asp:DropDownList>
            &nbsp;
            <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server" ControlToValidate="ddlEspecialidades" ErrorMessage="Debe seleccionar una especialidad" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Dias de atención:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlDiasAtencion" runat="server" Width="200px" ValidationGroup="1"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvDiasAtencion" runat="server" ControlToValidate="ddlDiasAtencion" ErrorMessage="Debe seleccionar un dia de atencion" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Horario de atención:&nbsp; <asp:DropDownList ID="ddlHorarioAtencion" runat="server" Width="200px" ValidationGroup="1"></asp:DropDownList>
            &nbsp;<asp:RequiredFieldValidator ID="rfvHorarioAtencion" runat="server" ControlToValidate="ddlHorarioAtencion" ErrorMessage="Debe seleccionar un Horario" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Crear usuario:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtUsuario" runat="server" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ErrorMessage="Debe ingresar un Usuario" ControlToValidate="txtUsuario" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Crear contraseña:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtContra" runat="server" TextMode="Password" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvContra" runat="server" ErrorMessage="Debe ingresar una contraseña" ControlToValidate="txtContra" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            <br /><br />
            Repetir contraseña:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtRepetirContra" runat="server" TextMode="Password" ValidationGroup="1"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvRepetirContra" runat="server" ErrorMessage="Debe ingresar nuevamente  la contraseña" ControlToValidate="txtRepetirContra" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;<asp:CompareValidator ID="cvContra" runat="server" ErrorMessage="Las contraseñas ingresadas deben coincidir" ControlToCompare="txtRepetirContra" ControlToValidate="txtContra" ForeColor="Red" ValidationGroup="1">*</asp:CompareValidator>
            <br /><br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAgregarMedico" runat="server" Text="Agregar medico" ValidationGroup="1" OnClick="btnAgregarMedico_Click" />
            <br /><br />
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:ValidationSummary ID="vsErrores" runat="server" ForeColor="Red" ValidationGroup="1" />
        </div>
    </form>
</body>
</html>
