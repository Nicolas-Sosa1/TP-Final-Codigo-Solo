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
        }

        protected void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            string legajo = txtEliminarMedico.Text;

            NegocioClinica negocio = new NegocioClinica();

            bool eliminado = negocio.eliminarMedico(legajo);

            if (eliminado == true)
            {
                lblMensaje.Text = "La sucursal se ha eliminado con éxito.";
                LimpiarCampos();
                lblMensaje.ForeColor = Color.Green;
            }

            else
            {
                lblMensaje.Text = "No se encontró una sucursal con ese ID.";
                lblMensaje.ForeColor = Color.Red;
            }

        }

        private void LimpiarCampos()
        {

        }
    }
}