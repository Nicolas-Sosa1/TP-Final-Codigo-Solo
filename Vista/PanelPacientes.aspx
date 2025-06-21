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
            <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" Font-Bold="True" ForeColor="#006600"></asp:Label>&nbsp;
            <asp:Label ID="lblNombreUsuario" runat="server" Font-Bold="True"></asp:Label>
            <br /><br />
            Buscar paciente:&nbsp;&nbsp;
            <asp:TextBox ID="txtBuscar" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvBuscar" runat="server" ErrorMessage="Debe ingresar un nombre" ControlToValidate="txtBuscar" ForeColor="Red" ValidationGroup="1">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" ValidationGroup="1" OnClick="btnFiltrar_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar Todos" OnClick="btnMostrar_Click" />
            <br /><br />
            <asp:ValidationSummary ID="vsBuscar" runat="server" ForeColor="Red" ValidationGroup="1" />
            <br />
            <asp:GridView ID="gvPacientes" runat="server" AutoGenerateEditButton="True" 
    OnRowCancelingEdit="gvPacientes_RowCancelingEdit" 
    OnRowEditing="gvPacientes_RowEditing" 
    OnRowUpdating="gvPacientes_RowUpdating" 
    AutoGenerateColumns="False" OnRowDataBound="gvPacientes_RowDataBound" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal" AllowPaging="True" OnPageIndexChanging="gvPacientes_PageIndexChanging" PageSize="5">
    <Columns>
        <asp:TemplateField HeaderText="DNI">
            <EditItemTemplate>
                <asp:Label ID="lbl_eit_dni" runat="server" Text='<%# Bind("Documento") %>'></asp:Label>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_dni" runat="server" Text='<%# Bind("Documento") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nombre">
            <EditItemTemplate>
                <asp:TextBox ID="txt_eit_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_nombre" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Apellido">
            <EditItemTemplate>
                <asp:TextBox ID="txt_eit_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_apellido" runat="server" Text='<%# Bind("Apellido") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Sexo">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlSexo" runat="server"></asp:DropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_sexo" runat="server" Text='<%# Bind("Sexo") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Nacionalidad">
            <EditItemTemplate>
                <asp:TextBox ID="txt_eit_nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_nacionalidad" runat="server" Text='<%# Bind("Nacionalidad") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Fecha de nacimiento">
            <EditItemTemplate>
                <asp:TextBox ID="txt_eit_fecha_nac" runat="server" Text='<%# Bind("FechaNacimiento", "{0:yyyy-MM-dd}") %>' TextMode="Date"></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_fecha_nacimiento" runat="server" Text='<%# Bind("FechaNacimiento") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Dirección">
            <EditItemTemplate>
                <asp:TextBox ID="txt_eit_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_direccion" runat="server" Text='<%# Bind("Direccion") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
       <asp:TemplateField HeaderText="Provincia">
    <ItemTemplate>
        <asp:Label ID="lbl_provincia" runat="server" Text='<%# Bind("Provincia") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:DropDownList ID="ddlProvincia" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged"></asp:DropDownList>
    </EditItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="Localidad">
            <EditItemTemplate>
                <asp:DropDownList ID="ddlLocalidad" runat="server"></asp:DropDownList>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_localidad" runat="server" Text='<%# Bind("Localidad") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Correo electrónico">
            <EditItemTemplate>
                <asp:TextBox ID="txt_eit_correo" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_correo" runat="server" Text='<%# Bind("CorreoElectronico") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Teléfono">
            <EditItemTemplate>
                <asp:TextBox ID="txt_eit_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:TextBox>
            </EditItemTemplate>
            <ItemTemplate>
                <asp:Label ID="lbl_telefono" runat="server" Text='<%# Bind("Telefono") %>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
                <FooterStyle BackColor="White" ForeColor="#333333" />
                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="White" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#487575" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#275353" />
</asp:GridView>
            <br />
        </div>
    </form>
</body>
</html>
