<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelUsuarioMedico.aspx.cs" Inherits="Vista.PanelUsuarioMedico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <div>
            <asp:Label ID="lblMedico" runat="server" Text="Panel de Médico" Font-Bold="True" Font-Size="X-Large"></asp:Label>
            <br /><br />
            Usuario:&nbsp;&nbsp;
            <asp:Label ID="lblUsuario" runat="server" Text=""></asp:Label>
            <br />
            <asp:HyperLink ID="hlCerrar" runat="server" NavigateUrl="~/CerrarSesion.aspx">Cerrar sesion</asp:HyperLink>
            <br />
            <br />
            Buscar por nombre de paciente:&nbsp;&nbsp; <asp:TextBox ID="txtNombre" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Buscar por numero de turno:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtTurno" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            Buscar por estado del turno:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlBuscarEstado" runat="server" Width="200px">
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar todos" />
            <br /><br />
            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" AutoGenerateEditButton="True">
                <Columns>
                     <asp:TemplateField HeaderText="Turno">
                     <EditItemTemplate>
                         <asp:Label ID="editTurno" runat="server" Text=""></asp:Label>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lblTurno" runat="server" Text=""></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Paciente">
                    <EditItemTemplate>
                        <asp:Label ID="editPaciente" runat="server" Text=""></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPaciente" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Estado">
                    <EditItemTemplate>
                        <asp:Label ID="editEstado" runat="server" Text=""></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList ID="ddlEstado" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Observaciones">
                    <EditItemTemplate>
                        <asp:Label ID="editObservaciones" runat="server" Text=""></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblObservaciones" runat="server" Text=""></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
    </form>
</body>
</html>
