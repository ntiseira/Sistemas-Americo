using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;  


namespace CapaDatos.SueldosyJornales
{
    public static class DatosSueldosJornales
    {
        /// <summary>
        /// Conexión con mysql.
        /// </summary>
        /// <remarks>
        /// Unificada con la clase Datos, para que al realizarle 
        /// modificaciones no haya que aplicarlas a cada clase que 
        /// tenga acceso a base de datos.
        /// </remarks>
        private static string connectionString = Datos.ConnectionString;

        #region CONSULTAS SELECT

        public static DataSet darSueldos(long codEmpresa)
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT categoriassueldo.codigo,categoriassueldo.descripcion,sueldos.sueldo FROM categoriassueldo,sueldos WHERE categoriassueldo.codigo = sueldos.categoria and categoriassueldo.habilitado = 1 and sueldos.codEmpresa = " + codEmpresa + " and categoriassueldo.codEmpresa = sueldos.codEmpresa;";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }

        public static DataSet darLugaresPago(long codEmpresa)
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM lugarespago WHERE habilitado = 1 and codEmpresa = " + codEmpresa + ";";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }

        public static DataSet darDatosEmpleador(long codEmpresa) 
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM Empresa WHERE codEmpresa = " + codEmpresa + ";";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }


        public static DataSet devolverEmpleado(long legajo, long empresa)
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM Empleados WHERE sucursal_empresa_idempresa = " + empresa + " and legajo = " + legajo + ";";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }




        public static DataSet darObrasSociales(long codEmpresa)
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM obrasSociales WHERE obrassociales.habilitado = 1 and obrasSociales.codEmpresa = " + codEmpresa + ";";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }

        public static DataSet darFeriados(long codEmpresa)
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM feriados WHERE codEmpresa = " + codEmpresa + ";";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }

        public static DataSet darJornales(long codEmpresa)
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM jornales WHERE "+codEmpresa+" = codEmpresa;";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                cn.Close();
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }

        public static DataSet darCategorias()
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM categoriassueldo";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
            cn.Close();
            return ds;
        }

        #endregion

        #region CONSULTAS INSERT

        public static bool insertarCategoriaSueldo(string nombreCategoria, bool habilitado) 
        {
            bool result = false;
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "INSERT INTO CategoriasSueldo (descripcion, habilitado) VALUES("+nombreCategoria+","+habilitado+");";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
                result = true;
            }
            catch (Exception e)
            {
                cn.Close();
                System.Console.WriteLine(e);
            }
            cn.Close();
            return result;
        }

        public static bool insertarSueldo(string codCategoria, float sueldoBasico)
        {
            bool result = false;
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "INSERT INTO Sueldos (descripcion, habilitado) VALUES(" + codCategoria + "," + sueldoBasico + ");";
            DataSet ds = new DataSet();
            try
            {
                cn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, cn);
                da.Fill(ds);
                result = true;
            }
            catch (Exception e)
            {
                cn.Close();
                System.Console.WriteLine(e);
            }
            cn.Close();
            return result;
        }



        #endregion

        #region CONSULTAS UPDATE

        #endregion

        #region CONSULTAS DELETE

        #endregion




    }
}
