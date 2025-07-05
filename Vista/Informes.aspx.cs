using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vista
{
    public partial class Informes : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            //string user;
            //user = Session["Usuario"].ToString();
            //lblUsuario.Text = user;

            if (!IsPostBack)
            {
                CargarDdlEspecialidades();
            }
        }

        private void CargarResumenTurnos(DateTime desde, DateTime hasta)
        {
            NegocioClinica negocio = new NegocioClinica();
            DataTable dt = negocio.ObtenerResumenAsistenciaTurnos(desde, hasta);
            gvInforme1.DataSource = dt;
            gvInforme1.DataBind();
        }

      

        protected void btnInforme1_Click(object sender, EventArgs e)
        {
            DateTime fechaDesde;
            DateTime fechaHasta;
            if (DateTime.TryParse(txtFechaDesde.Text, out fechaDesde) && (DateTime.TryParse(txtFechaHasta.Text, out fechaHasta)))
            {

                CargarResumenTurnos(fechaDesde, fechaHasta);
            }

        }

        private void CargarInformeEspecialidad(int IdEspecialidad)
        {
            NegocioClinica negocio = new NegocioClinica();
            DataTable dt = negocio.ObtenerEspecialidadMasFrecuente(IdEspecialidad);
            gvInformeEspecialidad.DataSource = dt;
            gvInformeEspecialidad.DataBind();
        }

        public void CargarDdlEspecialidades()
        {
            DataTable dataTable = negocioClinica.getTablaEspecialidades();
            ddlEspecialidades.DataSource = dataTable;
            ddlEspecialidades.DataTextField = "DescripcionEspecialidad";
            ddlEspecialidades.DataValueField = "Id_Especialidad";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccione una especialidad --", ""));

        }

        protected void btnInforme2_Click(object sender, EventArgs e)
        {
            int IdEspecialidad = Convert.ToInt32(ddlEspecialidades.SelectedValue);
            
            CargarInformeEspecialidad(IdEspecialidad);
        }
    }
}