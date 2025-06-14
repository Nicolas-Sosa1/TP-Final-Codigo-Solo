using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;




namespace Datos
{
    public class Dao
    {
        AccesoDatos accesoDatos = new AccesoDatos();

        public DataTable ObtenerTodasLasProvincias()
        {
            DataTable dataTable = accesoDatos.ObtenerTabla("Provincias", "SELECT * FROM Provincias");
            return dataTable;
        }

        public DataTable ObtenerTodosLosSexos()
        {
            DataTable dataTable = accesoDatos.ObtenerTabla("Sexo", "SELECT * FROM Sexo");
            return dataTable;
        }

        public DataTable ObtenerTodasLasEspecialidades()
        {
            DataTable dataTable = accesoDatos.ObtenerTabla("Especialidades", "SELECT * FROM Especialidades");
            return dataTable;

        }

        public DataTable ObtenerTodosLosDias()
        {
            DataTable dataTable = accesoDatos.ObtenerTabla("Dias", "SELECT * FROM Dias");
            return dataTable;

        }


        public DataTable ObtenerLocalidadesPorProvincia(Provincias provincia)
        {
            string consulta = "SELECT * FROM Localidades WHERE Id_Provincia = @idProvincia";

            SqlConnection conexion = new AccesoDatos().ObtenerConexion();
            SqlCommand comando = new SqlCommand(consulta, conexion);
            ArmarParametrosLocalidadesPorProvincia(ref comando, provincia);

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            DataSet dataSet = new DataSet();
            adaptador.Fill(dataSet, "Localidades");

            conexion.Close();

            return dataSet.Tables["Localidades"];
        }



        private void ArmarParametrosLocalidadesPorProvincia(ref SqlCommand sqlCommand, Provincias provincias)
        {
           
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = sqlCommand.Parameters.Add("@idProvincia", SqlDbType.Int);
            SqlParametros.Value = provincias.getId_Provincia();
        }

        private void ArmarParametrosAgregarPaciente(ref SqlCommand Comando, Pacientes pacientes)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = pacientes.getDni();
            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            SqlParametros.Value = pacientes.getNombre();
            SqlParametros = Comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
            SqlParametros.Value = pacientes.getApellido();
            SqlParametros = Comando.Parameters.Add("@Id_Sexo", SqlDbType.Int);
            SqlParametros.Value = pacientes.getId_Sexo();
            SqlParametros = Comando.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            SqlParametros.Value = pacientes.getNacionalidad();
            SqlParametros = Comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
            SqlParametros.Value = pacientes.getFechaNacimiento();
            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.VarChar);
            SqlParametros.Value = pacientes.getDireccion();
            SqlParametros = Comando.Parameters.Add("@Id_Localidad", SqlDbType.Int);
            SqlParametros.Value = pacientes.getId_Localidad();
            SqlParametros = Comando.Parameters.Add("@Email", SqlDbType.VarChar);
            SqlParametros.Value = pacientes.getEmail();
            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.VarChar);
            SqlParametros.Value = pacientes.getTelefono();


        }

        public int agregarPaciente(Pacientes pacientes)
        {

            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarPaciente(ref comando, pacientes);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarPaciente");
        }


        private void ArmarParametrosBajaPaciente(ref SqlCommand Comando, Pacientes pacientes)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Int);
            SqlParametros.Value = pacientes.getDni();
        }


        public int DarBajaPaciente(Pacientes pacientes)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosBajaPaciente(ref comando, pacientes);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spEliminarPaciente");
        }

        private void ArmarParametrosBajaMedico(ref SqlCommand Comando, Medicos medicos)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Legajo", SqlDbType.Char);
            SqlParametros.Value = medicos.GetLegajo();
        }
        public int DarBajaMedico(Medicos medicos)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosBajaMedico(ref comando, medicos);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spEliminarMedico");
        }

    }
}

/*
 CREATE PROCEDURE spAgregarPaciente
    @DNI CHAR(8),
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @Id_Sexo INT,
    @Nacionalidad VARCHAR(50),
    @FechaNacimiento DATE,
    @Direccion VARCHAR(50),
    @Id_Localidad INT,
    @Email VARCHAR(50),
    @Telefono VARCHAR(50)
AS
BEGIN
    INSERT INTO Pacientes (
        DNI,
        Nombre,
        Apellido,
        Id_Sexo,
        Nacionalidad,
        FechaNacimiento,
        Direccion,
        Id_Localidad,
        Email,
        Telefono
        -- Estado no se incluye porque tiene DEFAULT 1
    )
    VALUES (
        @DNI,
        @Nombre,
        @Apellido,
        @Id_Sexo,
        @Nacionalidad,
        @FechaNacimiento,
        @Direccion,
        @Id_Localidad,
        @Email,
        @Telefono
    )
END
*/

/*
 CREATE PROCEDURE spEliminarPaciente
    @DNI CHAR(8)
AS
BEGIN
    UPDATE Pacientes
    SET Estado = 0
    WHERE DNI = @DNI
END
*/


/*
  CREATE PROCEDURE spEliminarMedico
    @Legajo CHAR(6)
AS
BEGIN
    UPDATE Medicos
    SET Estado = 0
    WHERE Legajo = @Legajo
END
*/