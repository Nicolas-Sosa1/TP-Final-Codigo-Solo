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
    public partial class AgregarPaciente : System.Web.UI.Page
    {

        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (IsPostBack == false)
            {
                cargaDdlProvincias();
                cargarDdlSexo();
                cargarDdlSexo();

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

        protected void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            Pacientes pacientes = new Pacientes();
            pacientes.setDni(txtDNI.Text);
            pacientes.setNombre(txtNombre.Text);
            pacientes.setApellido(txtApellido.Text);
            pacientes.setId_Sexo(Convert.ToInt32(ddlSexo.SelectedValue));
            pacientes.setNacionalidad(txtNacionalidad.Text);
            pacientes.setFechaNacimiento(DateTime.Parse(txtFechaNac.Text));
            pacientes.setDireccion(txtDireccion.Text);
            pacientes.setId_Localidad(Convert.ToInt32(ddlLocalidad.SelectedValue));
            pacientes.setEmail(txtCorreo.Text);
            pacientes.setTelefono(txtTelefono.Text);

            int resultado = negocioClinica.agregarPaciente(pacientes);

            if (resultado > 0)
            {
                lblMensaje.Text = "Sucursal agregada con éxito.";
                lblMensaje.ForeColor = Color.Green;
            }
            else
            {
                lblMensaje.Text = "Ocurrió un error al agregar la sucursal.";
                lblMensaje.ForeColor = Color.Red;
            }

            limpiarCampos();
        }

        public void limpiarCampos()
        {

        }
    }
}

