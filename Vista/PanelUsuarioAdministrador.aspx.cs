using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class PanelAdministrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user;
            user = Session["Usuario"].ToString();
            lblNombreUsuario.Text = user;
        }

        protected void btnPacientes_Click(object sender, EventArgs e)
        {
            Server.Transfer("PanelPacientes.aspx");
        }

        protected void btnMedicos_Click(object sender, EventArgs e)
        {
            Server.Transfer("PanelMedicos.aspx");
        }

        protected void btnTurnos_Click(object sender, EventArgs e)
        {
            Server.Transfer("AsignarTurnos.aspx");
        }

        protected void btnInformes_Click(object sender, EventArgs e)
        {
            Server.Transfer("Informes.aspx");
        }
    }
}