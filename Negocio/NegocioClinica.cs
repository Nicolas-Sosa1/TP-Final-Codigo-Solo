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





        public int agregarMedico(Medicos medicos)
        {
            Dao dao = new Dao();
            return dao.agregarMedico(medicos);
        }

        public int agregarUsuario(Usuarios usuarios)
        {
            Dao dao = new Dao();
            return dao.agregarUsuario(usuarios);
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
