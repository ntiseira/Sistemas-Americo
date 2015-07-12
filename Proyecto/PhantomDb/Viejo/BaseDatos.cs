using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;

namespace PhantomDb.Viejo
{
    public enum BasesDeDatos
    {
        Access,
        MySQL
    }

    /// <summary>
    /// Métodos estáticos para manejo de bases de datos.
    /// CLASE VIEJA, NO USAR A MENOS QUE SE TRABAJE CON ACCESS.
    /// </summary>
    public class BaseDatos
    {
        private static OleDbConnection conexion;
        protected static OleDbConnection Conexion
        {
            get { return BaseDatos.conexion; }
            set { BaseDatos.conexion = value; }
        }

        public static DataSet Consultar(string consulta)
        {
            try
            {
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(consulta, Conexion);
                da.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public static DataSet ConsultarEx(string consulta)
        {
            DataSet ds = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(consulta, Conexion);
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// Transforma un objeto a un string guardable en la base de datos, segun su tipo.
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static String ObtenerStringBD(object o)
        {
            StringBuilder retorno = new StringBuilder();

            if (o.GetType().Name.ToLower().Equals("string"))
            {
                retorno.Append("'");
                retorno.Append(o.ToString());
                retorno.Append("'");
            }
            else if (o.GetType().Name.ToLower().Equals("boolean") || o.GetType().Name.ToLower().Equals("bool"))
            {
                retorno.Append(((bool)o) ? "true" : "false");
            }
            else
            {
                retorno.Append(o.ToString());
            }

            return retorno.ToString();
        }

        public static string GetStringConexion(BasesDeDatos bd, String baseDeDatos)
        {
            return GetStringConexion(bd, baseDeDatos, "");
        }

        public static string GetStringConexion(BasesDeDatos bd, String baseDeDatos, String clave)
        {
            switch (bd)
            {
                case BasesDeDatos.Access:
                    if(clave.Equals(""))
                    {
                        return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + baseDeDatos;
                    }
                    else
                    {
                        return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + baseDeDatos + "; Jet OLEDB:Database Password=" + clave + ";";
                    }

                case BasesDeDatos.MySQL:
                    return String.Format("Server=localhost;Database=basedatos;Uid=root;Pwd={0};", clave);

                default:
                    break;
            }

            return "";
        }

        /// <summary>
        /// Se conecta con la base de datos.
        /// </summary>
        /// <param name="conexion">String de conexión.</param>
        public static void Conectar(String conexion)
        {
            Desconectar();

            Conexion = new OleDbConnection(conexion);
            Conexion.Open();
        }        

        /// <summary>
        /// Se desconecta de la base de datos.
        /// </summary>
        public static void Desconectar()
        {
            try
            {
                if (Conexion != null)
                {
                    Conexion.Close();
                    Conexion.Dispose();
                    Conexion = null;
                }
            }
            catch (Exception)
            {
                Conexion = null;
            }
        }
    }
}
