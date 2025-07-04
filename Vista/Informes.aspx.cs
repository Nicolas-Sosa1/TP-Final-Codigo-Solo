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
        protected void Page_Load(object sender, EventArgs e)
        {
            string user;
            user = Session["Usuario"].ToString();
            lblUsuario.Text = user;
            

            CargarInformeEspecialidad();
        }

        private void CargarResumenTurnos(DateTime desde, DateTime hasta)
        {
            NegocioClinica negocio = new NegocioClinica();
            DataTable dt = negocio.ObtenerResumenAsistenciaTurnos(desde, hasta);
            gvInforme1.DataSource = dt;
            gvInforme1.DataBind();
        }

        private void CargarInformeEspecialidad()
        {
            NegocioClinica negocio = new NegocioClinica();
            DataTable dt = negocio.ObtenerEspecialidadMasFrecuente();
            gvInformeEspecialidad.DataSource = dt;
            gvInformeEspecialidad.DataBind();
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
    }
}