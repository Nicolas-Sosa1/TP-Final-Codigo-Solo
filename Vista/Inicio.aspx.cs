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
    public partial class InicioAdmin : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContra.Text.Trim();

            DataTable dt = negocioClinica.validarLogin(usuario, contraseña);

            if (dt.Rows.Count == 1)
            {
                string tipo = dt.Rows[0]["TipoUsuario"].ToString();

                Session["Usuario"] = usuario;

                if (tipo == "Admin")
                {
                    Session["IdAdministrador"] = dt.Rows[0]["Id_Administrador"];
                    Response.Redirect("PanelUsuarioAdministrador.aspx");
                }
                else if (tipo == "Medico")
                {
                    Session["LegajoMedico"] = dt.Rows[0]["Legajo_Medico"];
                    Response.Redirect("PanelUsuarioMedico.aspx");
                }
                else
                {
                    lblMensaje.Text = "Tipo de usuario desconocido.";
                }
            }
            else
            {
                lblMensaje.Text = "Usuario o contraseña incorrectos.";
            }

        }
    }
}