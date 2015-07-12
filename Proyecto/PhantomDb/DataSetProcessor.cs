using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace PhantomDb
{
    /// <summary>
    /// Provee de métodos para trabajar con DataSets.
    /// </summary>
    public static class DataSetProcessor
    {
        /// <summary>
        /// Chequea si el dataset esta vacía o no.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool EstaVacio(DataSet s)
        {
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
        /// Obtiene el valor de la primera columna en cada fila.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ArrayList GetValoresColumna(DataSet s)
        {
            ArrayList retorno = new ArrayList();

            foreach (DataRow dr in s.Tables[0].Rows)
            {
                retorno.Add(dr.ItemArray[0]);
            }

            return retorno;
        }

        /// <summary>
        /// Obtiene el valor de una columna específica en cada fila.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public static ArrayList GetValoresColumna(DataSet s, int columna)
        {
            ArrayList retorno = new ArrayList();

            foreach (DataRow dr in s.Tables[0].Rows)
            {
                retorno.Add(dr.ItemArray[columna]);
            }

            return retorno;
        }

        /// <summary>
        /// Obtiene los valores de la primera fila.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static object[] GetValores(DataSet s)
        {
            return s.Tables[0].Rows[0].ItemArray;
        }

        /// <summary>
        /// Obtiene los valores de la primera fila, devolviendo un ArrayList.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static ArrayList GetObjeto(DataSet s)
        {
            ArrayList retorno = new ArrayList(s.Tables[0].Rows[0].ItemArray.Length);
            retorno.AddRange(s.Tables[0].Rows[0].ItemArray);

            return retorno;
        }

        /// <summary>
        /// Obtiene una lista con todos los valores.
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
        /// Obtiene una lista con todos los atributos de los objetos.
        /// </summary>
        public static List<ArrayList> GetTotalObjetos(DataSet s)
        {
            List<ArrayList> objetos = new List<ArrayList>();

            foreach (DataRow dr in s.Tables[0].Rows)
            {
                ArrayList atributos = new ArrayList();
                atributos.AddRange(dr.ItemArray);
                /*foreach (object o in dr.ItemArray)
                {
                    atributos.Add(o);
                }*/

                objetos.Add(atributos);
            }

            return objetos;
        }
    }
}
