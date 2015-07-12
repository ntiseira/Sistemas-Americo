using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;  

namespace Datos.SueldosyJornales
{
    public static class DatosSueldosJornales
    {
        //CONEXION CON MYSQL
        static string connectionString = "Server=localhost;Database=basedatos;Uid=root;Pwd=;";


        #region CONSULTAS SELECT

        public static DataSet darSueldos()
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM Sueldos";
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

        public static DataSet darJornales()
        {
            MySqlConnection cn = new MySqlConnection(connectionString);
            string consulta = "SELECT * FROM Jornales";
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

        #endregion

        #region CONSULTAS INSERT

        #endregion

        #region CONSULTAS UPDATE

        #endregion

        #region CONSULTAS DELETE

        #endregion


    }
}
