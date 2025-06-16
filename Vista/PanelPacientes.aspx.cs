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
    }
}