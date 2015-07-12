using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections;
using CapaDatos;

namespace CapaDatos.VentasCuentasCobrar
{
   public static class Datos
    {
       
        //CONEXION CON MYSQL
        private static string connectionString = "Server=localhost;Database=siscont;Uid=root;Pwd=;";

        public static DataSet ObtenerClientes()
        {

            return CapaDatos.Datos.Consultar(
                string.Format(
                "SELECT * FROM Cliente;"
                ));
        }

        public static ArrayList darClientes()
        {

            ArrayList all = null;

            try
            {
                DataSet ds = new DataSet();
                ds = ObtenerClientes();
                all = new ArrayList();

                int i;

                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
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
                string asd = ex.Message;
            }

            return all;
        }




        #region ABM Clientes



        public static bool agregarCliente(long codigo, string razonSocial, string mail, string comentario, string direccion,
            string localidad, int cod, string prov, long tel, long fax)
       { 
            bool respu = true;
            MySqlConnection cn = new MySqlConnection(connectionString);
            try
            {
              
                cn.Open();
                string sentencia = "INSERT INTO empresa (codigo, razonsocial, mail, comentario, direccion, localidad, provincia, codigopostal, telefono, fax) " +
                "VALUES (" + codigo + ",'" + razonSocial + "','" + mail + "','" + comentario + "','" + direccion + "','" + localidad + "','" + prov + "'," + cod+ "," + tel + "," +fax + ")";
                MySqlCommand cmd = new MySqlCommand(sentencia, cn);
                cmd.ExecuteNonQuery();
                
            }
            catch
            {
                respu = false;
            }
            cn.Close(); 
            return respu;
        }

        public static bool actualizarCliente(long codigo, string razonSocial, string mail, string comentario, string direccion,
            string localidad, int cod, string prov, long tel, long fax)
        {
            bool respu = true;
            MySqlConnection cn = new MySqlConnection(connectionString);
            string sentencia = "UPDATE empresa SET  razonsocial='"+razonSocial +"',  mail='" + mail + "', comentario='" + comentario+ "',direccion='" +direccion + "', localidad='" + localidad+"', codigopostal="+cod+", telefono="+tel+",fax="+fax + " WHERE codigo=" + codigo;            
            try
            {
             
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(sentencia, cn);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                respu = false;
            }
            cn.Close();
            return respu;
        }

        public static bool verificarCliente(long cod)
        {
            string query = "SELECT * FROM empresa WHERE codigo = " + cod;
            DataSet ds = new DataSet();                     
            MySqlConnection cn = new MySqlConnection(connectionString);
            cn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
            da.Fill(ds);
            cn.Close();
            if (ds.Tables[0].Rows.Count == 1)
                return true;
            else
                return false;

        }

        public static bool eliminarCliente(long cod)
        {
            bool respu = true;
            string sentencia = "DELETE FROM clientes WHERE codigo = " + cod;
            MySqlConnection cn = new MySqlConnection(connectionString);
            try
            {            
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(sentencia, cn);
                cmd.ExecuteNonQuery();
              
            }
            catch
            {
                respu = false;
            }
            cn.Close();
            return respu;
        }


        public static int getCodigoCliente()
        {
            string query = " SELECT MAX(codigo) FROM clientes";
            DataSet ds = new DataSet();
            MySqlConnection cn = new MySqlConnection(connectionString);
         
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
                da.Fill(ds);
            }
            catch
            {
                ds = null;
            }
            cn.Close();

            if (ds.Tables[0].Rows.Count == 1)
            {
                return int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString());
            }
            else
            {
                return 1;
            }
        }





        #endregion
       
        #region ABM Empleados


        public static bool agregarEmpleado(long cE, string t, string c, string an, string ec, string tdoc, long ndoc, string nac, DateTime fechaNac, string dom,
            string loc, string cp, int pro, string tel, string m, double capI, bool g, string comCap, string car)
        {
            bool respu = true;
            MySqlConnection cn = new MySqlConnection(connectionString);
            try
            {

                cn.Open();
                string sentencia = "INSERT INTO empleado " +
                "VALUES (" + cE + ",'" + t + "','" + c + "','" + an + "','"
                + ec + "','" + tdoc + "'," + ndoc + ",'" + nac + "'," + fechaNac + ",'" + dom + "','" + loc + "','" + cp + "'," + pro + ",'" + tel + "','" + m + "'," + capI + "," + g + ",'" + comCap + "','"+car+ "')";
                MySqlCommand cmd = new MySqlCommand(sentencia, cn);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                respu = false;
            }
            cn.Close();
            return respu;
        }

        public static bool actualizarEmpleado(long cE, string t, string c, string an, string ec, string tdoc, long ndoc, string nac, DateTime fechaNac, string dom,
            string loc, string cp, int pro, string tel, string m, double capI, bool g, string comCap, string car)
        {
            bool respu = true;
            MySqlConnection cn = new MySqlConnection(connectionString);
            string sentencia = "UPDATE empleado SET  tipo='" + t + "', categoria="+c + "', apellidoNombre='"+ an
                + "', estadoCivil='" + ec + "', tipoDoc='" + tdoc + "', nroDoc=" + ndoc + ", nacionalidad='" + nac + "', fechaNac="+ fechaNac + ",domicilio='"+dom+ "', localidad='"+ loc + "', codPostal='"+cp + "', provincia="+ pro+ ", tel="+tel+ ", mail='"+ m+"', capitalInicial='"+capI+"', garantia="+g+", composcicionCapital='"+ comCap+"', cargo='"+ car  + "' WHERE codEmpleado=" + cE;
            try
            {

                cn.Open();
                MySqlCommand cmd = new MySqlCommand(sentencia, cn);
                cmd.ExecuteNonQuery();
            }
            catch
            {
                respu = false;
            }
            cn.Close();
            return respu;
        }

        public static bool verificarEmpleado(long cod)
        {
            string query = "SELECT * FROM empleado WHERE codEmpleado = " + cod;
            DataSet ds = new DataSet();
            MySqlConnection cn = new MySqlConnection(connectionString);
            cn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(query, cn);
            da.Fill(ds);
            cn.Close();
            if (ds.Tables[0].Rows.Count == 1)
                return true;
            else
                return false;

        }

        public static bool eliminarEmpleado(long cod)
        {
            bool respu = true;
            string sentencia = "DELETE FROM empleado WHERE codEmpleado = " + cod;
            MySqlConnection cn = new MySqlConnection(connectionString);
            try
            {
                cn.Open();
                MySqlCommand cmd = new MySqlCommand(sentencia, cn);
                cmd.ExecuteNonQuery();

            }
            catch
            {
                respu = false;
            }
            cn.Close();
            return respu;
        }



        #endregion
       




    }//clase
}//namespace
