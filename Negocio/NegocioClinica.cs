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

        



    }
}
