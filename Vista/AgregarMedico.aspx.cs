using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vista
{
    public partial class AgregarMedicos : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (IsPostBack == false)
            {
                cargaDdlProvincias();
                cargarDdlSexo();
                cargaDdlEspecialidades();
                cargarDdlSexo();
                cargarDdlDias();
                cargarDdlHorarios();

                string user;
                user = Session["Usuario"].ToString();
                lblNombreUsuario.Text = user;
            }
        }

        public void cargaDdlProvincias()
        {
            DataTable dataTable = negocioClinica.getTablaProvincias();
            ddlProvincia.DataSource = dataTable;
            ddlProvincia.DataTextField = "DescripcionProvincia";
            ddlProvincia.DataValueField = "Id_Provincia";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione provincia --", "0"));

        }


        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvincia.SelectedValue != "0")
            {
                // Crear y llenar el objeto Provincias
                Provincias provinciaSeleccionada = new Provincias();
                provinciaSeleccionada.setId_Provincia(int.Parse(ddlProvincia.SelectedValue));

                // Obtener las localidades desde la capa de negocio
                DataTable localidades = negocioClinica.getLocalidadesPorProvincia(provinciaSeleccionada);

                // Cargar el DropDownList de localidades
                ddlLocalidad.DataSource = localidades;
                ddlLocalidad.DataTextField = "DescripcionLocalidad";
                ddlLocalidad.DataValueField = "Id_Localidad";
                ddlLocalidad.DataBind();

                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione localidad --", "0"));
            }
            else
            {
                // Limpia si no hay provincia seleccionada
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione localidad --", "0"));

            }
        }

        public void cargarDdlSexo()
        {
            DataTable dataTable = negocioClinica.getTablaSexo();
            ddlSexo.DataSource = dataTable;
            ddlSexo.DataTextField = "Descripcion_Sexo";
            ddlSexo.DataValueField = "Id_Sexo";
            ddlSexo.DataBind();
            ddlSexo.Items.Insert(0, new ListItem("-- Seleccione un sexo --", "0"));

        }

        public void cargaDdlEspecialidades()
        {
            DataTable dataTable = negocioClinica.getTablaEspecialidades();
            ddlEspecialidades.DataSource = dataTable;
            ddlEspecialidades.DataTextField = "DescripcionEspecialidad";
            ddlEspecialidades.DataValueField = "Id_Especialidad";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccione una especialidad --", "0"));

        }

        public void cargarDdlDias()
        {
            DataTable dataTable = negocioClinica.getTablaDias();
            cblDias.DataSource = dataTable;
            cblDias.DataTextField = "DescripcionDia";
            cblDias.DataValueField = "Id_Dia";
            cblDias.DataBind();
           

        }

        public void cargarDdlHorarios()
        {
            DataTable horarios = negocioClinica.getTablaHorarios();
            ddlHorarioAtencion.DataSource = horarios;
            ddlHorarioAtencion.DataTextField = "DescripcionHorario";
            ddlHorarioAtencion.DataValueField = "Id_Horario";        
            ddlHorarioAtencion.DataBind();

            ddlHorarioAtencion.Items.Insert(0, new ListItem("-- Seleccione un horario --", "0"));
        }

        protected void btnAgregarMedico_Click(object sender, EventArgs e)
        {
            Medicos medico = new Medicos();
            medico.SetLegajo(txtLegajo.Text);
            medico.SetDNI(txtDNI.Text);
            medico.SetNombre(txtNombre.Text);
            medico.SetApellido(txtApellido.Text);
            medico.SetId_Sexo(int.Parse(ddlSexo.SelectedValue));
            medico.SetNacionalidad(txtNacionalidad.Text);
            medico.SetFechaNacimiento(DateTime.Parse(txtFechaNac.Text));
            medico.SetDireccion(txtDireccion.Text);
            medico.SetId_Localidad(int.Parse(ddlLocalidad.SelectedValue));
            medico.SetEmail(txtCorreo.Text);
            medico.SetTelefono(txtTelefono.Text);
            medico.SetId_Especialidad(int.Parse(ddlEspecialidades.SelectedValue));


            Usuarios usuario = new Usuarios();
            usuario.SetNombreUsuario(txtUsuario.Text);
            usuario.SetContrasena(txtContra.Text);
            usuario.SetTipoUsuario("Medico");
            usuario.SetLegajo_Medico(txtLegajo.Text);

            string resultado = negocioClinica.RegistrarMedicoYUsuario(medico, usuario);

            if (resultado == "OK")
            {
                // Obtener días seleccionados
                List<int> diasSeleccionados = new List<int>();
                foreach (ListItem item in cblDias.Items)
                {
                    if (item.Selected)
                        diasSeleccionados.Add(int.Parse(item.Value)); // Valores: 1 a 7
                }

                // Obtener horario
                int idHorario = int.Parse(ddlHorarioAtencion.SelectedValue);

                // Registrar las fechas que corresponden a esos días
                negocioClinica.RegistrarFechasAtencion(medico.GetLegajo(), diasSeleccionados, idHorario);

                lblMensaje.Text = "✔ Registro exitoso con fechas de atención.";
            }

        }

        public void limpiarCampos()
        {

        }
    }
}