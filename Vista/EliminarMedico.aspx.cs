using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vista
{
    public partial class EliminarMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            string user;
            user = Session["Usuario"].ToString();
            lblNombreUsuario.Text = user;
        }
        protected void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            string legajo = txtEliminarMedico.Text;

            NegocioClinica negocio = new NegocioClinica();
            string resultado = negocio.eliminarMedico(legajo);

            switch (resultado)
            {
                case "ok":
                    lblMensaje.Text = "✅ El médico se ha eliminado (dado de baja) con éxito.";
                    lblMensaje.ForeColor = Color.Green;
                    LimpiarCampos();
                    break;

                case "yaBaja":
                    lblMensaje.Text = "⚠️ El médico ya estaba dado de baja.";
                    lblMensaje.ForeColor = Color.OrangeRed;
                    break;

                case "noExiste":
                    lblMensaje.Text = "❌ No se encontró un médico con ese legajo.";
                    lblMensaje.ForeColor = Color.Red;
                    break;

                default:
                    lblMensaje.Text = "❌ Error al intentar eliminar el médico.";
                    lblMensaje.ForeColor = Color.Red;
                    break;
            }
        }


        private void LimpiarCampos()
        {
            txtEliminarMedico.Text = "";
        }
    }
}