using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        string cadenaConexion = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog = ClinicaMedicaPruebaFinal1; Integrated Security = True";

        public SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection(cadenaConexion);
            try
            {
                conexion.Open();

                return conexion;
            }
            catch
            {
                return null;
            }
        }

        public SqlDataAdapter ObtenerAdaptador(string consultaSql, SqlConnection cn)
        {
            SqlDataAdapter sqlDataAdapter;
            try
            {
                sqlDataAdapter = new SqlDataAdapter(consultaSql, ObtenerConexion());
                return sqlDataAdapter;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable ObtenerTabla(String NombreTabla, String Sql)
        {
            DataSet dataSet = new DataSet();
            SqlConnection Conexion = ObtenerConexion();
            SqlDataAdapter sqlDataAdapter = ObtenerAdaptador(Sql, Conexion);
            sqlDataAdapter.Fill(dataSet, NombreTabla);
            Conexion.Close();
            return dataSet.Tables[NombreTabla];
        }


        public int EjecutarProcedimientoAlmacenado(SqlCommand Comando, String NombreSP)
        {
            int FilasCambiadas;
            SqlConnection Conexion = ObtenerConexion();
            SqlCommand cmd = new SqlCommand();
            cmd = Comando;
            cmd.Connection = Conexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = NombreSP;
            FilasCambiadas = cmd.ExecuteNonQuery();
            Conexion.Close();
            return FilasCambiadas;
        }


        public DataTable ObtenerTablaConParametros(string nombreTabla, SqlCommand comando)
        {
            DataSet ds = new DataSet();
            SqlConnection conexion = ObtenerConexion();
            comando.Connection = conexion;

            SqlDataAdapter adaptador = new SqlDataAdapter(comando);
            adaptador.Fill(ds, nombreTabla);
            conexion.Close();

            return ds.Tables[nombreTabla];
        }



    }
}
