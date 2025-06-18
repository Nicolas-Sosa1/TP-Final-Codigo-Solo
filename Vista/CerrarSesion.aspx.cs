using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class CerrarSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user;
            user = Session["Usuario"].ToString();
            lblUsuario.Text = user;
        }

        protected void btnSi_Click(object sender, EventArgs e)
        {
            // Reiniciar variables Session
            Session["Usuario"] = null;
            Session["TipoUsuario"] = null;
            Server.Transfer("Inicio.aspx");
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            string tipo = Session["TipoUsuario"].ToString();

            if (tipo == "Admin")
                Server.Transfer("PanelUsuarioAdministrador.aspx");
            if (tipo == "Medico")
                Server.Transfer("PanelUsuarioMedico.aspx");
        }
    }
}