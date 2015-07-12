using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PhantomDb.Entidades;

namespace PhantomDb.Armadores
{
    public partial class Armador
    {
        #region Métodos soporte
        /// <summary>
        /// Genera el nombre del armador.
        /// </summary>
        /// <param name="t"></param>
        protected void GenerarNombreArmador(Type t)
        {
            try
            {
                foreach (object tab in t.GetCustomAttributes(true))
                {
                    if (tab.GetType().Equals(typeof(Tabla)))
                    {
                        this.Nombre = ((Tabla)tab).Nombre;
                        break;
                    }
                }
            }
            catch
            {
                this.Nombre = "";
            }
            finally
            {
                if (this.Nombre.Equals(""))
                {
                    this.Nombre = t.Name;
                }
            }
        }

        /// <summary>
        /// Asocia una instancia al armador, y lee sus valores.
        /// </summary>
        /// <param name="o"></param>
        protected void AsociarYLeer(object o)
        {
            InstanciaAsociada = o;
            this.CopyFromInstance();
        }

        /// <summary>
        /// Asocia una instancia al armador, y escribe sobre sus valores.
        /// </summary>
        /// <param name="o"></param>
        protected void AsociarYEscribir(object o)
        {
            InstanciaAsociada = o;
            this.CopyToInstance();
        }

        /// <summary>
        /// Valores necesarios para encontrar una determinada instancia en la base 
        /// de datos, expresados en formato de consulta.
        /// </summary>
        /// <returns></returns>
        protected string ValoresWhere
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                if (Identificadores.Count > 0)
                {
                    sb.Append(Identificadores[0].Nombre);
                    sb.Append(" = ");
                    sb.Append(this.ValorToBd(Identificadores[0]));

                    for (int i = 1; i < Identificadores.Count; i++)
                    {
                        sb.Append(" AND ");
                        sb.Append(Identificadores[i].Nombre);
                        sb.Append(" = ");
                        sb.Append(this.ValorToBd(Identificadores[i]));
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Devuelve el valor procesado los atributos escribibles del objeto, separado
        /// con comas.
        /// </summary>
        /// <returns></returns>
        protected string ValoresSeparadosPorComa
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<Atributos> at = new List<Atributos>();

                foreach (Atributos a in Atributos)
                {
                    if (!a.SoloLectura)
                        at.Add(a);
                }

                if (at.Count > 0)
                {
                    sb.Append(this.ValorToBd(at[0]));

                    for (int i = 1; i < at.Count; i++)
                    {
                        sb.Append(",");
                        sb.Append(this.ValorToBd(at[i]));
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Devuelve el valor procesado los atributos escribibles del objeto, separado
        /// con comas, siempre que ellos no sean autonuméricos.
        /// </summary>
        /// <returns></returns>
        protected string ValoresInsertSeparadosPorComa
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<Atributos> at = new List<Atributos>();

                foreach (Atributos a in Atributos)
                {
                    if (!a.Autogenerado)
                        at.Add(a);
                }

                if (at.Count > 0)
                {
                    sb.Append(this.ValorToBd(at[0]));

                    for (int i = 1; i < at.Count; i++)
                    {
                        sb.Append(",");
                        sb.Append(this.ValorToBd(at[i]));
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Devuelve el valor procesado para setear los atributos 
        /// escribibles del objeto mediante parámetros, separado 
        /// con comas. 
        /// </summary>
        /// <returns></returns>
        protected string UpdateValoresParam
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<Atributos> at = new List<Atributos>();

                foreach (Atributos a in Atributos)
                {
                    if (!a.SoloLectura)
                        at.Add(a);
                }

                if (at.Count > 0)
                {
                    sb.Append(at[0].Nombre);
                    sb.Append(" = ");
                    sb.Append(at[0].Valor.ToString());

                    for (int i = 1; i < at.Count; i++)
                    {
                        sb.Append(",");
                        sb.Append(at[i].Nombre);
                        sb.Append(" = ");
                        sb.Append(at[i].Valor.ToString());
                    }
                }

                return sb.ToString();
            }
        }
        /// <summary>
        /// Devuelve el valor procesado para setear los atributos 
        /// escribibles del objeto mediante parámetros, separado 
        /// con comas. 
        /// </summary>
        /// <returns></returns>
        protected string UpdateValores
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<Atributos> at = new List<Atributos>();

                foreach (Atributos a in Atributos)
                {
                    if (!a.SoloLectura)
                        at.Add(a);
                }

                if (at.Count > 0)
                {
                    sb.Append(at[0].Nombre);
                    sb.Append(" = ");
                    sb.Append(this.ValorToBd(at[0]));

                    for (int i = 1; i < at.Count; i++)
                    {
                        sb.Append(",");
                        sb.Append(at[i].Nombre);
                        sb.Append(" = ");
                        sb.Append(this.ValorToBd(at[i]));
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string NombresSeparadosPorComa
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<Atributos> at = new List<Atributos>();

                foreach (Atributos a in Atributos)
                {
                    at.Add(a);
                }

                if (at.Count > 0)
                {
                    sb.Append(at[0].Nombre);

                    for (int i = 1; i < at.Count; i++)
                    {
                        sb.Append(",");
                        sb.Append(at[i].Nombre);
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string NombresUpdateSeparadosPorComa
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<Atributos> at = new List<Atributos>();

                foreach (Atributos a in Atributos)
                {
                    if (!a.SoloLectura)
                        at.Add(a);
                }

                if (at.Count > 0)
                {
                    sb.Append(at[0].Nombre);

                    for (int i = 1; i < at.Count; i++)
                    {
                        sb.Append(",");
                        sb.Append(at[i].Nombre);
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Nombres de valores usados para hacer un insert.
        /// </summary>
        /// <returns></returns>
        protected string NombresInsertSeparadosPorComa
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<Atributos> at = new List<Atributos>();

                foreach (Atributos a in Atributos)
                {
                    if (!a.Autogenerado)
                        at.Add(a);
                }

                if (at.Count > 0)
                {
                    sb.Append(at[0].Nombre);

                    for (int i = 1; i < at.Count; i++)
                    {
                        sb.Append(",");
                        sb.Append(at[i].Nombre);
                    }
                }

                return sb.ToString();
            }
        }

        /// <summary>
        /// Procesa el valor para que sea compatible con el de la base de datos.
        /// Ejemplo, si es un string, le agrega las comillas.
        /// </summary>
        /// <param name="at"></param>
        /// <returns></returns>
        protected string ValorToBd(Atributos at)
        {
            Type t = at.Property.PropertyType;

            try
            {
                if (t.Equals(typeof(bool)))
                {
                    bool valor = (bool)at.Valor;
                    if (valor)
                        return "1";
                    else
                        return "0";
                }
                else if (t.Equals(typeof(string)))
                {
                    if (at.Valor == null)
                        return "''";
                    else
                        return "'" + at.Valor.ToString() + "'";
                }
                else if (t.Equals(typeof(DateTime)))
                {
                    if (at.Valor == null)
                        return "''";
                    else
                    {
                        var sb = new StringBuilder();
                        sb.Append("'");
                        DateTime valor = (DateTime)at.Valor;
                        if (at.Columna.Formato.Tipo.Equals(Formato.DateTimeType))
                        {
                            sb.Append(valor.ToString("yyyy-MM-dd HH:mm:ss.fffffff"));
                        }
                        else if (at.Columna.Formato.Tipo.Equals(Formato.TimeType))
                        {
                            sb.Append(valor.ToString("HH:mm:ss.fffffff"));
                        }
                        else
                        {
                            sb.Append(valor.ToString("yyyy-MM-dd"));
                        } 
                        sb.Append("'");
                        return sb.ToString();
                    }
                }
                else
                {
                    if (at.Valor == null)
                        return "";
                    else
                        return at.Valor.ToString();
                }
            }
            catch
            {
                return at.Valor.ToString();
            }
        }

        /// <summary>
        /// Copia los valores de los atributos de la instancia asociada. 
        /// Si la instancia no existe no hace nada.
        /// </summary>
        protected void CopyFromInstance()
        {
            if (InstanciaAsociada != null)
            {
                foreach (Atributos a in Atributos)
                {
                    a.LeerDeInstancia();
                }
            }
        }

        /// <summary>
        /// Copia los valores de los atributos de la clase a la instancia asociada. 
        /// Si la instancia asociada no existe, entonces intenta crearla.
        /// </summary>
        /// <returns>Success = true, Fail = false.</returns>
        protected bool CopyToInstance()
        {
            if (InstanciaAsociada == null)
            {
                try
                {
                    InstanciaAsociada = Tipo.GetConstructor(System.Type.EmptyTypes).Invoke(new Object[0]);
                }
                catch
                {
                    InstanciaAsociada = null;
                }
            }

            if (InstanciaAsociada != null)
            {
                foreach (Atributos a in Atributos)
                {
                    try
                    {
                        this.GetAtributo(a.Nombre).EscribirEnInstancia();
                    }
                    catch { }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Crea un nuevo objeto, usando los valores cargados en el armador.
        /// </summary>
        /// <returns></returns>
        public object CrearInstancia()
        {
            InstanciaAsociada = null;
            if (CopyToInstance())
            {
                object ret = InstanciaAsociada;
                InstanciaAsociada = null;
                return ret;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Escribe un valor en un atributo de manera segura.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="valor"></param>
        private void SetValorToAtributo(int index, object valor)
        {
            try
            {
                try
                {
                    Atributos[index].Valor = valor;
                }
                catch(Exception ex)
                {
                    Atributos[index].Valor = FromString.GetFromString(Atributos[index].Tipo, valor.ToString());
                }
            }
            catch
            {
                Atributos[index].Valor = null;
            }
        }

        /// <summary>
        /// Obtiene los atributos de un arreglo y se los asigna a la instancia.
        /// </summary>
        /// <param name="atributos"></param>
        public void AsignarAtributos(object[] atributos)
        {
            for (int i = 0; i < atributos.Length; i++)
            {
                SetValorToAtributo(i, atributos[i]);
            }
        }       
        
        /// <summary>
        /// Obtiene los atributos de un ArrayList y se los asigna al armador.
        /// </summary>
        /// <param name="atributos"></param>
        public void AsignarAtributos(ArrayList atributos)
        {
            for (int i = 0; i < atributos.Count; i++)
            {
                SetValorToAtributo(i, atributos[i]);
            }
        }

        /// <summary>
        /// Devuelve los valores de los atributos en forma de ArrayList
        /// </summary>
        /// <returns></returns>
        public ArrayList ArrayListAtributos()
        {
            ArrayList array = new ArrayList();
            foreach (Atributos a in Atributos)
            {
                array.Add(a.Valor);
            }
            return array;
        }

        #endregion
    }
}
