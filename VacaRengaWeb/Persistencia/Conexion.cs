using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;


namespace VacaRengaWeb.Persistencia
{
    public class Conexion
    {
        private string _cadenaConexion = @"Data Source=ETERNAL_MONARCH\SQLEXPRESS;Integrated Security=True;Database=VacaRenga; Connect Timeout=0";

        public bool Consulta(string sql)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(this._cadenaConexion);
                SqlCommand comando = new SqlCommand(sql, conexion);
                conexion.Open();
                comando.ExecuteNonQuery();
                comando.Dispose();
                conexion.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
                //throw new Exception("Error en conexión sql = " + sql, e);
            }
        }

        public DataSet Seleccion(string sql)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(this._cadenaConexion);
                SqlDataAdapter adaptador = new SqlDataAdapter(sql, conexion);
                DataSet resultado = new DataSet();
                conexion.Open();
                adaptador.Fill(resultado);
                adaptador.Dispose();
                conexion.Close();
                return resultado;
            }
            catch (Exception e)
            {
                throw new Exception("Error en conexión sql = " + sql, e);
            }
        }
    }
}