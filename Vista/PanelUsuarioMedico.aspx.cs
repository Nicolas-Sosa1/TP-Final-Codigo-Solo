using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vista
{
    public partial class PanelUsuarioMedico : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string user;
                user = Session["Usuario"].ToString();
                lblUsuario.Text = user;

                CargarTurnos();
            }

        }

        private void CargarTurnos()
        {
            string nombreUsuario = Session["Usuario"].ToString(); // Ya lo estás guardando antes
            DataTable dt = negocioClinica.ObtenerTodosLosTurnos(nombreUsuario);
            gvTurnos.DataSource = dt;
            gvTurnos.DataBind();
        }

        protected void gvTurnos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvTurnos.EditIndex == e.Row.RowIndex)
            {
                // Obtener el valor actual del estado desde el DataItem
                string estadoActual = DataBinder.Eval(e.Row.DataItem, "EstadoTurno").ToString();

                // Buscar el DropDownList
                DropDownList ddlEstado = (DropDownList)e.Row.FindControl("ddlEstado");
                if (ddlEstado != null)
                {
                    // Cargar las opciones si aún no están cargadas
                    if (ddlEstado.Items.Count == 0)
                    {
                        ddlEstado.Items.Add(new ListItem("Presente", "Presente"));
                        ddlEstado.Items.Add(new ListItem("Ausente", "Ausente"));
                        ddlEstado.Items.Add(new ListItem("Pendiente", "Pendiente"));
                    }

                    // Seleccionar la opción actual
                    ddlEstado.SelectedValue = estadoActual;
                }

                // === HABILITAR txtObservaciones solo si el estado es "Presente" ===
                TextBox txtObservaciones = (TextBox)e.Row.FindControl("txtObservaciones");
                if (txtObservaciones != null)
                {
                    txtObservaciones.Enabled = (estadoActual == "Presente");
                }
            }
        }

        protected void gvTurnos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = gvTurnos.Rows[e.RowIndex];

            int idTurno = Convert.ToInt32(gvTurnos.DataKeys[e.RowIndex].Value);

            DropDownList ddlEstado = (DropDownList)row.FindControl("ddlEstado");
            TextBox txtObservacion = (TextBox)row.FindControl("txtObservaciones");

            Turnos turno = new Turnos();
            turno.setId_Turno(idTurno);
            turno.setEstadoTurno(ddlEstado.SelectedValue);
            turno.setObservacion(txtObservacion.Text);

            int filasAfectadas = negocioClinica.ActualizarTurno(turno);

            gvTurnos.EditIndex = -1;
            CargarTurnos();

            // Opcional: mensaje de éxito
            if (filasAfectadas > 0)
                lblMensaje.Text = "Turno actualizado correctamente.";
            else
                lblMensaje.Text = "No se pudo actualizar el turno.";
        }

        protected void gvTurnos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvTurnos.PageIndex = e.NewPageIndex;
            CargarTurnos();
        }
        protected void gvTurnos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvTurnos.EditIndex = e.NewEditIndex;
            CargarTurnos();
        }

        protected void gvTurnos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvTurnos.EditIndex = -1;
            CargarTurnos();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlEstado = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlEstado.NamingContainer;
            TextBox txtObservaciones = (TextBox)row.FindControl("txtObservaciones");

            if (txtObservaciones != null)
            {
                // Habilitar sólo si está en "Presente"
                txtObservaciones.Enabled = ddlEstado.SelectedValue == "Presente";
            }
        }
    }
}