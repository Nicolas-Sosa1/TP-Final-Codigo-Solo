﻿using System;
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


        //Cargar tablas-----------------------------------------------------------------------
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
                P.Id_Sexo AS Id_Sexo,
                p.Nacionalidad AS 'Nacionalidad',
                p.FechaNacimiento AS 'FechaNacimiento',
                p.Direccion AS 'Direccion',
                l.DescripcionLocalidad AS 'Localidad',
                pr.DescripcionProvincia AS 'Provincia',
                l.Id_Provincia AS Id_Provincia,          
                l.Id_Localidad AS Id_Localidad,              
                p.Email AS 'CorreoElectronico',
                p.Telefono AS 'Telefono',
                p.Estado AS 'Estado'
            FROM Pacientes p
            JOIN Sexo s ON p.Id_Sexo = s.Id_Sexo
            JOIN Localidades l ON p.Id_Localidad = l.Id_Localidad
            JOIN Provincias pr ON l.Id_Provincia = pr.Id_Provincia
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
                m.Id_Sexo AS Id_Sexo,
                m.Nacionalidad AS 'Nacionalidad',
                m.FechaNacimiento AS 'FechaNacimiento',
                m.Direccion AS 'Direccion',
                l.DescripcionLocalidad AS 'Localidad',
                pr.DescripcionProvincia AS 'Provincia',
                l.Id_Provincia AS Id_Provincia,
                l.Id_Localidad AS Id_Localidad,
                e.Id_Especialidad AS Id_Especialidad,
                e.DescripcionEspecialidad AS 'Especialidad',
                m.Email AS 'CorreoElectronico',
                m.Telefono AS 'Telefono',
                m.Estado AS 'Estado',
                u.Id_Usuario,
                u.NombreUsuario,
                u.Contrasena
            FROM Medicos m
            JOIN Sexo s ON m.Id_Sexo = s.Id_Sexo
            JOIN Localidades l ON m.Id_Localidad = l.Id_Localidad
            JOIN Provincias pr ON l.Id_Provincia = pr.Id_Provincia
            JOIN Especialidades e ON m.Id_Especialidad = e.Id_Especialidad
            JOIN Usuarios u ON m.Legajo = u.Legajo_Medico
            WHERE m.Estado = 1;
            ";

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


        //-----------------------------------------------------------------------------------------


        //login-----------------------------------------------------------------------------------------

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

        //-----------------------------------------------------------------------------------------



        //Mostrar Localidades dependiendo la provincia----------------------------------------------------

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

        //-----------------------------------------------------------------------------------






        //Agregar nuevo paciente mediante interfaz----------------------------------------------------

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


        //------------------------------------------------------------------------------------------


        //Dar de baja paciente mediante interfaz----------------------------------------------------

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


        public bool ExistePacienteYActivo(string dni, out bool yaBaja)
        {
            yaBaja = false;
            string consulta = "SELECT Estado FROM Pacientes WHERE DNI = @DNI";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@DNI", dni);

            DataTable tabla = accesoDatos.ObtenerTablaConParametros("Pacientes", cmd);

            if (tabla.Rows.Count == 0)
                return false;

            bool estado = Convert.ToBoolean(tabla.Rows[0]["Estado"]);
            yaBaja = !estado;

            return true;
        }

        //--------------------------------------------------------------------------------------



        //Dar de baja medico mediante interfaz----------------------------------------------------
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

        public bool ExisteMedicoYActivo(string legajo, out bool yaBaja)
        {
            yaBaja = false;
            string consulta = "SELECT Estado FROM Medicos WHERE Legajo = @Legajo";
            SqlCommand cmd = new SqlCommand(consulta);
            cmd.Parameters.AddWithValue("@Legajo", legajo);

            DataTable tabla = accesoDatos.ObtenerTablaConParametros("Medicos", cmd);

            if (tabla.Rows.Count == 0)
            {
                return false; // no existe
            }

            bool estado = Convert.ToBoolean(tabla.Rows[0]["Estado"]);
            yaBaja = !estado; // si estado == false → ya estaba de baja

            return true;
        }


        //--------------------------------------------------------------------------------------




        //Agregar medico mediante interfaz---------------------------------------------------------------


        //agregar solo la parte de la tabla Medico-----------------------------------------------------
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

        //--------------------------------------------------------------------------------------


        //agregar solo la parte de la tabla Usuarios-----------------------------------------------------
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

        //--------------------------------------------------------------------------------------



        //agregar solo la parte de la tabla DiasXHorarios
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
        //------------------------------------------------------------------------------------------------


        //agregar solo la parte de la tabla DiasXHorariosXFechas
        //------------------------------------------------------------------------------------------------
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

        //------------------------------------------------------------------------------------------------


        //agregar solo la parte de la tabla DiasXHorariosXFechasXMedico
        //------------------------------------------------------------------------------------------------
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

        //------------------------------------------------------------------------------------------------


        public DataTable ObtenerTodasLasFechas()
        {
            string consulta = "SELECT Fecha FROM Fechas";
            return accesoDatos.ObtenerTabla("Fechas", consulta);
        }



        //-------------------------------------------------------------------------------------------------

        

        //Actualizar Paciente
        //--------------------------------------------------------------------------------------------
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
            


        }

        public int actualizarPaciente(Pacientes pacientes)
        {

            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarPaciente(ref comando, pacientes);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spActualizarPaciente");
        }


        public DataTable ObtenerLocalidadesPorProvincia(int idProvincia)
        {
            string consulta = "SELECT * FROM Localidades WHERE Id_Provincia = @Id_Provincia";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@Id_Provincia", idProvincia);

            return accesoDatos.ObtenerTablaConParametros("Localidades", comando);
        }

        //--------------------------------------------------------------------------------------------


        //Actualizar Medico
        //--------------------------------------------------------------------------------------------
        private void ArmarParametrosActualizarMedico(ref SqlCommand Comando, Medicos medicos)
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


        public int actualizarMedico(Medicos medicos)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarMedico(ref comando, medicos);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spActualizarMedico");
        }

        //--------------------------------------------------------------------------------------------


        //Actualizar Usuario
        //--------------------------------------------------------------------------------------------
        private void ArmarParametrosActualizarUsuario(ref SqlCommand Comando, Usuarios usuarios)
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


        public int actualizarUsuario(Usuarios usuarios)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarUsuario(ref comando, usuarios);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spActualizarUsuario");
        }
        //--------------------------------------------------------------------------------------------










        //Seccion Asignar Turno
        //------------------------------------------------------------------------------------------------

        private void ArmarParametrosTurno(ref SqlCommand comando, Turnos turno)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = comando.Parameters.Add("@Id_Dia", SqlDbType.Int);
            SqlParametros.Value = turno.getId_Dia();
            SqlParametros = comando.Parameters.Add("@Id_Horario", SqlDbType.Int);
            SqlParametros.Value = turno.getId_Horario();
            SqlParametros = comando.Parameters.Add("@Fecha", SqlDbType.Date);
            SqlParametros.Value = turno.getFecha();
            SqlParametros = comando.Parameters.Add("@Legajo_Medico", SqlDbType.Char);
            SqlParametros.Value = turno.getLegajo_Medico();
            SqlParametros = comando.Parameters.Add("@DNI_Paciente", SqlDbType.Char);
            SqlParametros.Value = turno.getDNI_Paciente();
            SqlParametros = comando.Parameters.Add("@Hora", SqlDbType.Time);
            SqlParametros.Value = turno.getHora();
            SqlParametros = comando.Parameters.Add("@EstadoTurno", SqlDbType.VarChar);
            SqlParametros.Value = turno.getEstadoTurno();
            SqlParametros = comando.Parameters.Add("@Observacion", SqlDbType.VarChar);
            SqlParametros.Value = turno.getObservacion();
        }

        public int InsertarTurno(Turnos turno)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosTurno(ref comando, turno);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spInsertarTurno");
        }


        public DataTable GetMedicosPorEspecialidad(int idEspecialidad)
        {
            string consulta = $@"
        SELECT Legajo, (Nombre + ' ' + Apellido) AS NombreCompleto
        FROM Medicos
        WHERE Id_Especialidad = {idEspecialidad} AND Estado = 1";

            return accesoDatos.ObtenerTabla("Medicos", consulta);
        }


        public DataTable ObtenerDiasDisponibles(int legajo, DateTime fecha)
        {
            string consulta = $@"
        SELECT DISTINCT d.Id_Dia, di.DescripcionDia
        FROM DiasXHorariosXFechasXMedico d
        JOIN Dias di ON d.Id_Dia = di.Id_Dia
        WHERE d.Legajo_Medico = '{legajo}'
          AND d.Fecha = '{fecha:yyyy-MM-dd}'";

            return accesoDatos.ObtenerTabla("DiasDisponibles", consulta);
        }

        public DataTable ObtenerHorariosDisponibles(int idDia, int legajo, DateTime fecha)
        {
            string consulta = $@"
        SELECT h.Id_Horario, h.HoraDesde, h.HoraHasta
        FROM DiasXHorariosXFechasXMedico d
        JOIN Horarios h ON d.Id_Horario = h.Id_Horario
        WHERE d.Id_Dia = {idDia}
          AND d.Legajo_Medico = '{legajo}'
          AND d.Fecha = '{fecha:yyyy-MM-dd}'";

            return accesoDatos.ObtenerTabla("HorariosDisponibles", consulta);
        }


        public DataTable ObtenerHorasDisponibles(int idDia, int idHorario, DateTime fecha, string legajo)
        {
            // Paso 1: Obtener rango horario
            string queryRango = $@"
        SELECT HoraDesde, HoraHasta
        FROM Horarios
        WHERE Id_Horario = {idHorario}";
            DataTable tablaRango = accesoDatos.ObtenerTabla("Rango", queryRango);

            if (tablaRango.Rows.Count == 0) return new DataTable();

            TimeSpan desde = (TimeSpan)tablaRango.Rows[0]["HoraDesde"];
            TimeSpan hasta = (TimeSpan)tablaRango.Rows[0]["HoraHasta"];

            // Paso 2: Traer las horas ya asignadas como turnos
            string queryOcupadas = $@"
        SELECT Hora
        FROM Turnos
        WHERE Fecha = '{fecha:yyyy-MM-dd}'
          AND Legajo_Medico = '{legajo}'";
            DataTable ocupadas = accesoDatos.ObtenerTabla("Ocupadas", queryOcupadas);

            HashSet<TimeSpan> horasOcupadas = new HashSet<TimeSpan>(
                ocupadas.Rows.Cast<DataRow>().Select(r => (TimeSpan)r["Hora"])
            );

            // Paso 3: Generar horas posibles por bloques de 1 hora
            DataTable disponibles = new DataTable();
            disponibles.Columns.Add("Hora", typeof(string));

            for (TimeSpan h = desde; h.Add(TimeSpan.FromHours(1)) <= hasta; h = h.Add(TimeSpan.FromHours(1)))
            {
                if (!horasOcupadas.Contains(h))
                {
                    disponibles.Rows.Add(h.ToString(@"hh\:mm"));
                }
            }

            return disponibles;
        }

        public bool ExisteTurno(string legajo, DateTime fecha, TimeSpan hora)
        {
            string consulta = $@"
        SELECT COUNT(*) FROM Turnos
        WHERE Legajo_Medico = '{legajo}'
          AND Fecha = '{fecha:yyyy-MM-dd}'
          AND Hora = '{hora}'";

            DataTable tabla = accesoDatos.ObtenerTabla("Turnos", consulta);
            return Convert.ToInt32(tabla.Rows[0][0]) > 0;
        }

        //-------------------------------------------------------------------------------------------------


        //Busquedas/filtrar
        //-------------------------------------------------------------------------------------------------
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
                pr.DescripcionProvincia AS 'Provincia',
                e.DescripcionEspecialidad AS Especialidad,
                m.Email AS [CorreoElectronico],
                m.Telefono,
                m.Estado,
                u.NombreUsuario,
                u.Contrasena
            FROM Medicos m
            JOIN Sexo s ON m.Id_Sexo = s.Id_Sexo
            JOIN Localidades l ON m.Id_Localidad = l.Id_Localidad
            JOIN Provincias pr ON l.Id_Provincia = pr.Id_Provincia
            JOIN Especialidades e ON m.Id_Especialidad = e.Id_Especialidad
            JOIN Usuarios u ON m.Legajo = u.Legajo_Medico
            WHERE 
                m.Nombre LIKE '%' + @Criterio + '%' OR
                m.Apellido LIKE '%' + @Criterio + '%' OR
                m.DNI LIKE '%' + @Criterio + '%' OR
                m.Legajo LIKE '%' + @Criterio + '%';");

            comando.Parameters.AddWithValue("@Criterio", criterio);

            return accesoDatos.ObtenerTablaConParametros("Medicos", comando);
        }

        public DataTable BuscarPacientes(string criterio)
        {
            SqlCommand comando = new SqlCommand(@"
            SELECT 
                p.DNI AS 'Documento',
                p.Nombre,
                p.Apellido,
                s.Descripcion_Sexo AS 'Sexo',
                p.Nacionalidad,
                p.FechaNacimiento,
                p.Direccion,
                l.DescripcionLocalidad AS 'Localidad',
                pr.DescripcionProvincia AS 'Provincia',
                p.Email AS 'CorreoElectronico',
                p.Telefono,
                p.Estado
            FROM Pacientes p
            JOIN Sexo s ON p.Id_Sexo = s.Id_Sexo
            JOIN Localidades l ON p.Id_Localidad = l.Id_Localidad
            JOIN Provincias pr ON l.Id_Provincia = pr.Id_Provincia
            WHERE 
                p.Nombre LIKE '%' + @Criterio + '%' OR
                p.Apellido LIKE '%' + @Criterio + '%' OR
                p.DNI LIKE '%' + @Criterio + '%';");

            comando.Parameters.AddWithValue("@Criterio", criterio);

            return accesoDatos.ObtenerTablaConParametros("Medicos", comando);
        }

    }//-------------------------------------------------------------------------------------------------
}


