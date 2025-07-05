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

        public DataTable ObtenerTodosLosTurnos(string nombreUsuario)
        {
            string consulta = @"
            SELECT 
                t.Id_Turno,
                t.Fecha,
                t.Hora,
                d.DescripcionDia,
                h.HoraDesde,
                h.HoraHasta,
                t.EstadoTurno,
                t.Observacion,
                p.DNI AS DNI_Paciente,
                p.Nombre + ' ' + p.Apellido AS NombrePaciente
            FROM Turnos t
            INNER JOIN Usuarios u ON u.Legajo_Medico = t.Legajo_Medico
            INNER JOIN Dias d ON d.Id_Dia = t.Id_Dia
            INNER JOIN Horarios h ON h.Id_Horario = t.Id_Horario
            INNER JOIN Pacientes p ON p.DNI = t.DNI_Paciente
            WHERE u.NombreUsuario = @nombreUsuario
            ORDER BY t.Id_Turno";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

            return accesoDatos.ObtenerTablaConParametros("Turnos", comando);

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

        public DataTable ObtenerTodasLasFechas()
        {
            string consulta = "SELECT Fecha FROM Fechas";
            return accesoDatos.ObtenerTabla("Fechas", consulta);
        }


        //-----------------------------------------------------------------------------------------


        //login-----------------------------------------------------------------------------------------

        public DataTable validarLogin(string usuario, string contraseña)
        {
            string consulta = "SELECT * FROM Usuarios WHERE NombreUsuario = @NombreUsuario AND Contrasena = @Contrasena";

            SqlCommand comando = new SqlCommand(consulta);

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
            SqlCommand comando = new SqlCommand(consulta);
            ArmarParametrosLocalidadesPorProvincia(ref comando, provincia);

            return accesoDatos.ObtenerTablaConParametros("Localidades", comando);
        }



        private void ArmarParametrosLocalidadesPorProvincia(ref SqlCommand sqlCommand, Provincias provincias)
        {
           
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = sqlCommand.Parameters.Add("@idProvincia", SqlDbType.Int);
            SqlParametros.Value = provincias.getId_Provincia();
        }

        //-----------------------------------------------------------------------------------


        // Verificar si existe DNI del paciente

        public bool ExistePacienteRegistrado(string dni)
        {
            string consulta = "SELECT * FROM Pacientes WHERE DNI = @DNI";
            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@DNI", dni);


            DataTable tabla = accesoDatos.ObtenerTablaConParametros("Pacientes", comando);

            // Si en el DataTable hay al menos 1 fila, el DNI ya existe
            return tabla.Rows.Count > 0;
        }



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
            // Verificar si existe DNI con metodo creado (si existe sale con return)
            if (ExistePacienteRegistrado(pacientes.getDni()))
            {
                return 0;
            }

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
            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@DNI", dni);

            DataTable tabla = accesoDatos.ObtenerTablaConParametros("Pacientes", comando);

            if (tabla.Rows.Count == 0)
            {
                return false;
            }

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

        public bool ExisteLegajoMedico(string legajo)
        {
            string consulta = "SELECT * FROM Medicos WHERE Legajo = @Legajo";
            
            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@Legajo", legajo);

            
            DataTable tabla = accesoDatos.ObtenerTablaConParametros("Medicos",comando);

            // Si en el DataTable hay al menos 1 fila, el legajo del medico ya existe
            return tabla.Rows.Count > 0;
        }

        public bool ExisteDNIMedico(string dni)
        {
            string consulta = "SELECT * FROM Medicos WHERE DNI = @DNI";
            
            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@DNI", dni);

            
            DataTable tabla = accesoDatos.ObtenerTablaConParametros("Medicos", comando);

           
            // Si en el DataTable hay al menos 1 fila, el DNI del medico ya existe
            return tabla.Rows.Count > 0;
        }


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
            if (ExisteDNIMedico(medicos.GetDNI()))
            {
                 return -1; // Código para "DNI ya existe"
            }

            if (ExisteLegajoMedico(medicos.GetLegajo()))
            {
                return -2; // Código para "Legajo ya existe"
            }
                
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

        //Actualizar FechasxDiasxHorarios
        //--------------------------------------------------------------------------------------------

        public DataTable ObtenerDiasHorariosDeMedico(string legajo)
        {
            string consulta = @"
        SELECT Id_Dia, DescripcionDia, Id_Horario, HoraDesde, HoraHasta
        FROM vw_DiasHorariosPorMedico
        WHERE Legajo_Medico = @Legajo";

            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@Legajo", legajo);

            return accesoDatos.ObtenerTablaConParametros("DiasHorariosMedico", comando);
        }

        public void EliminarDiasXHorariosXFechasXMedicoSiNoHayTurno(int idDia, int idHorario, DateTime fecha, string legajo)
        {
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@Id_Dia", idDia);
            comando.Parameters.AddWithValue("@Id_Horario", idHorario);
            comando.Parameters.AddWithValue("@Fecha", fecha);
            comando.Parameters.AddWithValue("@Legajo_Medico", legajo);

            accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spEliminarDiasXHorariosXFechasXMedicoSiNoTurno");
        }

        public List<int> getTodosLosIdHorarios()
        {
            // Creamos una lista vacía para guardar los Id_Horario que obtenemos de la base de datos
            List<int> lista = new List<int>();

            // Obtenemos una conexión a la base de datos (usando un método propio llamado ObtenerConexion)
            SqlConnection conexion = accesoDatos.ObtenerConexion();

            // Creamos un comando SQL con la consulta que selecciona todos los Id_Horario
            SqlCommand comando = new SqlCommand("SELECT Id_Horario FROM Horarios", conexion);

            // Ejecutamos la consulta y obtenemos un lector de datos que lee cada fila
            SqlDataReader reader = comando.ExecuteReader();

            // Mientras haya filas por leer, seguimos leyendo
            while (reader.Read())
            {
                // Leemos el valor de la columna "Id_Horario" de la fila actual
                // Convertimos ese valor a int y lo agregamos a la lista
                lista.Add(Convert.ToInt32(reader["Id_Horario"]));
            }

            
            reader.Close();

            conexion.Close();

          
            return lista;
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
            string consulta = @"
            SELECT DISTINCT d.Id_Dia, di.DescripcionDia
            FROM DiasXHorariosXFechasXMedico d
            JOIN Dias di ON d.Id_Dia = di.Id_Dia
            WHERE d.Legajo_Medico = @legajo
              AND d.Fecha = @fecha";

            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@legajo", legajo);
            comando.Parameters.AddWithValue("@fecha", fecha.Date);

            return accesoDatos.ObtenerTablaConParametros("DiasDisponibles", comando);
        }

        public DataTable ObtenerHorariosDisponibles(int idDia, int legajo, DateTime fecha)
        {
            string consulta = @"
            SELECT h.Id_Horario, h.HoraDesde, h.HoraHasta
            FROM DiasXHorariosXFechasXMedico d
            JOIN Horarios h ON d.Id_Horario = h.Id_Horario
            WHERE d.Id_Dia = @IdDia
              AND d.Legajo_Medico = @legajo
              AND d.Fecha = @fecha";

            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@idDia", idDia);
            comando.Parameters.AddWithValue("@legajo", legajo);
            comando.Parameters.AddWithValue("@fecha", fecha.Date);

            return accesoDatos.ObtenerTablaConParametros("HorariosDisponibles", comando);
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


        //-------------------------------------------------------------------------------------------------
        //Actualizar Turno
        private void ArmarParametrosActualizarTurno(ref SqlCommand Comando, Turnos turnos)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@Id_Turno", SqlDbType.Int);
            SqlParametros.Value = turnos.getId_Turno();
            SqlParametros = Comando.Parameters.Add("@EstadoTurno", SqlDbType.VarChar);
            SqlParametros.Value = turnos.getEstadoTurno();
            SqlParametros = Comando.Parameters.Add("@Observacion", SqlDbType.VarChar);
            SqlParametros.Value = turnos.getObservacion();
                
        }

        public int actualizarTurno(Turnos turnos)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosActualizarTurno(ref comando, turnos);
            return accesoDatos.EjecutarProcedimientoAlmacenado(comando, "spActaulizarTurno");
        }

       
        //-------------------------------------------------------------------------------------------------


        //Busquedas/filtrar
        //-------------------------------------------------------------------------------------------------
        public DataTable BuscarMedicos(string criterio)
        {
            string consulta = @"
            SELECT 
                m.Legajo,
                m.DNI AS 'Documento',
                m.Nombre,
                m.Apellido,
                s.Descripcion_Sexo AS Sexo,
                m.Nacionalidad,
                m.FechaNacimiento,
                m.Direccion,
                l.DescripcionLocalidad AS 'Localidad',
                pr.DescripcionProvincia AS 'Provincia',
                e.DescripcionEspecialidad AS Especialidad,
                m.Email AS 'CorreoElectronico',
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
                m.Legajo LIKE '%' + @Criterio + '%';";

            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@Criterio", criterio);

            return accesoDatos.ObtenerTablaConParametros("Medicos", comando);
        }

        public DataTable BuscarPacientes(string criterio)
        {

            string consulta =@"
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
                p.DNI LIKE '%' + @Criterio + '%';";

            SqlCommand comando = new SqlCommand(consulta);

            comando.Parameters.AddWithValue("@Criterio", criterio);

            return accesoDatos.ObtenerTablaConParametros("Pacientes", comando);
        }

        public DataTable BuscarTurno(string nombreUsuario, string nombrePaciente, int? nroTurno, string estado)
        {
            string consulta = @"
            SELECT 
                t.Id_Turno,
                t.Fecha,
                t.Hora,
                d.DescripcionDia,
                h.HoraDesde,
                h.HoraHasta,
                t.EstadoTurno,
                t.Observacion,
                p.DNI AS DNI_Paciente,
                p.Nombre + ' ' + p.Apellido AS NombrePaciente
            FROM Turnos t
            INNER JOIN Usuarios u ON u.Legajo_Medico = t.Legajo_Medico
            INNER JOIN Dias d ON d.Id_Dia = t.Id_Dia
            INNER JOIN Horarios h ON h.Id_Horario = t.Id_Horario
            INNER JOIN Pacientes p ON p.DNI = t.DNI_Paciente
            WHERE u.NombreUsuario = @nombreUsuario
                AND (@nombrePaciente IS NULL OR p.Nombre LIKE '%' + @nombrePaciente + '%' OR p.Apellido LIKE '%' + @nombrePaciente + '%')
                AND (@nroTurno IS NULL OR t.Id_Turno = @nroTurno)
                AND (@estado IS NULL OR t.EstadoTurno LIKE '%' + @estado + '%')
            ORDER BY t.Id_Turno";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
            // Si el string está vacío, pasamos DBNull.Value
            comando.Parameters.AddWithValue("@nombrePaciente", string.IsNullOrEmpty(nombrePaciente) ? (object)DBNull.Value : nombrePaciente);
            comando.Parameters.AddWithValue("@estado", string.IsNullOrEmpty(estado) ? (object)DBNull.Value : estado);

            // Si nroTurno es null, pasamos DBNull, sino el valor
            comando.Parameters.AddWithValue("@nroTurno", nroTurno.HasValue ? (object)nroTurno.Value : DBNull.Value);

            return accesoDatos.ObtenerTablaConParametros("Turnos", comando);
        }

        //-------------------------------------------------------------------------------------------------
        //Seccion Informes
        // === DAO (Acceso a Datos) ===
        public DataTable ObtenerResumenAsistenciaTurnos(DateTime fechaDesde, DateTime fechaHasta)
        {
            string consulta = @"
        SELECT 
            EstadoTurno,
            COUNT(*) AS Cantidad,
            ROUND(CAST(COUNT(*) * 100.0 / 
                (SELECT COUNT(*) FROM Turnos 
                 WHERE Fecha BETWEEN @Desde AND @Hasta) AS FLOAT), 2) AS Porcentaje
        FROM Turnos
        WHERE Fecha BETWEEN @Desde AND @Hasta
        GROUP BY EstadoTurno";

            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@Desde", fechaDesde);
            comando.Parameters.AddWithValue("@Hasta", fechaHasta);

            return accesoDatos.ObtenerTablaConParametros("Turnos", comando);
        }


        public DataTable ObtenerEspecialidadMasFrecuente(int IdEspecialidad)
        {
            string consulta = @"
        SELECT 
            e.DescripcionEspecialidad,
            COUNT(*) AS CantidadMedicos,
            ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Medicos), 2) AS Porcentaje
        FROM Medicos m
        INNER JOIN Especialidades e ON m.Id_Especialidad = e.Id_Especialidad
        WHERE e.Id_Especialidad = @IdEspecialidad
        GROUP BY e.DescripcionEspecialidad
        ORDER BY CantidadMedicos DESC;";


            SqlCommand comando = new SqlCommand(consulta);
            comando.Parameters.AddWithValue("@IdEspecialidad", IdEspecialidad);

            return accesoDatos.ObtenerTablaConParametros("InformeEspecialidad", comando);
        }


        //-------------------------------------------------------------------------------------------------

    }



}


