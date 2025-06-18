using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Turnos
    {
        private int Id_Turno;
        private int Id_Dia;
        private int Id_Horario;
        private DateTime Fecha;
        private string Legajo_Medico;
        private string DNI_Paciente;
        private TimeSpan Hora;
        private string EstadoTurno;
        private string Observacion;

        public void setId_Turno(int id)
        {
            Id_Turno = id;
        }

        public int getId_Turno()
        {
            return Id_Turno;
        }

        public void setId_Dia(int idDia)
        {
            Id_Dia = idDia;
        }

        public int getId_Dia()
        {
            return Id_Dia;
        }

        public void setId_Horario(int idHorario)
        {
            Id_Horario = idHorario;
        }

        public int getId_Horario()
        {
            return Id_Horario;
        }

        public void setFecha(DateTime fecha)
        {
            Fecha = fecha;
        }

        public DateTime getFecha()
        {
            return Fecha;
        }

        public void setLegajo_Medico(string legajo)
        {
            Legajo_Medico = legajo;
        }

        public string getLegajo_Medico()
        {
            return Legajo_Medico;
        }

        public void setDNI_Paciente(string dni)
        {
            DNI_Paciente = dni;
        }

        public string getDNI_Paciente()
        {
            return DNI_Paciente;
        }

        public void setHora(TimeSpan horaTurno)
        {
            Hora = horaTurno;
        }

        public TimeSpan getHora()
        {
            return Hora;
        }

        public void setEstadoTurno(string estado)
        {
            EstadoTurno = estado;
        }

        public string getEstadoTurno()
        {
            return EstadoTurno;
        }

        public void setObservacion(string observacion)
        {
            Observacion = observacion;
        }

        public string getObservacion()
        {
            return Observacion;
        }
    }
}
