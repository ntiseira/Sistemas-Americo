using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using PhantomDb;
using PhantomDb.Armadores;
using PhantomDb.Entidades;
using System.Collections;
using CapaDatos;
using Ext.Net.UX;
using System.Globalization;

#warning No funcionan los valores fijos en campos booleanos.

namespace WebHelper
{
    /// <summary>
    /// Genera interfaces usando armadores de PhantomDb.
    /// </summary>
    public class Storer
    {
        ArmadorFactory af = new ArmadorFactory(null);
        Armador armador;

        public Armador Armador
        {
            get { return armador; }
            set { armador = value; }
        }
        Type t;

        SqlValor[] valores = null;
        public SqlValor[] Valores
        {
            get { return valores; }
            set { valores = value; }
        }

        SqlValor[] valoresCombo = null;
        public SqlValor[] ValoresCombo
        {
            get { return valoresCombo; }
            set { valoresCombo = value; }
        }

        public Storer(Type t)
        {
            this.t = t;
            this.af.Consultar = Datos.Consultar;
            this.armador = af.CreateFromClass(t);
        }

        public static TypeCode GetTypeCode(Type t)
        {
            return Parameter.ConvertDbTypeToTypeCode(GetType(t));
        }

        public enum BasicType
        {
            Text,
            Bool,
            Number,
            Date
        }

        public static BasicType GetBasicType(Type t)
        {
            switch (t.Name.ToLower())
            {
                case "bool":
                case "boolean":
                    return BasicType.Bool;

                case "byte":
                case "decimal":
                case "double":
                case "float":
                case "int":
                case "int16":
                case "int32":
                case "int64":
                case "long":
                    return BasicType.Number;

                case "char":
                case "string":
                    return BasicType.Text;

                case "date":
                case "datetime":
                case "timespan":
                    return BasicType.Date;

                default:
                    return BasicType.Number;
            }
        }


        public static System.Data.DbType GetType(Type t)
        {
            if (t.Equals(typeof(String)))
            {
                return System.Data.DbType.String;
            }
            else if (t.Equals(typeof(Int64)))
            {
                return System.Data.DbType.Int64;
            }
            else if (t.Equals(typeof(Int32)))
            {
                return System.Data.DbType.Int32;
            }
            else if (t.Equals(typeof(Int16)))
            {
                return System.Data.DbType.Int16;
            }
            else if (t.Equals(typeof(float)))
            {
                return System.Data.DbType.Single;
            }
            else if (t.Equals(typeof(double)))
            {
                return System.Data.DbType.Double;
            }
            else if (t.Equals(typeof(byte[])))
            {
                return System.Data.DbType.Binary;
            }
            else if (t.Equals(typeof(DateTime)))
            {
                return System.Data.DbType.DateTime;
            }
            else if (t.Equals(typeof(Decimal)))
            {
                return System.Data.DbType.Decimal;
            }
            else if (t.Equals(typeof(Guid)))
            {
                return System.Data.DbType.Guid;
            }
            else if (t.Equals(typeof(object)))
            {
                return System.Data.DbType.Object;
            }
            else if (t.Equals(typeof(bool)))
            {
                return System.Data.DbType.Boolean;
            }
            else if (t.Equals(typeof(byte)))
            {
                return System.Data.DbType.Byte;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Warning, tipo "+t.ToString()+" no reconocido. Seteado como String por defecto.");
                return System.Data.DbType.String;
            }
        }

      



        /// <summary>
        /// Establece las consultas del sql datasource.
        /// </summary>
        /// <param name="ds"></param>
        public void ObjectToSqlDataSource(ref SqlDataSource ds)
        {
            foreach (Atributos a in armador.Atributos)
            {
                Parameter param = new Parameter(a.Nombre);
                param.Type = GetTypeCode(a.Property.PropertyType);

                if (armador.EsIdentificador(a) && !EstaEnValores(a.Nombre))
                {
                    ds.DeleteParameters.Add(param);
                }

                if (!a.SoloLectura)
                {
                    ds.UpdateParameters.Add(param);
                }

                if (!a.Autogenerado && !EstaEnValores(a.Nombre))
                {
                    ds.InsertParameters.Add(param);
                }
            }
        }

        /// <summary>
        /// Indica si el valor de un campo fue pre-establecido.
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
        private bool EstaEnValores(string nombre)
        {
            if(Valores != null)
            {
                foreach (SqlValor v in Valores)
                {
                    if (v.Nombre.Equals(nombre))
                        return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// Agrega campos al store.
        /// </summary>
        /// <param name="st"></param>
        public void ObjectToStore(ref Ext.Net.Store st)
        {
            foreach (Atributos a in armador.Atributos)
            {
                st.AddField(new Ext.Net.RecordField(a.Nombre, Ext.Net.RecordFieldType.Auto));
            }
        }

        /// <summary>
        /// Genera las columnas del gridpanel.
        /// </summary>
        /// <param name="gp"></param>
        public void ObjectToGridPanel(ref Ext.Net.GridPanel gp)
        {
            foreach (Atributos a in armador.Atributos)
            {
                TypeCode tc = GetTypeCode(a.Tipo);
                Ext.Net.ColumnBase.Config cf;

                switch (tc)
                {
                    case TypeCode.Boolean:
                        {
                            if (!a.Columna.ValoresFijos)
                                cf = new Ext.Net.CheckColumn.Config();
                            else
                                cf = new Ext.Net.Column.Config();
                        }
                        break;

                    case TypeCode.DateTime:
                        {
                            cf = new Ext.Net.DateColumn.Config() { Format = a.Columna.Formato.Valor };
                        }
                        break;

                    default:
                        cf = new Ext.Net.Column.Config();
                        break;
                }

                if(armador.EsIdentificador(a))
                {
                    cf.ColumnID = a.Nombre;
                }
                cf.Editable = !a.Autogenerado;
                cf.DataIndex = a.Nombre;
                cf.Header = a.Columna.Titulo;

                Ext.Net.ColumnBase col;

                switch (tc)
                {
                    case TypeCode.Boolean:
                        {
                            if (!a.Columna.ValoresFijos)
                            {
                                col = new Ext.Net.CheckColumn((Ext.Net.CheckColumn.Config)cf);
                            }
                            else
                            {
                                col = new Ext.Net.Column((Ext.Net.Column.Config)cf);
                                col.Editor.Add(GenerarCampoCombo(a.Columna.Valores));
                            }
                        }
                        break;

                    case TypeCode.DateTime:
                        {
                            col = new Ext.Net.DateColumn((Ext.Net.DateColumn.Config)cf);
                            col.Editor.Add(GenerarCampo(tc));
                        }
                        break;

                    default:
                        {
                            col = new Ext.Net.Column((Ext.Net.Column.Config)cf);
                            if (!a.Autogenerado)
                            {
                                // Si no es una relación
                                if (a.Relacion == null)
                                {
                                    if (!a.Columna.ValoresFijos)
                                    {
                                        col.Editor.Add(GenerarCampo(tc));
                                    }
                                    else
                                    {
                                        col.Editor.Add(GenerarCampoCombo(a.Columna.Valores));
                                    }


                            if (a.EsLetra == true)
                            {

                                Ext.Net.UX.InputTextMask mascara = new InputTextMask();
                                mascara.Mask = "L";

                                col.Editor.Editor.Plugins.Add(mascara);
                            }
                             if (a.EsCuit ==  true)
                            {                             
                         
                            Ext.Net.UX.InputTextMask mascara = new InputTextMask();
                            mascara.Mask = "99-99999999-9";
                                 
                            col.Editor.Editor.Plugins.Add(mascara);
                            }
                             if (a.EsDni == true)
                             {

                                 Ext.Net.UX.InputTextMask mascara = new InputTextMask();
                                 mascara.Mask = "99.999.999";
                                 col.Editor.Editor.Plugins.Add(mascara);
                             }
                             if (a.EsImporte == true)
                             {

                                 Ext.Net.UX.InputTextMask mascara = new InputTextMask();
                                 mascara.Mask = "$99999999";
                                 col.Editor.Editor.Plugins.Add(mascara);
                             }

                             if (a.EsMail == true)
                             {

                                 Ext.Net.UX.InputTextMask mascara = new InputTextMask();
                                 mascara.Mask.Contains("@");
                                 col.Editor.Editor.Plugins.Add(mascara);
                             }
                             if (a.EsNumerico == true)
                             {
                                 Ext.Net.UX.InputTextMask mascara = new InputTextMask();
                                 mascara.Mask = "99999999999";
                                 col.Editor.Editor.Plugins.Add(mascara);
                             }
                             if (a.EsPorcentaje == true)
                             {
                                 Ext.Net.UX.InputTextMask mascara = new InputTextMask();
                                 mascara.Mask = "999%";
                                 col.Editor.Editor.Plugins.Add(mascara);
                             }

                                }
                                else // Si ES una relación
                                {
                                    List<CustomValue> valores = new List<CustomValue>();

                                    if (a.Relacion.PermitirNull)
                                        valores.Add(new CustomValue("", null));

                                    foreach (object o in a.Relacion.Resultados2)
                                    {
                                        bool match = true;
                                        var atributos = (IList<Atributos>)o;
                                        if (ValoresCombo != null)
                                        {
                                            foreach (SqlValor v in ValoresCombo)
                                            {
                                                foreach (Atributos atr in atributos)
                                                {
                                                    if (v.Nombre.Equals(atr.Nombre))
                                                    {
                                                        if (!v.Valor.ToString().Equals(atr.Valor.ToString())) // Bugfix haciendo comparación con strings, porque me pasaba que al comparar 1 != 1 decia true...
                                                        {
                                                            match = false;
                                                            break;
                                                        }
                                                    }
                                                }

                                                if (!match)
                                                    break;
                                            }
                                        }

                                        if (match)
                                        {
                                            valores.Add(new CustomValue(
                                                atributos[a.Relacion.CampoSecundario].Valor.ToString(),
                                                atributos[a.Relacion.CampoId].Valor));
                                        }

                                        //var atributos = (object[])o;
                                        //valores.Add(new CustomValue(atributos[a.Relacion.CampoSecundario].ToString(), atributos[a.Relacion.CampoId]));
                                    }
                                    col.Editor.Add(GenerarCampoCombo(valores.ToArray()));
                                }
                            }
                        }
                        break;
                }

                col.Hidden = !a.Columna.Visible;
                gp.ColumnModel.Columns.Add(col);
            }
        }

        public Atributos GetAtributosFromColumna(string nombre)
        {
            foreach (Atributos a in Armador.Atributos)
            {
                if (a.Columna != null && a.Columna.Titulo.Equals(nombre))
                {
                    return a;
                }
            }

            return null;
        }

        public static Ext.Net.GridFilter GetFilter(Ext.Net.GridFilters gf, string nombre)
        {
            foreach (Ext.Net.GridFilter filtro in gf.Filters)
            {
                if (filtro.DataIndex.Equals(nombre))
                {
                    return filtro;
                }
            }

            return null;
        }

        /// <summary>
        /// Agrega filtros a un GridFilters en base a los atributos del objeto.
        /// </summary>
        /// <param name="gf"></param>
        public void ObjectToFilters(ref Ext.Net.GridFilters gf)
        {
            gf.Filters.Clear();

            foreach (Atributos a in armador.Atributos)
            {
                if (a.Columna != null && a.Columna.Visible)
                {
                    Ext.Net.GridFilter filtro = null;

                    try
                    {
                        switch (Storer.GetBasicType(a.Tipo))
                        {
                            case BasicType.Number:
                                {
                                    filtro = new Ext.Net.NumericFilter();
                                }
                                break;
                            case BasicType.Text:
                                {
                                    filtro = new Ext.Net.StringFilter();
                                }
                                break;
                            case BasicType.Date:
                                {
                                    filtro = new Ext.Net.DateFilter();
                                }
                                break;
                            case BasicType.Bool:
                                {
                                    filtro = new Ext.Net.BooleanFilter();
                                }
                                break;
                        }

                        filtro.DataIndex = a.Nombre;

                        gf.Filters.Add(filtro);

                    }
                    catch { } // Si ocurre un error no agrega el filtro
                }
            }
        }

        /// <summary>
        /// Genera un combobox, y le agrega los valores deseados.
        /// </summary>
        /// <param name="valores"></param>
        /// <returns></returns>
        private static Ext.Net.Field GenerarCampoCombo(CustomValue[] valores)
        {
            Ext.Net.ComboBox.Config cf = new Ext.Net.ComboBox.Config();
            Ext.Net.ComboBox cb = new Ext.Net.ComboBox(cf);

            foreach (CustomValue valor in valores)
            {
                string stringValor;
                if (valor.Valor != null)
                    stringValor = valor.Valor.ToString();
                else
                    stringValor = "";

                cb.Items.Add(new Ext.Net.ListItem(valor.Nombre, stringValor));
            }

            return cb;
        }

        /// <summary>
        /// Genera un campo, utilizado en la generación de gridpanel.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns></returns>
        private static Ext.Net.Field GenerarCampo(TypeCode tipo)
        {
            switch (tipo)
            {
                //Fechas
                case TypeCode.DateTime:
                    return new Ext.Net.DateField();

                //Textos
                default:
                    {
                        Ext.Net.TextField.Config cf = new Ext.Net.TextField.Config();
                        return new Ext.Net.TextField();
                    }
            }
        }

        public String GetSelect()
        {
            SqlHelper sql = SqlHelper.Generar(t, Valores);
            return sql.SelectCommand();
        }

        public String GetInsert()
        {
            SqlHelper sql = SqlHelper.Generar(t);
            //return sql.InsertCommand();
            string str = sql.InsertCommand();
            
            if(Valores != null)
            {
                foreach (SqlValor v in this.Valores)
                {
                    str = str.Replace("@" + v.Nombre, v.Valor.ToString());
                }
            }

            return str;
        }

        public String GetUpdate()
        {
            SqlHelper sql = SqlHelper.Generar(t);
            return sql.UpdateCommand();
        }

        public String GetDelete()
        {
            SqlHelper sql = SqlHelper.Generar(t);
            string str = sql.DeleteCommand();
            
            if(Valores != null)
            {
                foreach (SqlValor v in this.Valores)
                {
                    str = str.Replace("@" + v.Nombre, v.Valor.ToString());
                }
            }
            return str;
        }

        public static bool CheckEmptyJson(Dictionary<string, string>[] companies)
        {
            if (companies.Length == 0)
            {
                return true;
            }

            foreach (Dictionary<string, string> row in companies)
            {
                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    if (!keyValuePair.Value.Equals(""))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public object MakeObjectFromRow(Dictionary<string, string>[] companies)
        {
            SqlHelper sql = SqlHelper.Generar(t);

            foreach (Dictionary<string, string> row in companies)
            {
                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    try
                    {
                        sql.GetAtributo(keyValuePair.Key).Valor = FromString.GetFromString(sql.GetAtributo(keyValuePair.Key).Tipo, keyValuePair.Value);
                    }
                    catch { } // Excepción al intentar asignar el valor a la property
                }
            }

            if (Valores != null)
            {
                foreach (SqlValor v in this.Valores)
                {
                    sql.GetAtributo(v.Nombre).Valor = v.Valor;
                }
            }

            return sql.CrearInstancia();
        }

        public string MakeDeleteRow(Dictionary<string, string>[] companies)
        {
            SqlHelper sql = SqlHelper.Generar(t);
            string str = sql.DeleteCommand();
            if(Valores != null)
            {
                foreach (SqlValor v in this.Valores)
                {
                    str = str.Replace("@" + v.Nombre, v.Valor.ToString());
                }
            }
            
            foreach (Dictionary<string, string> row in companies)
            {
                foreach (KeyValuePair<string, string> keyValuePair in row)
                {
                    try
                    {
                        sql.GetAtributo(keyValuePair.Key).Valor = keyValuePair.Value;
                    }
                    catch { } // Excepción al intentar asignar el valor a la property
                }
            }

            return sql.DeleteRow();
        }

      /*  public object MakeObjectFromRow(Dictionary[] companies)
        {
            throw new NotImplementedException();
        }*/
    }
}
