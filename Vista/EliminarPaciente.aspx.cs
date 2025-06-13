using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vista
{
    public partial class EliminarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnEliminarPaciente_Click(object sender, EventArgs e)
        {
            string dni = txtEliminarPaciente.Text;

            NegocioClinica negocio = new NegocioClinica();

            bool eliminado = negocio.eliminarPaciente(dni);

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

        public void LimpiarCampos()
        {

        }
    }
}