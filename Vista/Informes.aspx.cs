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
            //string user;
            //user = Session["Usuario"].ToString();
            //lblUsuario.Text = user;


            
            CargarResumenTurnos(FechaDesdeEnero(), FechaHastaDiciembre());
            CargarInformeEspecialidad();
        }

        public DateTime FechaDesdeEnero()
        {

            DateTime desde = new DateTime(2025, 1, 1);
            return desde;


        }

        public DateTime FechaHastaDiciembre()
        {

            DateTime hasta = new DateTime(2025, 12, 31);
            return hasta;


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
    }
}