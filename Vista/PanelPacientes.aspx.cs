using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;


namespace Vista
{
    public partial class PanelPacientes : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (IsPostBack == false)
            {
                cargarGridView();
            }
        }

        public void cargarGridView()
        {
            DataTable dataTable = negocioClinica.getTablaPacientes();
            gvPacientes.DataSource = dataTable;
            gvPacientes.DataBind();
            
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            cargarGridView();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            

        }

        protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPacientes.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void gvPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPacientes.EditIndex = -1;
            cargarGridView();
        }

        protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string dni = ((Label)gvPacientes.Rows[e.RowIndex].FindControl("lbl_eit_dni")).Text;
            string nombre = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_nombre")).Text;
            string apellido = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txt_eit_apellido")).Text;
        }
    }
}