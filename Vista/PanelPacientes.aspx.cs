using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;


namespace Vista
{
    public partial class PanelPacientes : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (IsPostBack == false)
            {
                cargarGridView();

                string user;
                user = Session["Usuario"].ToString();
                lblUsuario.Text = user;
            }
        }

        public void cargarGridView()
        {
            DataTable dataTable = negocioClinica.getTablaPacientes();
            gvPacientes.DataSource = dataTable;
            gvPacientes.DataBind();
            
        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            cargarGridView();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            

        }

        protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPacientes.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void gvPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPacientes.EditIndex = -1;
            cargarGridView();
        }

        protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPacientes.Rows[e.RowIndex];

            Pacientes paciente = new Pacientes();

            paciente.setDni(((Label)row.FindControl("lbl_eit_dni")).Text);
            paciente.setNombre(((TextBox)row.FindControl("txt_eit_nombre")).Text);
            paciente.setApellido(((TextBox)row.FindControl("txt_eit_apellido")).Text);

            DropDownList ddlSexo = (DropDownList)row.FindControl("ddlSexo");
            paciente.setId_Sexo(int.Parse(ddlSexo.SelectedValue));

            paciente.setNacionalidad(((TextBox)row.FindControl("txt_eit_nacionalidad")).Text);

            TextBox txtFecha = (TextBox)row.FindControl("txt_eit_fecha_nac");
            paciente.setFechaNacimiento(DateTime.Parse(txtFecha.Text));

            paciente.setDireccion(((TextBox)row.FindControl("txt_eit_direccion")).Text);

            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidad");
            paciente.setId_Localidad(int.Parse(ddlLocalidad.SelectedValue));

            paciente.setEmail(((TextBox)row.FindControl("txt_eit_correo")).Text);
            paciente.setTelefono(((TextBox)row.FindControl("txt_eit_telefono")).Text);

           

            negocioClinica.ActualizarPaciente(paciente);

            gvPacientes.EditIndex = -1;
            cargarGridView();
        }

        

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlProvincia = (DropDownList)sender;
            GridViewRow row = (GridViewRow)ddlProvincia.NamingContainer;

            if (row != null)
            {
                DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidad");
                int idProvincia = int.Parse(ddlProvincia.SelectedValue);

                ddlLocalidad.DataSource = negocioClinica.ObtenerLocalidadesPorProvincia(idProvincia);
                ddlLocalidad.DataTextField = "DescripcionLocalidad";
                ddlLocalidad.DataValueField = "Id_Localidad";
                ddlLocalidad.DataBind();

                ddlLocalidad.Items.Insert(0, new ListItem("Seleccione", ""));
            }
        }

        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                int idLocalidad = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Localidad"));
                int idProvincia = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Provincia"));
                int Id_Sexo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Sexo"));

                // ddlProvincia
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("ddlProvincia");
                ddlProvincia.DataSource = negocioClinica.getTablaProvincias();
                ddlProvincia.DataTextField = "DescripcionProvincia";
                ddlProvincia.DataValueField = "Id_Provincia";
                ddlProvincia.DataBind();
                ddlProvincia.SelectedValue = idProvincia.ToString();

                // ddlLocalidad
                DropDownList ddlLocalidad = (DropDownList)e.Row.FindControl("ddlLocalidad");
                ddlLocalidad.DataSource = negocioClinica.ObtenerLocalidadesPorProvincia(idProvincia);
                ddlLocalidad.DataTextField = "DescripcionLocalidad";
                ddlLocalidad.DataValueField = "Id_Localidad";
                ddlLocalidad.DataBind();
                ddlLocalidad.SelectedValue = idLocalidad.ToString();

                // ddlSexo
                DropDownList ddlSexo = (DropDownList)e.Row.FindControl("ddlSexo");
                ddlSexo.DataSource = negocioClinica.getTablaSexo();
                ddlSexo.DataTextField = "Descripcion_Sexo";
                ddlSexo.DataValueField = "Id_Sexo";
                ddlSexo.DataBind();
                ddlSexo.SelectedValue = Id_Sexo.ToString();
            }

        }
    }
}