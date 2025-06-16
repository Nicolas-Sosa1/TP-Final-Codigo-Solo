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
    public partial class PanelMedicos : System.Web.UI.Page
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
            DataTable dataTable = negocioClinica.getTablaMedicos();
            gvMedicos.DataSource = dataTable;
            gvMedicos.DataBind();

        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            cargarGridView();
        }
    }
}