using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;   

namespace CapaDatos
{
    public static class Datos
    {
        //CONEXION CON MYSQL
#if DEBUG
        private static string connectionString = 

        "Server=localhost;Database=siscont;Uid=root;Pwd=12361236;Allow Zero Datetime=True;";
     

        //"Server=localhost;Database=wi331278_siscont;Uid=wi331278;Pwd=VIgawo66ka;";
    //    "Server=localhost;Database=siscont;Uid=root;Pwd=;";

#else
        private static string connectionString =
            "Server=localhost;Database=siscont;Uid=root;Pwd=12361236;Allow Zero Datetime=True;";
#endif

        public static PhantomDb.PDBHelperAbstract Phantom
        {
            get
            {
                if(PhantomDb.PDBHelper.Factory.Consultar == null)
                {
                    PhantomDb.PDBHelper.Factory.Consultar = new PhantomDb.DataSet_String(Datos.ConsultarEx);
                }
                return PhantomDb.PDBHelper.Instance;
            }
        }

        public static string ConnectionString
        {
            get { return Datos.connectionString; }
            set { Datos.connectionString = value; }
        }

        private static void MejorarConsulta(ref string consulta)
        {
            if (!consulta.EndsWith(";"))
                consulta = consulta + ";";
        }


        /// <summary>
        /// Realiza una consulta "sin tener en cuenta" las excepciones.
        /// </summary>
        /// <param name="consulta"></param>
        /// <returns></returns>
        public static DataSet ConsultarEx(string consulta)
        {
            MejorarConsulta(ref consulta);
            MySqlConnection cn = null;
            try
            {
                cn = new MySqlConnection(connectionString);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                cn.Close();

                return ds;
            }
            catch (Exception ex)
            {
                if (cn != null)
                    cn.Close();

                throw ex;
            }
        }

        public static int Consultar(string consulta, byte mentira)
        {
            MejorarConsulta(ref consulta);
            MySqlConnection cn = null;
            DataSet ds = new DataSet();
            try
            {
                cn = new MySqlConnection(connectionString);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

            if (cn != null)
                cn.Close();

            return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
        }

        public static DataSet Consultar(string consulta)
        {
            MejorarConsulta(ref consulta);
            MySqlConnection cn = null;
            DataSet ds = new DataSet();
            try
            {
                cn = new MySqlConnection(connectionString);
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
            }

            if (cn != null)
                cn.Close();

            return ds;
        }

       /// <summary>
       /// Chequea si el dataset esta vacía o no.
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static bool EstaVacio(DataSet s)
       {
           if (s.Tables.Count == 0)
               return true;
           return s.Tables[0].Rows.Count == 0;
       }

       /// <summary>
       /// Obtiene el primer valor de la primera fila.
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static object GetValor(DataSet s)
       {
           return s.Tables[0].Rows[0].ItemArray[0];
       }

       /// <summary>
       /// Obtiene los primeros valores de la primera fila.
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static object[] GetValores(DataSet s)
       {
           return s.Tables[0].Rows[0].ItemArray;
       }

       /// <summary>
       /// Obtiene una lista con todos los valores de cada fila.
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static List<object[]> GetTotalValores(DataSet s)
       {
           List<object[]> objetos = new List<object[]>();

           foreach (DataRow dr in s.Tables[0].Rows)
           {
               objetos.Add(dr.ItemArray);
           }

           return objetos;
       }

       /// <summary>
       /// Obtiene una lista con todos los valores de cada fila.
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static object[] GetTotalValores(DataSet s, int columna)
       {
           object[] objetos = new object[s.Tables[0].Rows.Count];

           for (int i = 0; i < s.Tables[0].Rows.Count; i++)
           {
               objetos[i] = s.Tables[0].Rows[i].ItemArray[columna];
           }

           return objetos;
       }

       public static IList<string> DataSetToString(DataSet ds)
       {
           return DataSetToString(ds, " - ");
       }

       /// <summary>
       /// Obtiene una lista de strings con todos los valores de cada fila.
       /// </summary>
       /// <param name="s"></param>
       /// <returns></returns>
       public static IList<string> DataSetToString(DataSet ds, string separator)
       {
           List<object[]> valores = Datos.GetTotalValores(ds);
           List<string> retorno = new List<string>();
           foreach (object[] obs in valores)
           {
               try
               {
                   string linea = obs[0].ToString();
                   for (int i = 1; i < obs.Length; i++)
                   {
                       linea += separator;
                       linea += obs[i].ToString();
                   }
                   retorno.Add(linea);
               }
               catch { }
           }

           return retorno;
       }













    }//clase
}//namespace
