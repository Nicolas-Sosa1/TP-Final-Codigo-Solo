using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class NegocioClinica
    {
        public DataTable getTablaProvincias()
        {
            Dao dao = new Dao();
            return dao.ObtenerTodasLasProvincias();
        }

        public DataTable getLocalidadesPorProvincia(Provincias provincia)
        {
            Dao dao = new Dao();
            return dao.ObtenerLocalidadesPorProvincia(provincia);
        }

        public DataTable getTablaSexo()
        {
            Dao dao = new Dao();
            return dao.ObtenerTodosLosSexos();
        }

        public DataTable getTablaEspecialidades()
        {
            Dao dao = new Dao();
            return dao.ObtenerTodasLasEspecialidades();
        }

        public DataTable getTablaDias()
        {
            Dao dao = new Dao();
            return dao.ObtenerTodosLosDias();
        }

        public DataTable getTablaHorarios()
        {
            Dao dao = new Dao();
            return dao.ObtenerTodosLosHorarios();
        }

        public int agregarPaciente(Pacientes pacientes)
        {
            Dao dao = new Dao();
            return dao.agregarPaciente(pacientes);
        }

        public bool eliminarPaciente(string dni)
        {
            //Validar id existente 
            Dao dao = new Dao();
            Pacientes pacientes = new Pacientes();
            pacientes.setDni(dni);
            int op = dao.DarBajaPaciente(pacientes);
            if (op == 1)
                return true;
            else
                return false;
        }

        public bool eliminarMedico(string legajo)
        {
            //Validar id existente 
            Dao dao = new Dao();
            Medicos medicos = new Medicos();
            medicos.SetLegajo(legajo);
            int op = dao.DarBajaMedico(medicos);
            if (op == 1)
                return true;
            else
                return false;
        }

        public DataTable getTablaPacientes()
        {
            Dao dao = new Dao();
            return dao.ObtenerTodosLosPacientes();
        }

        public DataTable getTablaMedicos()
        {
            Dao dao = new Dao();
            return dao.ObtenerTodosLosMedicos();
        }

        public string RegistrarMedicoYUsuario(Medicos medico, Usuarios usuario)
        {
            Dao dao = new Dao();

            int resultadoMedico = dao.agregarMedico(medico); // ← Usás el método del DAO

            if (resultadoMedico <= 0)
            {
                return "Error al registrar al médico.";
            }

            usuario.SetLegajo_Medico(medico.GetLegajo()); // Asociás el legajo médico al usuario

            int resultadoUsuario = dao.agregarUsuario(usuario); // ← También desde DAO

            if (resultadoUsuario <= 0)
            {
                // opcional: dao.eliminarMedico(medico.GetLegajo());
                return "El médico fue registrado, pero ocurrió un error al registrar el usuario.";
            }

            return "OK";
        }

        public void RegistrarFechasAtencion(string legajoMedico, List<int> diasSeleccionados, int idHorario)
        {
            Dao dao = new Dao();
            DataTable fechas = dao.ObtenerTodasLasFechas();

            foreach (DataRow fila in fechas.Rows)
            {
                DateTime fecha = Convert.ToDateTime(fila["Fecha"]);
                int diaSemana = ((int)fecha.DayOfWeek + 1); // Lunes = 1, ..., Domingo = 7

                if (diasSeleccionados.Contains(diaSemana))
                {
                    // 0. Asegurar existencia del par en DiasXHorarios
                    dao.insertarDiasXHorarios(diaSemana, idHorario);

                    // 1. Insertar en tabla intermedia (solo si existe en DiasXHorarios)
                    dao.insertarDiasXHorariosXFechas(diaSemana, idHorario, fecha);

                    // 2. Insertar en tabla final con legajo del médico
                    dao.insertarDiasXHorariosXFechasXMedico(diaSemana, idHorario, fecha, legajoMedico);
                }
            }
        }


        //Seccion AsignarTurno---------------------------------------------------------------
        public bool RegistrarTurno(Turnos turnos)
        {
            Dao dao = new Dao();
            int filas = dao.InsertarTurno(turnos);
            return filas > 0;
        }

        public DataTable GetMedicosPorEspecialidad(int idEspecialidad)
        {
            Dao dao = new Dao();
            return dao.GetMedicosPorEspecialidad(idEspecialidad);
        }

        public DataTable ObtenerDiasDisponibles(int legajo, DateTime fecha)
        {
            Dao dao = new Dao();
            return dao.ObtenerDiasDisponibles(legajo, fecha);
        }

        public DataTable ObtenerHorariosDisponibles(int idDia, int legajo, DateTime fecha)
        {
            Dao dao = new Dao();
            return dao.ObtenerHorariosDisponibles(idDia, legajo, fecha);
        }

        public DataTable ObtenerHorasDisponibles(int idDia, int idHorario, DateTime fecha, string legajo)
        {
            Dao dao = new Dao();
            return dao.ObtenerHorasDisponibles(idDia, idHorario, fecha, legajo);
        }

        public bool ExisteTurno(string legajo, DateTime fecha, TimeSpan hora)
        {
            Dao dao = new Dao();
            return dao.ExisteTurno(legajo, fecha, hora);
        }


        //-------------------------------------------------------------------------------------








        public void ActualizarPaciente(Pacientes paciente)
        {
            Dao dao = new Dao();
            dao.actualizarPaciente(paciente);
        }






        public DataTable BuscarMedicos(string criterio)
        {
            Dao dao = new Dao();
            return dao.BuscarMedicos(criterio);
        }


        public DataTable validarLogin(string usuario, string contrasena)
        {
            Dao dao = new Dao();
            return dao.validarLogin(usuario, contrasena);
        }

    }
}
