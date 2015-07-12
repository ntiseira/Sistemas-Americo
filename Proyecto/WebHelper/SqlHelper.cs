using System;
using PhantomDb;
using PhantomDb.Armadores;
using PhantomDb.Entidades;
using System.Collections.Generic;
using System.Text;

namespace WebHelper
{
    /// <summary>
    /// Armador que agrega @ o valores a sus atributos.
    /// </summary>
    public class SqlHelper: Armador
    {
        public static SqlHelper Generar(Type t)
        {
            ArmadorFactory af = new ArmadorFactory(null);
            return Generar(af.CreateFromClass(t), null);
        }

        public static SqlHelper Generar(Type t, SqlValor [] valores)
        {
            ArmadorFactory af = new ArmadorFactory(null);
            return Generar(af.CreateFromClass(t), valores);
        }

        public static SqlHelper Generar(Armador arm, SqlValor[] valores)
        {
            SqlHelper sql = new SqlHelper(arm.Tipo, valores);

            sql.Nombre = arm.Nombre;

            foreach (Atributos a in arm.Atributos)
            {
                sql.Agregar(a);
            }

            foreach (Atributos a in arm.Identificadores)
            {
                sql.Identificadores.Add(a);
            }

            sql.ProcesarAtributos();

            return sql;
        }

        Dictionary<string, object> valores = new Dictionary<string, object>();

        private SqlHelper(Type tipo)
            : this(tipo, null)
        { }

        private SqlHelper(Type tipo, SqlValor[] valores)
            : base(tipo)
        {
            Identificadores.Clear();
            Atributos.Clear();

            if (valores != null)
            {
                foreach (SqlValor v in valores)
                {
                    this.valores[v.Nombre] = v.Valor;
                }
            }
        }

        internal void ProcesarAtributos()
        {
            foreach (Atributos a in Atributos)
            {
                if (valores.ContainsKey(a.Nombre))
                    a.Valor = valores[a.Nombre];
                else
                    a.Valor = "@" + a.Nombre;
            }
        }

        public string SelectCommand()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT ");
            sb.Append(NombresSeparadosPorComa);
            sb.Append(" FROM ");
            sb.Append(Nombre);

            if (this.valores.Count > 0)
            {
                sb.Append(" WHERE (");
                Dictionary<string, object>.Enumerator e = valores.GetEnumerator();
                e.MoveNext();
                sb.Append(e.Current.Key);
                sb.Append("=");
                sb.Append(e.Current.Value);
                while (e.MoveNext())
                {
                    sb.Append(" AND ");
                    sb.Append(e.Current.Key);
                    sb.Append("=");
                    sb.Append(e.Current.Value);
                }
                sb.Append(")");
            }

            return sb.ToString();
        }
        public string SelectCommand(bool all)
        {
            if (all)
            {
                return String.Format("SELECT {1} FROM {0}", Nombre, NombresSeparadosPorComa);
            }
            else
            {
                return String.Format("SELECT {1} FROM {0} WHERE {2}", Nombre, NombresSeparadosPorComa, ValoresWhere.Replace("'", ""));
            }
        }

        public string InsertCommand()
        {
            return String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                Nombre, NombresInsertSeparadosPorComa, ValoresInsertSeparadosPorComa.Replace("'", ""));
        }

        public string DeleteCommand()
        {
            return String.Format("DELETE FROM {0} WHERE {1}",
                Nombre, ValoresWhere.Replace("'", ""));
        }

        public string DeleteRow()
        {
            return String.Format("DELETE FROM {0} WHERE {1}",
                Nombre, ValoresWhere);
        }

        public string UpdateCommand()
        {
            return String.Format("UPDATE {0} SET {1} WHERE {2}",
                Nombre, UpdateValoresParam, ValoresWhere.Replace("'", ""));
        }
    }
}
