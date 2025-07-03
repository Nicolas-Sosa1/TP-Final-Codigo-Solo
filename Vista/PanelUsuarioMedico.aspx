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
            <strong>
            <asp:Label ID="lblUsuarios" runat="server" ForeColor="#006600" Text="Usuario:"></asp:Label>
            </strong>&nbsp;<strong><asp:Label ID="lblUsuario" runat="server" ForeColor="Black"></asp:Label>
            </strong>
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
            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnMostrar" runat="server" Text="Mostrar todos" OnClick="btnMostrar_Click" />
            <br /><br />
            <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_Turno"  AutoGenerateEditButton="True"  OnPageIndexChanging="gvTurnos_PageIndexChanging" OnRowCancelingEdit="gvTurnos_RowCancelingEdit" OnRowDataBound="gvTurnos_RowDataBound" OnRowEditing="gvTurnos_RowEditing" OnRowUpdating="gvTurnos_RowUpdating" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" GridLines="Horizontal">
                <Columns>
                     <asp:TemplateField HeaderText="Turno">
                     <EditItemTemplate>
                         <asp:Label ID="editTurno" runat="server" Text='<%# Bind("Id_Turno") %>'></asp:Label>
                     </EditItemTemplate>
                     <ItemTemplate>
                         <asp:Label ID="lblTurno" runat="server" Text='<%# Bind("Id_Turno") %>'></asp:Label>
                     </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Paciente">
                    <EditItemTemplate>
                        <asp:Label ID="editPaciente" runat="server" Text='<%# Bind("DNI_Paciente") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblPaciente" runat="server" Text='<%# Bind("DNI_Paciente") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Nombre del Paciente">
                    <EditItemTemplate>
                        <asp:Label ID="editNombrePaciente" runat="server" Text='<%# Bind("NombrePaciente") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblNombrePaciente" runat="server" Text='<%# Bind("NombrePaciente") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Dia">
                    <EditItemTemplate>
                        <asp:Label ID="editDescripcionDia" runat="server" Text='<%# Bind("DescripcionDia") %>'></asp:Label>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDescripcionDia" runat="server" Text='<%# Bind("DescripcionDia") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Fecha">
                        <EditItemTemplate>
                            <asp:Label ID="editFecha" runat="server" Text='<%# Bind("Fecha", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblFecha" runat="server" Text='<%# Bind("Fecha", "{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Hora">
                        <EditItemTemplate>
                            <asp:Label ID="editHora" runat="server" Text='<%# Bind("Hora") %>'></asp:Label>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblHora" runat="server" Text='<%# Bind("Hora") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                     <asp:TemplateField HeaderText="Estado">
                    <EditItemTemplate>
                     <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"></asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                         <asp:Label ID="editEstado" runat="server" Text='<%# Bind("EstadoTurno") %>'></asp:Label>
                    </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Observaciones">
                    <EditItemTemplate>
                       
                        <asp:TextBox ID="txtObservaciones" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                         <ItemTemplate>
                             
                              <asp:Label ID="editObservaciones" runat="server" Text='<%# Bind("Observacion") %>'></asp:Label>
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
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
