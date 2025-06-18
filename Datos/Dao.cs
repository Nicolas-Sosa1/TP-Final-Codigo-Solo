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

        public DataTable ObtenerTodosLosPacientes()
        {
            string consulta = @"
        SELECT 
            p.DNI AS 'Documento',
            p.Nombre AS 'Nombre',
            p.Apellido AS 'Apellido',
            s.Descripcion_Sexo AS 'Sexo',
            p.Nacionalidad AS 'Nacionalidad',
            p.FechaNacimiento AS 'Fecha de nacimiento',
            p.Direccion AS 'Dirección',
            l.DescripcionLocalidad AS 'Localidad',
            p.Email AS 'Correo electrónico',
            p.Telefono AS 'Teléfono',
            p.Estado AS 'Estado'
        FROM Pacientes p
        JOIN Sexo s ON p.Id_Sexo = s.Id_Sexo
        JOIN Localidades l ON p.Id_Localidad = l.Id_Localidad
        WHERE p.Estado = 1";

            return accesoDatos.ObtenerTabla("Pacientes", consulta);
        }

        public DataTable ObtenerTodosLosMedicos()
        {
            string consulta = @"
        SELECT 
            m.Legajo AS 'Legajo',
            m.DNI AS 'Documento',
            m.Nombre AS 'Nombre',
            m.Apellido AS 'Apellido',
            s.Descripcion_Sexo AS 'Sexo',
            m.Nacionalidad AS 'Nacionalidad',
            m.FechaNacimiento AS 'Fecha de nacimiento',
            m.Direccion AS 'Dirección',
            l.DescripcionLocalidad AS 'Localidad',
            e.DescripcionEspecialidad AS 'Especialidad',
            m.Email AS 'Correo electrónico',
            m.Telefono AS 'Teléfono',
            m.Estado AS 'Estado'
        FROM Medicos m
        JOIN Sexo s ON m.Id_Sexo = s.Id_Sexo
        JOIN Localidades l ON m.Id_Localidad = l.Id_Localidad
        JOIN Especialidades e ON m.Id_Especialidad = e.Id_Especialidad
        WHERE p.Estado = 1";

            return accesoDatos.ObtenerTabla("Medicos", consulta);
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

        public DataTable ObtenerTodosLosHorarios()
        {
            string consulta = @"
        SELECT 
            Id_Horario,
            CAST(Id_Horario AS VARCHAR(10)) + ' - ' + 
            CONVERT(VARCHAR(5), HoraDesde, 108) + ' - ' + 
            CONVERT(VARCHAR(5), HoraHasta, 108) AS DescripcionHorario
        FROM Horarios";

            return accesoDatos.ObtenerTabla("Horarios", consulta);
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


        public DataTable validarLogin(string usuario, string contraseña)
        {
            string sql = "SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contrasena = @Contrasena";

            SqlCommand comando = new SqlCommand(sql);

            SqlParameter parametroUsuario = new SqlParameter("@NombreUsuario", SqlDbType.VarChar, 50); // Ajustá el tamaño a tu DB
            parametroUsuario.Value = usuario;
            comando.Parameters.Add(parametroUsuario);

            SqlParameter parametroContrasena = new SqlParameter("@Contrasena", SqlDbType.VarChar, 50); // Ajustá el tamaño a tu DB
            parametroContrasena.Value = contraseña;
            comando.Parameters.Add(parametroContrasena);

            return accesoDatos.ObtenerTablaConParametros("Usuarios", comando);
        }


        private void ArmarParametrosAgregarMedico(ref SqlCommand Comando, Medicos medicos)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Legajo", SqlDbType.Char);
            SqlParametros.Value = medicos.GetLegajo();
            SqlParametros = Comando.Parameters.Add("@DNI", SqlDbType.Char);
            SqlParametros.Value = medicos.GetDNI();
            SqlParametros = Comando.Parameters.Add("@Nombre", SqlDbType.VarChar);
            SqlParametros.Value = medicos.GetNombre();
            SqlParametros = Comando.Parameters.Add("@Apellido", SqlDbType.VarChar);
            SqlParametros.Value = medicos.GetApellido();
            SqlParametros = Comando.Parameters.Add("@Id_Sexo", SqlDbType.Int);
            SqlParametros.Value = medicos.GetId_Sexo();
            SqlParametros = Comando.Parameters.Add("@Nacionalidad", SqlDbType.VarChar);
            SqlParametros.Value = medicos.GetNacionalidad();
            SqlParametros = Comando.Parameters.Add("@FechaNacimiento", SqlDbType.Date);
            SqlParametros.Value = medicos.GetFechaNacimiento();
            SqlParametros = Comando.Parameters.Add("@Direccion", SqlDbType.VarChar);
            SqlParametros.Value = medicos.GetDireccion();
            SqlParametros = Comando.Parameters.Add("@Id_Localidad", SqlDbType.Int);
            SqlParametros.Value = medicos.GetId_Localidad();
            SqlParametros = Comando.Parameters.Add("@Email", SqlDbType.VarChar);
            SqlParametros.Value = medicos.GetEmail();
            SqlParametros = Comando.Parameters.Add("@Telefono", SqlDbType.VarChar);
            SqlParametros.Value = medicos.GetTelefono();
            SqlParametros = Comando.Parameters.Add("@Id_Especialidad", SqlDbType.Int);
            SqlParametros.Value = medicos.GetId_Especialidad();



        }


        public int agregarMedico(Medicos medicos)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarMedico(ref comando, medicos);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarMedico");
        }


        private void ArmarParametrosAgregarUsuario(ref SqlCommand Comando, Usuarios usuarios)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@NombreUsuario", SqlDbType.VarChar);
            SqlParametros.Value = usuarios.GetNombreUsuario();
            SqlParametros = Comando.Parameters.Add("@Contrasena", SqlDbType.VarChar);
            SqlParametros.Value = usuarios.GetContrasena();
            SqlParametros = Comando.Parameters.Add("@TipoUsuario", SqlDbType.VarChar);
            SqlParametros.Value = usuarios.GetTipoUsuario();
            SqlParametros = Comando.Parameters.Add("@Legajo_Medico", SqlDbType.Char);
            SqlParametros.Value = usuarios.GetLegajo_Medico();


        }

        public int agregarUsuario(Usuarios usuarios)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosAgregarUsuario(ref comando, usuarios);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spAgregarUsuario");
        }


        //Seccion Dias Horarios FECHA
        //------------------------------------------------------------------------------------------------
        private void ArmarParametrosDiasXHorarios(ref SqlCommand comando, int idDia, int idHorario)
        {
            comando.Parameters.Add("@Id_Dia", SqlDbType.Int).Value = idDia;
            comando.Parameters.Add("@Id_Horario", SqlDbType.Int).Value = idHorario;
        }

        public int insertarDiasXHorarios(int idDia, int idHorario)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDiasXHorarios(ref comando, idDia, idHorario);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spInsertarDiasXHorarios");
        }


        private void ArmarParametrosDiasXHorariosXFechas(ref SqlCommand comando, int idDia, int idHorario, DateTime fecha)
        {
            comando.Parameters.Add("@Id_Dia", SqlDbType.Int).Value = idDia;
            comando.Parameters.Add("@Id_Horario", SqlDbType.Int).Value = idHorario;
            comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha;

        }

        public int insertarDiasXHorariosXFechas(int idDia, int idHorario, DateTime fecha)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDiasXHorariosXFechas(ref comando, idDia, idHorario, fecha);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spInsertarDiasXHorariosXFechas");
        }



        private void ArmarParametrosDiasXHorariosXFechasXMedico(ref SqlCommand comando, int idDia, int idHorario, DateTime fecha, string legajoMedico)
        {
            comando.Parameters.Add("@Id_Dia", SqlDbType.Int).Value = idDia;
            comando.Parameters.Add("@Id_Horario", SqlDbType.Int).Value = idHorario;
            comando.Parameters.Add("@Fecha", SqlDbType.Date).Value = fecha;
            comando.Parameters.Add("@Legajo_Medico", SqlDbType.Char).Value = legajoMedico;
        }

        public int insertarDiasXHorariosXFechasXMedico(int idDia, int idHorario, DateTime fecha, string legajoMedico)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosDiasXHorariosXFechasXMedico(ref comando, idDia, idHorario, fecha, legajoMedico);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spInsertarDiasXHorariosXFechasXMedico");
        }

        public DataTable ObtenerTodasLasFechas()
        {
            string consulta = "SELECT Fecha FROM Fechas";
            return accesoDatos.ObtenerTabla("Fechas", consulta);
        }

        //-------------------------------------------------------------------------------------------------






        /*ver luego*/

        private void ArmarParametrosActualizarPaciente(ref SqlCommand Comando, Pacientes pacientes)
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
            SqlParametros = Comando.Parameters.Add("@Estado", SqlDbType.Bit);
            SqlParametros.Value = pacientes.getEstado();


        }

        public int actualizarPaciente(Pacientes pacientes)
        {

            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarPaciente(ref comando, pacientes);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spActualizarPaciente");
        }



        public DataTable BuscarMedicos(string criterio)
        {
            SqlCommand comando = new SqlCommand(@"
            SELECT 
                m.Legajo,
                m.DNI AS Documento,
                m.Nombre,
                m.Apellido,
                s.Descripcion_Sexo AS Sexo,
                m.Nacionalidad,
                m.FechaNacimiento,
                m.Direccion,
                l.DescripcionLocalidad AS Localidad,
                e.DescripcionEspecialidad AS Especialidad,
                m.Email AS [Correo electrónico],
                m.Telefono,
                m.Estado
            FROM Medicos m
            JOIN Sexo s ON m.Id_Sexo = s.Id_Sexo
            JOIN Localidades l ON m.Id_Localidad = l.Id_Localidad
            JOIN Especialidades e ON m.Id_Especialidad = e.Id_Especialidad
            WHERE 
                m.Nombre LIKE '%' + @Criterio + '%' OR
                m.Apellido LIKE '%' + @Criterio + '%' OR
                m.DNI LIKE '%' + @Criterio + '%';");

            comando.Parameters.AddWithValue("@Criterio", criterio);

            return accesoDatos.ObtenerTablaConParametros("Medicos", comando);
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