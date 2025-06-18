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
            string resultado = negocio.eliminarPaciente(dni);

            switch (resultado)
            {
                case "ok":
                    lblMensaje.Text = "✅ El paciente se ha eliminado con éxito.";
                    lblMensaje.ForeColor = Color.Green;
                    LimpiarCampos();
                    break;

                case "yaBaja":
                    lblMensaje.Text = "⚠️ El paciente ya estaba dado de baja.";
                    lblMensaje.ForeColor = Color.OrangeRed;
                    break;

                case "noExiste":
                    lblMensaje.Text = "❌ No se encontró un paciente con ese DNI.";
                    lblMensaje.ForeColor = Color.Red;
                    break;

                default:
                    lblMensaje.Text = "❌ Error al intentar eliminar el paciente.";
                    lblMensaje.ForeColor = Color.Red;
                    break;
            }
        }


        public void LimpiarCampos()
        {
            txtEliminarPaciente.Text = "";
        }
    }
}