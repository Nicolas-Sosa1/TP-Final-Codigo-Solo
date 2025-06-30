using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vista
{
    public partial class PanelMedicos : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (IsPostBack == false)
            {
                cargarGridView();

                //string user;
               // user = Session["Usuario"].ToString();
                //lblNombreUsuario.Text = user;
            }
        }

        public void cargarGridView()
        {
            DataTable dataTable = negocioClinica.getTablaMedicos();
            gvMedicos.DataSource = dataTable;
            gvMedicos.DataBind();

        }

        protected void btnMostrar_Click(object sender, EventArgs e)
        {
            cargarGridView();
            limpiarTodos();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string criterio = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(criterio))
            {
                DataTable dt = negocioClinica.BuscarMedicos(criterio);

                gvMedicos.DataSource = dt;
                gvMedicos.DataBind();
            }
           
        }

        private void limpiarTodos()
        {
            txtBuscar.Text = "";
        }

        protected void gvMedicos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedicos.EditIndex = -1;
            cargarGridView();
        }

        protected void gvMedicos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMedicos.EditIndex = e.NewEditIndex;
            cargarGridView();
        }

        protected void gvMedicos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvMedicos.Rows[e.RowIndex];

            Medicos medicos = new Medicos();
            medicos.SetLegajo(((Label)row.FindControl("lbl_eit_legajo")).Text);
            medicos.SetDNI(((Label)row.FindControl("lbl_eit_dni")).Text);
            medicos.SetNombre(((TextBox)row.FindControl("txt_eit_nombre")).Text);
            medicos.SetApellido(((TextBox)row.FindControl("txt_eit_apellido")).Text);

            DropDownList ddlSexo = (DropDownList)row.FindControl("ddlSexo");
            medicos.SetId_Sexo(int.Parse(ddlSexo.SelectedValue));

            medicos.SetNacionalidad(((TextBox)row.FindControl("txt_eit_nacionalidad")).Text);

            TextBox txtFecha = (TextBox)row.FindControl("txt_eit_fecha_nac");
            medicos.SetFechaNacimiento(DateTime.Parse(txtFecha.Text));

            medicos.SetDireccion(((TextBox)row.FindControl("txt_eit_direccion")).Text);

            DropDownList ddlLocalidad = (DropDownList)row.FindControl("ddlLocalidad");
            medicos.SetId_Localidad(int.Parse(ddlLocalidad.SelectedValue));

            medicos.SetEmail(((TextBox)row.FindControl("txt_eit_correo")).Text);
            medicos.SetTelefono(((TextBox)row.FindControl("txt_eit_telefono")).Text);

            DropDownList ddlEspecialidades = (DropDownList)row.FindControl("ddlEspecialidades");
            medicos.SetId_Especialidad(int.Parse(ddlEspecialidades.SelectedValue));

            Usuarios usuario = new Usuarios();
            usuario.SetNombreUsuario(((TextBox)row.FindControl("txt_eit_usuario")).Text);
            usuario.SetContrasena(((TextBox)row.FindControl("txt_eit_contrasena")).Text);
            usuario.SetTipoUsuario("Medico");
            usuario.SetLegajo_Medico(medicos.GetLegajo());

            // ✅ ACTUALIZAR DATOS PERSONALES
            negocioClinica.ActualizarMedico(medicos);
            negocioClinica.ActualizarUsuario(usuario);

            // ✅ ACTUALIZAR DÍAS
            CheckBoxList cblDias = (CheckBoxList)row.FindControl("cblDias");
            List<int> diasSeleccionados = new List<int>();
            foreach (ListItem item in cblDias.Items)
            {
                if (item.Selected)
                    diasSeleccionados.Add(int.Parse(item.Value));
            }

            // ✅ ACTUALIZAR HORARIOS (CheckBoxList)
            CheckBoxList cblHorarios = (CheckBoxList)row.FindControl("cblHorarios");
            List<int> horariosSeleccionados = new List<int>();
            foreach (ListItem item in cblHorarios.Items)
            {
                if (item.Selected)
                    horariosSeleccionados.Add(int.Parse(item.Value));
            }

            // ✅ Registrar fechas según días y horarios seleccionados
            if (diasSeleccionados.Count > 0 && horariosSeleccionados.Count > 0)
            {
                negocioClinica.ActualizarDiasHorariosFechasMedico(medicos.GetLegajo(), diasSeleccionados, horariosSeleccionados);
            }


            gvMedicos.EditIndex = -1;
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
            }
        }

        protected void gvMedicos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowState.HasFlag(DataControlRowState.Edit))
            {
                // Obtener los IDs necesarios desde el DataItem
                int idLocalidad = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Localidad"));
                int idProvincia = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Provincia"));
                int idEspecialidad = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Especialidad"));
                int idSexo = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Id_Sexo"));

                // Cargar ddlProvincia
                DropDownList ddlProvincia = (DropDownList)e.Row.FindControl("ddlProvincia");
                ddlProvincia.DataSource = negocioClinica.getTablaProvincias();
                ddlProvincia.DataTextField = "DescripcionProvincia";
                ddlProvincia.DataValueField = "Id_Provincia";
                ddlProvincia.DataBind();
                ddlProvincia.SelectedValue = idProvincia.ToString();

                // Cargar ddlLocalidad (según la provincia actual)
                DropDownList ddlLocalidad = (DropDownList)e.Row.FindControl("ddlLocalidad");
                ddlLocalidad.DataSource = negocioClinica.ObtenerLocalidadesPorProvincia(idProvincia);
                ddlLocalidad.DataTextField = "DescripcionLocalidad";
                ddlLocalidad.DataValueField = "Id_Localidad";
                ddlLocalidad.DataBind();
                ddlLocalidad.SelectedValue = idLocalidad.ToString();

                // Cargar ddlSexo
                DropDownList ddlSexo = (DropDownList)e.Row.FindControl("ddlSexo");
                ddlSexo.DataSource = negocioClinica.getTablaSexo();
                ddlSexo.DataTextField = "Descripcion_Sexo";
                ddlSexo.DataValueField = "Id_Sexo";
                ddlSexo.DataBind();
                ddlSexo.SelectedValue = idSexo.ToString();

                // Cargar ddlEspecialidades
                DropDownList ddlEspecialidades = (DropDownList)e.Row.FindControl("ddlEspecialidades");
                ddlEspecialidades.DataSource = negocioClinica.getTablaEspecialidades();
                ddlEspecialidades.DataTextField = "DescripcionEspecialidad"; 
                ddlEspecialidades.DataValueField = "Id_Especialidad";
                ddlEspecialidades.DataBind();
                ddlEspecialidades.SelectedValue = idEspecialidad.ToString();


                // Obtener el legajo del médico actual
                string legajo = DataBinder.Eval(e.Row.DataItem, "Legajo").ToString();

                // Obtener los días y horarios asignados desde la BD
                DataTable diasHorarios = negocioClinica.GetDiasHorariosPorMedico(legajo);

                // Cargar CheckBoxList de días
                CheckBoxList cblDias = (CheckBoxList)e.Row.FindControl("cblDias");
                cblDias.DataSource = negocioClinica.getTablaDias();
                cblDias.DataTextField = "DescripcionDia";
                cblDias.DataValueField = "Id_Dia";
                cblDias.DataBind();

                // Marcar los días que tiene asignados
                foreach (ListItem item in cblDias.Items)
                {
                    if (diasHorarios.AsEnumerable().Any(r => r["Id_Dia"].ToString() == item.Value))
                    {
                        item.Selected = true;
                    }
                }

                CheckBoxList cblHorarios = (CheckBoxList)e.Row.FindControl("cblHorarios");
                DataTable horarios = negocioClinica.getTablaHorarios();
                cblHorarios.DataSource = horarios;
                cblHorarios.DataTextField = "DescripcionHorario";
                cblHorarios.DataValueField = "Id_Horario";
                cblHorarios.DataBind();

                // Marcar los horarios ya asignados al médico
                foreach (ListItem item in cblHorarios.Items)
                {
                    if (diasHorarios.AsEnumerable().Any(r => r["Id_Horario"].ToString() == item.Value))
                    {
                        item.Selected = true;
                    }
                }

            }
        }

        protected void gvMedicos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMedicos.PageIndex = e.NewPageIndex;
            cargarGridView();
        }
    }
}