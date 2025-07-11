﻿using System;
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

            if (!IsPostBack)
            {
                cargaDdlProvincias();
                cargarDdlSexo();
                cargaDdlEspecialidades();
                cargarDdlHorarios();
                cargarDdlDias();

                // Para tener al menos un checkbox seleccionado (pero falta validar que al menos haya alguno marcado siempre)
                if (cblDias.Items.Count > 0)
                    cblDias.Items[0].Selected = true;

                string user = Session["Usuario"].ToString();
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
            ddlProvincia.Items.Insert(0, new ListItem("-- Seleccione provincia --", ""));

        }


        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlProvincia.SelectedValue) && ddlProvincia.SelectedValue != "0")
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

                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione localidad --", ""));
            }
            else
            {
                // Limpia si no hay provincia seleccionada
                ddlLocalidad.Items.Clear();
                ddlLocalidad.Items.Insert(0, new ListItem("-- Seleccione localidad --", ""));

            }
        }

        public void cargarDdlSexo()
        {
            DataTable dataTable = negocioClinica.getTablaSexo();
            ddlSexo.DataSource = dataTable;
            ddlSexo.DataTextField = "Descripcion_Sexo";
            ddlSexo.DataValueField = "Id_Sexo";
            ddlSexo.DataBind();
            ddlSexo.Items.Insert(0, new ListItem("-- Seleccione un sexo --", ""));

        }

        public void cargaDdlEspecialidades()
        {
            DataTable dataTable = negocioClinica.getTablaEspecialidades();
            ddlEspecialidades.DataSource = dataTable;
            ddlEspecialidades.DataTextField = "DescripcionEspecialidad";
            ddlEspecialidades.DataValueField = "Id_Especialidad";
            ddlEspecialidades.DataBind();
            ddlEspecialidades.Items.Insert(0, new ListItem("-- Seleccione una especialidad --", ""));

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

            ddlHorarioAtencion.Items.Insert(0, new ListItem("-- Seleccione un horario --", ""));
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
                    {
                        diasSeleccionados.Add(int.Parse(item.Value));
                    }
                }

                // Obtener horario
                int idHorario = int.Parse(ddlHorarioAtencion.SelectedValue);

                // Registrar las fechas que corresponden a esos días
                negocioClinica.RegistrarFechasAtencion(medico.GetLegajo(), diasSeleccionados, idHorario);

                lblMensaje.Text = "✔ Registro exitoso.";
                lblMensaje.ForeColor = Color.Green;
            }
            else
            {
                lblMensaje.Text = resultado; // Da el mensaje segun error (legajo o DNI)
                lblMensaje.ForeColor = Color.Red;
            }

            LimpiarCampos();

        }

        public void LimpiarCampos()
        {
            txtLegajo.Text = "";
            txtDNI.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            ddlSexo.SelectedIndex = 0;
            txtNacionalidad.Text = "";
            txtFechaNac.Text = "";
            txtDireccion.Text = "";
            ddlProvincia.SelectedIndex = 0;
            ddlLocalidad.SelectedIndex = 0;
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            ddlEspecialidades.SelectedIndex = 0;
            
            // Para que siempre quede Lunes por defecto, pero se sigue pudiendo destildar
            if (cblDias.Items.Count > 0) 
            {
                cblDias.Items[0].Selected = true;
                cblDias.Items[1].Selected = false;
                cblDias.Items[2].Selected = false;
                cblDias.Items[3].Selected = false;
                cblDias.Items[4].Selected = false;
                cblDias.Items[5].Selected = false;
                cblDias.Items[6].Selected = false;
            }

            ddlHorarioAtencion.SelectedIndex = 0;
            txtUsuario.Text = "";
            txtContra.Text = "";
            txtRepetirContra.Text = "";

        }
    }
}