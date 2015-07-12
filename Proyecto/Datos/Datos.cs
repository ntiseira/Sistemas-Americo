using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;
using System.Collections;   

namespace CapaDatos
{
    public static class Datos
    {
        //CONEXION CON MYSQL
#if DEBUG
        private static string connectionString = 
        //"Server=localhost;Database=wi331278_siscont;Uid=wi331278;Pwd=VIgawo66ka;Allow Zero Datetime=True;";
        "Server=localhost;Database=siscont;Uid=root;Pwd=12361236;Allow Zero Datetime=True;";
     

        //"Server=localhost;Database=wi331278_siscont;Uid=wi331278;Pwd=VIgawo66ka;";
    //    "Server=localhost;Database=siscont;Uid=root;Pwd=;";

#else
        private static string connectionString =
            "Server=localhost;Database=wi331278_siscont;Uid=wi331278;Pwd=VIgawo66ka;Allow Zero Datetime=True;";
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



        #region Consultas sin phantom


       public static string GuardarFechaHora(DateTime value)
       {
           // devuelve 2004-01-06T14:33:41.1234567
           return value.ToString("yyyy/MM/dd",
           CultureInfo.InvariantCulture);
       }


       public static bool AgregarComprobanteVenta(DateTime fecha,  int codCliente,  string letra,
                int numero,int tipoLista, long empresa,  DateTime fechaEntrega, DateTime fechaEmision, DateTime fechaContabilizacion,
                DateTime fechaDeclaracionJurada, bool bienUso ,int prov, double total,
            bool habilitado, int regimenEspecial, double totalNeto, double totalIva, double totalRecargo,
            double totalDescuento, double totalOtros, int nroTalonario, int talonario_sucursal_codigoSucursal,string talonario_tiposcomprobante_idtipocomprobante, int moneda)
       {
           bool respu = true;

           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "INSERT INTO comprobantesventa (fecha, cliente_codCliente,letra, numero, tipolista_idtipolista, empresa_idempresa, fechaentrega,fechaemision, fechacontabilizacion, fechadeclaracion, biendeuso, provincia_codProv, talonario_nroTalonario, talonario_sucursal_codigoSucursal, talonario_tiposcomprobante_idtipocomprobante, habilitado, totalNeto, totalIva, totalRecargo, totalDescuento, totalOtros, total, regimenesEspeciales_idregimen, moneda_idmoneda) values(" + GuardarFechaHora(fecha) + "," + codCliente + ",'" + letra + "'," + numero + ","
                   + tipoLista + "," + empresa + ",'" + GuardarFechaHora(fechaEntrega) + "','" +GuardarFechaHora(fechaEmision) + "','" + GuardarFechaHora(fechaContabilizacion) + "','" + GuardarFechaHora(fechaDeclaracionJurada) + "'," 
                   +bienUso + "," +prov+ ","+ nroTalonario+","+ talonario_sucursal_codigoSucursal + ","
                  + talonario_tiposcomprobante_idtipocomprobante + "," + habilitado + "," + totalNeto + "," + totalIva + ","
                  + totalRecargo + "," + totalDescuento + "," + totalOtros + "," + total + "," + regimenEspecial + "," + moneda + ")";
                  MySqlCommand cmd = new MySqlCommand(consulta, cn);
                  cmd.ExecuteNonQuery();       

               
           }
           catch (Exception ex)
           {

               Console.WriteLine("Error: {0}", ex.ToString());
               respu = false;
           }
           finally
           {

               if (cn != null)
                   cn.Close();
           }

           return respu;
       }



       public static bool AgregarLineaVenta(int comprobantesventa, int concepto, int moneda, int cantidad, double importe, int nrotalonario, int nroSucursal, string  talonariotipoComprobante, long empresa)
       {
           bool respu = true;

           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "INSERT INTO lineadeventa (comprobantesventa_numero,concepto_codConcepto, concepto_moneda_idmoneda, cantidad, importe, comprobantesventa_talonario_nroTalonario, comprobantesventa_talonario_sucursal_codigoSucursal, comprobantesventa_talonario_tiposcomprobante_idtipocomprobante, comprobantesventa_moneda_idmoneda, comprobantesventa_empresa_idempresa ) values(" + comprobantesventa + "," + concepto + "," + moneda + "," + cantidad + ",'" + importe + "'," + nrotalonario + "," + nroSucursal + "," + talonariotipoComprobante + "," + moneda +","+empresa + ")";
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();


           }
           catch (Exception ex)
           {

               Console.WriteLine("Error: {0}", ex.ToString());
               respu = false;
           }
           finally
           {

               if (cn != null)
                   cn.Close();
           }

           return respu;
       }




       public static DataSet ConsultarSituacionImpositiva(int cliente)
       {
          
           MySqlConnection cn = null;
           DataSet ds = new DataSet();
           try
           {
               string consulta = "select situacioniva from clientedatosimpositivos where cliente_codCliente=" + cliente;
               cn = new MySqlConnection(connectionString);
               cn.Open();
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


       public static DataSet ConsultarNroCuenta(int cliente)
       {

           MySqlConnection cn = null;
           DataSet ds = new DataSet();
           try
           {
               string consulta = "SELECT nroCuenta,total,banco_idbanco FROM cuentacorriente where cliente_codCliente=" + cliente;
               cn = new MySqlConnection(connectionString);
               cn.Open();
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







       public static ArrayList ObtenerTalonario(int tipoComprobante)
       {
           ArrayList all = new ArrayList();
           MySqlConnection cn = null;
           DataSet ds = new DataSet();
           try
           {
               string consulta = "select nroTalonario, ultimoUtilizado, hasta from talonario where tiposcomprobante_idtipocomprobante=" + tipoComprobante;
               cn = new MySqlConnection(connectionString);
               cn.Open();
               MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
               da.Fill(ds);

               
               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   ArrayList array = new ArrayList();
                   IEnumerator en = ds.Tables[0].Rows[i].ItemArray.GetEnumerator();
                   while (en.MoveNext())
                   {
                       array.Add(en.Current);
                   }
                   all.Add(array);

               }
           
           }
           catch (Exception ex)
           {
               System.Diagnostics.Debug.WriteLine(ex.Message);
               System.Diagnostics.Debug.WriteLine(ex.StackTrace);
           }

           if (cn != null)
               cn.Close();

           return all;
       }



       public static ArrayList ObtenerDescuentoFinanciero(int nroDescuento)
       {
           ArrayList all = new ArrayList();
           MySqlConnection cn = null;
           DataSet ds = new DataSet();
           try
           {
               string consulta = "select descuento, porcentaje from descuentosfinancieros where iddescuentosfinancieros =" + nroDescuento;
               cn = new MySqlConnection(connectionString);
               cn.Open();
               MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
               da.Fill(ds);


               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   ArrayList array = new ArrayList();
                   IEnumerator en = ds.Tables[0].Rows[i].ItemArray.GetEnumerator();
                   while (en.MoveNext())
                   {
                       array.Add(en.Current);
                   }
                   all.Add(array);
               }
           }
           catch (Exception ex)
           {
               System.Diagnostics.Debug.WriteLine(ex.Message);
               System.Diagnostics.Debug.WriteLine(ex.StackTrace);
           }

           if (cn != null)
               cn.Close();
           return all;
       }


       public static ArrayList ObtenerDescuentoComercial(int nroDescuento)
       {
           ArrayList all = new ArrayList();
           MySqlConnection cn = null;
           DataSet ds = new DataSet();
           try
           {
               string consulta = "select porcentaje, recargo from lineadescuento where descuentoscomerciales_iddescuentoscomerciales=" + nroDescuento;
               cn = new MySqlConnection(connectionString);
               cn.Open();
               MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
               da.Fill(ds);


               for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
               {
                   ArrayList array = new ArrayList();
                   IEnumerator en = ds.Tables[0].Rows[i].ItemArray.GetEnumerator();
                   while (en.MoveNext())
                   {
                       array.Add(en.Current);
                   }
                   all.Add(array);
               }
           }
           catch (Exception ex)
           {
               System.Diagnostics.Debug.WriteLine(ex.Message);
               System.Diagnostics.Debug.WriteLine(ex.StackTrace);
           }

           if (cn != null)
               cn.Close();
           return all;
       }
   



       public static void IncrementarNroTalonarioUtilizado(int nroTalonario)
       {
         

           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "UPDATE talonario SET ultimoUtilizado=ultimoUtilizado+1 WHERE nroTalonario="+nroTalonario;
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();


           }
           catch (Exception ex)
           {

               Console.WriteLine("Error: {0}", ex.ToString());
              
           }
           finally
           {

               if (cn != null)
                   cn.Close();
           }

         
       }





       public static void ingresarCompensacionComprobante(int nroComprobante, double totalAplicar)
       {


           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "UPDATE comprobantesventa SET total=total+'"+totalAplicar +"' WHERE numero=" + nroComprobante;
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();


           }
           catch (Exception ex)
           {

               Console.WriteLine("Error: {0}", ex.ToString());

           }
           finally
           {
               if (cn != null)
                   cn.Close();
           }
       }




        
       public static bool ingresarSaldoyAjustes(int nroCuenta, double debe, double haber)
       {
           bool respu = true;
           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "UPDATE cuentacorriente SET total=total-"+haber+"+"+debe+" WHERE nroCuenta=" + nroCuenta;
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Console.WriteLine("Error: {0}", ex.ToString());
               respu = false;
           }
           finally
           {
               if (cn != null)
                   cn.Close();
           }
           return respu;
       }

       public static bool ingresarComprobanteAnulado(int nroComprobante)
       {
           bool respu = true;
           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "UPDATE comprobantesventa SET habilitado=0 WHERE numero="+nroComprobante;
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Console.WriteLine("Error: {0}", ex.ToString());
               respu = false;
           }
           finally
           {
               if (cn != null)
                   cn.Close();
           }
           return respu;
       }









       public static bool RegistrarMovimiento(DateTime fecha, double importe, string descripcion, string tipoMovimiento, long empresa, int nroCuenta, int idBanco, int cliente, double saldo)
       {
           bool respu = true;

           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "INSERT INTO movimiento (fecha, importe, total, descripcion, tipomovimiento_descripcion, "+
               "tipomovimiento_empresa_idempresa, CuentaCorriente_nroCuenta, CuentaCorriente_banco_idbanco, CuentaCorriente_banco_empresa_idempresa,"+
               "CuentaCorriente_cliente_codCliente, CuentaCorriente_cliente_empresa_idempresa)"+
               "values(" + GuardarFechaHora(fecha) + ",'" + importe + "','" + saldo + "','" + descripcion + "','" + tipoMovimiento + "'," + empresa + "," + nroCuenta + "," + idBanco + "," + empresa + "," + cliente + "," + empresa + ")";
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Console.WriteLine("Error: {0}", ex.ToString());
               respu = false;
           }
           finally
           {
               if (cn != null)
                   cn.Close();
           }
           return respu;
       }




       public static bool RegistrarCobranza(DateTime fecha,double importeNeto, double importeBruto, int codCliente, long empresa)
       {
           bool respu = true;

           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "INSERT INTO cobranza (fecha, importeNeto, importeBruto, cliente_codCliente, cliente_empresa_idempresa) values(" + GuardarFechaHora(fecha) + ",'" + importeNeto + "','" + importeBruto + "'," + codCliente + "," + empresa + ")";
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Console.WriteLine("Error: {0}", ex.ToString());
               respu = false;
           }
           finally
           {
               if (cn != null)
                   cn.Close();
           }
           return respu;
       }


       public static bool RegistrarComprobanteAnulado(DateTime fecha,  int talonario, string tipoComprobante, int sucursal, int moneda, int nroComprobante, int empresa)
       {
           bool respu = true;

           MySqlConnection cn = null;
           try
           {
               cn = new MySqlConnection(connectionString);
               cn.Open();
               string consulta = "INSERT INTO comprobantesventasanulados (fechaAnulacion, comprobantesventa_empresa_idempresa, comprobantesventa_talonario_nroTalonario,comprobantesventa_talonario_sucursal_codigoSucursal, comprobantesventa_talonario_tiposcomprobante_idtipocomprobante,comprobantesventa_moneda_idmoneda,comprobantesventa_numero)"+
                "values('" + GuardarFechaHora(fecha) + "'," + empresa + "," + talonario + "," + sucursal + ",'" + tipoComprobante + "'," + moneda + "," + nroComprobante + ")";
               MySqlCommand cmd = new MySqlCommand(consulta, cn);
               cmd.ExecuteNonQuery();
           }
           catch (Exception ex)
           {
               Console.WriteLine("Error: {0}", ex.ToString());
               respu = false;
           }
           finally
           {
               if (cn != null)
                   cn.Close();
           }
           return respu;
       }







       public static DataSet ObtenerResumenDeCuenta(int cliente,int nroCuenta, int idBanco)
       {

           MySqlConnection cn = null;
           DataSet ds = new DataSet();
           try
           {
               string consulta = "select CuentaCorriente_nroCuenta as NroCuenta, fecha as Fecha, haber as importe,b.descripcion as 'banco', c.razonSocial as 'Cliente'"
               + "from movimiento m inner join banco b  ON  b.idbanco = m.CuentaCorriente_banco_idbanco " +
               " LEFT join cliente c on m.CuentaCorriente_cliente_codCliente = c.codCliente " +
                "where CuentaCorriente_nroCuenta=" + nroCuenta + "and CuentaCorriente_banco_idbanco=" + idBanco + "and CuentaCorriente_cliente_codCliente=" + cliente +
                "group by CuentaCorriente_nroCuenta , fecha , haber ,b.descripcion , c.razonSocial";
               cn = new MySqlConnection(connectionString);
               cn.Open();
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







        #endregion









    }//clase
}//namespace
