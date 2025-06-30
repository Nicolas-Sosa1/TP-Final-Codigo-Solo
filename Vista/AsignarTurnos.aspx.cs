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
    public partial class AsignarTurnos : System.Web.UI.Page
    {
        NegocioClinica negocioClinica = new NegocioClinica();
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;

            if (IsPostBack == false)
            {
                cargaDdlEspecialidades();
                cargarDdlPacientes();

                //string user;
               // user = Session["Usuario"].ToString();
                //lblUsuario.Text = user;

            }
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            if (ddlEspecialidades.SelectedIndex == 0 ||
        ddlMedicos.SelectedIndex == 0 ||
        ddlDias.SelectedIndex == 0 ||
        ddlHorarios.SelectedIndex == 0 ||
        ddlHora.SelectedIndex == 0 ||
        ddlPacientes.SelectedIndex == 0 ||
        string.IsNullOrEmpty(txtFechaTurno.Text))
            {
                lblMensaje.Text = "⚠️ Complete todos los campos antes de continuar.";
                return;
            }

            try
            {
                Turnos turno = new Turnos();

                turno.setId_Dia(int.Parse(ddlDias.SelectedValue));
                turno.setId_Horario(int.Parse(ddlHorarios.SelectedValue));
                turno.setFecha(DateTime.Parse(txtFechaTurno.Text));
                turno.setLegajo_Medico(ddlMedicos.SelectedValue);
                turno.setDNI_Paciente(ddlPacientes.SelectedValue);
                turno.setHora(TimeSpan.Parse(ddlHora.SelectedValue));
                turno.setEstadoTurno("Pendiente");
                turno.setObservacion(""); // o string.Empty


                // Validar si ya existe turno
                if (negocioClinica.ExisteTurno(turno.getLegajo_Medico(), turno.getFecha(), turno.getHora()))
                {
                    lblMensaje.Text = "⚠️ El médico ya tiene un turno en ese horario.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                bool resultado = negocioClinica.RegistrarTurno(turno);

                if (resultado)
                {
                    lblMensaje.Text = "✅ Turno registrado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    limpiarCampos();
                }
                else
                {
                    lblMensaje.Text = "❌ No se pudo registrar el turno.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"❌ Error: {ex.Message}";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
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

        public void cargarDdlPacientes()
        {
            DataTable pacientes = negocioClinica.getTablaPacientes();
            ddlPacientes.DataSource = pacientes;
            ddlPacientes.DataTextField = "Nombre"; // o solo "Nombre"
            ddlPacientes.DataValueField = "Documento"; // asegurate que esta sea la columna correcta
            ddlPacientes.DataBind();
            ddlPacientes.Items.Insert(0, new ListItem("-- Seleccione un paciente --", ""));
        }




        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idEspecialidad = int.Parse(ddlEspecialidades.SelectedValue);
            DataTable medicos = negocioClinica.GetMedicosPorEspecialidad(idEspecialidad);
            ddlMedicos.DataSource = medicos;
            ddlMedicos.DataTextField = "NombreCompleto";
            ddlMedicos.DataValueField = "Legajo";
            ddlMedicos.DataBind();
            ddlMedicos.Items.Insert(0, new ListItem("-- Seleccione un médico --", "0"));
        }

        protected void ddlMedicos_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime fecha;
            if (DateTime.TryParse(txtFechaTurno.Text, out fecha))
            {
                int legajo = int.Parse(ddlMedicos.SelectedValue);
                DataTable dias = negocioClinica.ObtenerDiasDisponibles(legajo, fecha);

                ddlDias.DataSource = dias;
                ddlDias.DataTextField = "DescripcionDia";
                ddlDias.DataValueField = "Id_Dia";
                ddlDias.DataBind();
                ddlDias.Items.Insert(0, new ListItem("-- Seleccione un día --", "0"));
            }
        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDias.SelectedIndex > 0 && ddlMedicos.SelectedIndex > 0 && DateTime.TryParse(txtFechaTurno.Text, out DateTime fecha))
            {
                int idDia = int.Parse(ddlDias.SelectedValue);
                string legajo = ddlMedicos.SelectedValue;

                DataTable horarios = negocioClinica.ObtenerHorariosDisponibles(idDia, int.Parse(legajo), fecha);

                // Agregar columna manual si no existe
                if (!horarios.Columns.Contains("DescripcionHorario"))
                    horarios.Columns.Add("DescripcionHorario", typeof(string));

                foreach (DataRow row in horarios.Rows)
                {
                    TimeSpan desde = (TimeSpan)row["HoraDesde"];
                    TimeSpan hasta = (TimeSpan)row["HoraHasta"];
                    row["DescripcionHorario"] = $"{desde:hh\\:mm} - {hasta:hh\\:mm}";
                }

                ddlHorarios.DataSource = horarios;
                ddlHorarios.DataTextField = "DescripcionHorario";
                ddlHorarios.DataValueField = "Id_Horario";
                ddlHorarios.DataBind();
                ddlHorarios.Items.Insert(0, new ListItem("-- Seleccione un horario --", "0"));
            }

        }

        protected void ddlHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHorarios.SelectedIndex > 0 && ddlMedicos.SelectedIndex > 0 && DateTime.TryParse(txtFechaTurno.Text, out DateTime fecha))
            {
                int idHorario = int.Parse(ddlHorarios.SelectedValue);
                int idDia = int.Parse(ddlDias.SelectedValue);
                string legajo = ddlMedicos.SelectedValue;

                DataTable horas = negocioClinica.ObtenerHorasDisponibles(idDia, idHorario, fecha, legajo);

                ddlHora.Items.Clear();
                foreach (DataRow row in horas.Rows)
                {
                    string hora = row["Hora"].ToString();
                    ddlHora.Items.Add(new ListItem(hora, hora));
                }
                ddlHora.Items.Insert(0, new ListItem("-- Seleccione una hora --", ""));
            }
        }

        public void limpiarCampos()
        {
            txtFechaTurno.Text = "";

            // Recargar especialidades
            cargaDdlEspecialidades();

            // Reiniciar médicos (vuelve a cargar luego de seleccionar especialidad)
            ddlMedicos.Items.Clear();
            ddlMedicos.Items.Insert(0, new ListItem("-- Seleccione un médico --", "0"));

            // Reiniciar días
            ddlDias.Items.Clear();
            ddlDias.Items.Insert(0, new ListItem("-- Seleccione un día --", "0"));

            // Reiniciar horarios
            ddlHorarios.Items.Clear();
            ddlHorarios.Items.Insert(0, new ListItem("-- Seleccione un horario --", "0"));

            // Reiniciar horas
            ddlHora.Items.Clear();
            ddlHora.Items.Insert(0, new ListItem("-- Seleccione una hora --", ""));

            // Recargar pacientes
            cargarDdlPacientes();



        }
    }
}