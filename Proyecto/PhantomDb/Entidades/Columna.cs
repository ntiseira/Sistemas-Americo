using System;
using System.Collections.Generic;

namespace PhantomDb.Entidades
{
    [AttributeUsage(
    AttributeTargets.Property | AttributeTargets.Field |
    AttributeTargets.Parameter | AttributeTargets.ReturnValue|AttributeTargets.Event
    , AllowMultiple = false)]
    
    public class Columna : Attribute
    {


        string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

 

        bool visible;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        private string format;
        public string Formato
        {
            get { return format; }
            set { format = value; }
        }

        private string valoresFijos;
        /// <summary>
        /// <example>
        /// Valores = "Valor 1: value1,Valor 2";
        /// </example>
        /// </summary>
        public string ValoresFijos
        {
            get { return valoresFijos; }
            set 
            {
                valoresFijos = value;

                while(valoresFijos.Contains("  "))
                {
                    valoresFijos = valoresFijos.Replace("  ", " ");
                }

                valoresFijos = valoresFijos.Replace(": ", ":").Replace(", ", ",").Replace(" :", ":").Replace(" ,",",");
            }
        }

        private string MaskRe;
        
        public string mascara
        {
           
            get { return MaskRe; }
            set { MaskRe = value; }
        }




        public CustomValue[] Valores
        {
            get
            {
                if (ValoresFijos.Equals(""))
                    return null;

                string [] pairs = ValoresFijos.Split(',');
                List<CustomValue> valores = new List<CustomValue>(pairs.Length);
                foreach (string pair in pairs)
                {
                    if (pair.Contains(":"))
                        valores.Add(new CustomValue(pair.Substring(0, pair.IndexOf(":")), pair.Substring(pair.IndexOf(":") + 1)));
                    else
                        valores.Add(new CustomValue(pair, pair));
                }

                return valores.ToArray();
            }
        }


        public Columna()
            : this("", true)
        { }

        public Columna(bool visible)
            : this("", visible)
        { }

        public Columna(string titulo)
            : this(titulo, true)
        { }

        public Columna(string titulo, bool visible)
        {
            Titulo = titulo;
            Visible = visible;
            Formato = "";
            ValoresFijos = "";
        }
    }
}
