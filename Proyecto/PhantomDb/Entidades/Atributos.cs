using System;
using System.Reflection;
using PhantomDb.Armadores;

namespace PhantomDb.Entidades
{
    public class Atributos
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Nombre por el cuál se motrará el atributo.
        /// </summary>
        public string NombreDisplay
        {
            get { if (columna != null) { return columna.Titulo; } else { return Nombre; } }
        }



        #region PROPIEDADES PARA CONSTRUIR MASCARAS PARA CADA CAMPO EN EL STORER

        private bool esImporte;

        public bool EsImporte
        {
            get { return esImporte; }
            set { esImporte = value; }
        }

        private bool esMail;

        public bool EsMail
        {
            get { return esMail; }
            set { esMail = value; }
        }

        private bool esNumerico;

        public bool EsNumerico
        {
            get { return esNumerico; }
            set { esNumerico = value; }
        }

        private bool esDni;

        public bool EsDni
        {
            get { return esDni; }
            set { esDni = value; }
        }

        private bool esCuit;

        public bool EsCuit
        {
            get { return esCuit; }
            set { esCuit = value; }
        }

        private bool esPorcentaje;

        public bool EsPorcentaje
        {
            get { return esPorcentaje; }
            set { esPorcentaje = value; }
        }

        
            private bool esLetra;
             public bool EsLetra
        {
            get { return esLetra; }
            set { esLetra = value; }
        }

        #endregion










        private Columnas columna;
        public Columnas Columna
        {
            get { return columna; }
            set { columna = value; }
        }

        public Type Tipo
        {
            get
            {
                return Property.PropertyType;
            }
        }
        
        private string atributo = "";
        public string Atributo
        {
            get { return atributo; }
            set { atributo = value; }
        }

        public string Param
        {
            get { return "@" + Nombre; }
        }

        private object valor;
        /// <summary>
        /// Escribe un valor en el atributo y en el correspondiente objeto.
        /// </summary>
        public object Valor
        {
            get { return valor; }
            set 
            { 
                if (Instancia != null && Property != null && Property.CanWrite)
                {
                    Type tttt = Property.PropertyType;
                    if (tttt.Equals(typeof(DateTime)))
                    {
                        valor = DateTime.Parse(value.ToString());
                    }
                    else if(tttt.Equals(typeof(string)))
                    {
                        if (value == null)
                            valor = "";
                        else
                            valor = value;
                    }
                    else
                    {
                        valor = value;
                    }

                    Property.SetValue(Instancia, valor, null);
                }
                else
                {
                    valor = value;
                }
            }
        }

        private bool soloLectura;
        /// <summary>
        /// Indica si el valor se usa solo para leer.
        /// </summary>
        public bool SoloLectura
        {
            get { return soloLectura; }
            set { soloLectura = value; }
        }

        private bool autogenerado;
        /// <summary>
        /// Indica si el campo es autonumérico.
        /// </summary>
        public bool Autogenerado
        {
            get { return autogenerado; }
            set { autogenerado = value; }
        }

        PropertyInfo property;
        public PropertyInfo Property
        {
            get { return property; }
            set { property = value; }
        }

        Relacionado relacion = null;
        public Relacionado Relacion
        {
            get { return relacion; }
            set { relacion = value; if (relacion != null) relacion.Atributo = this; }
        }

        object instancia;
        public object Instancia
        {
            get { return instancia; }
            set 
            {
                instancia = value;
            }
        }

        public Atributos(string nombre)
            : this(nombre, null)
        {
        }

        public Atributos(string nombre, object valor)
            : this(nombre, valor, null)
        {
         }

        public Atributos(string nombre, object valor, PropertyInfo p, object instancia)
            : this(nombre, valor, p, instancia, false)
        {
        }

        public Atributos(string nombre, object valor, PropertyInfo p, object instancia, bool cuit)
            : this(nombre, valor, p, instancia, cuit, false)
        {
        }

        public Atributos(string nombre, object valor, PropertyInfo p, object instancia, bool cuit, bool numerico)
            : this(nombre, valor, p, instancia, cuit, numerico, false, false)
        {
        }

        public Atributos(string nombre, object valor, PropertyInfo p, object instancia, bool cuit, bool numerico, bool dni)
            : this(nombre, valor, p, instancia, cuit, numerico, dni, false)
        {
        }

        public Atributos(string nombre, object valor, PropertyInfo p, object instancia, bool cuit, bool numerico, bool dni, bool importe)
            : this(nombre, valor, p, instancia, cuit, numerico, dni, importe,cuit)
        {
        }

        public Atributos(string nombre, object valor, PropertyInfo p, object instancia, bool cuit, bool numerico, bool dni, bool importe, bool mail)
            : this(nombre, valor, p, instancia,false,false,cuit,numerico,dni,importe, mail,false, false)
        {
        }
        public Atributos(string nombre, object valor, PropertyInfo p, object instancia, bool cuit, bool numerico, bool dni, bool importe, bool mail, bool porcentaje)
            : this(nombre, valor, p, instancia, false, false, cuit, numerico, dni, importe, mail, porcentaje, false)
        {
        }

        /*
        public Atributos(string nombre, object valor, PropertyInfo p, object instancia, bool cuit, bool numerico, bool dni, bool importe, bool mail, bool porcentaje)
            : this(nombre, valor, p, instancia, cuit, numerico, dni, importe, mail, porcentaje)
        {
        }
        */
        public Atributos(string nombre, object valor, PropertyInfo p, 
            object instancia, bool soloLectura, bool autogenerado, bool cuit, bool numerico
            ,bool dni, bool importe, bool mail, bool porcentaje, bool letra)
        {
            Atributo = nombre;
            SoloLectura = soloLectura;
            Nombre = nombre;
            Valor = valor;
            Property = p;
            Instancia = instancia;
            Columna = new Columnas(Nombre, true);
            Autogenerado = autogenerado;
            EsCuit = esCuit;
            EsDni = dni;
            EsImporte = importe;
            EsMail = mail;
            EsPorcentaje = porcentaje;
            EsNumerico = numerico;
            EsLetra = letra;
        }

        public Atributos(string nombre, object valor, PropertyInfo p)
            : this(nombre, valor, p, null)
        {
        }


        /// <summary>
        /// Copia el valor dentro de la instancia asociada.
        /// </summary>
        public void EscribirEnInstancia()
        {
            if (Instancia != null && Property != null && Property.CanWrite)
            {
                try
                {
                    Property.SetValue(Instancia, valor, null);
                }
                catch
                {
                    Property.SetValue(Instancia, FromString.GetFromString(Property.PropertyType, valor.ToString()), null);
                }
            }
        }

        /// <summary>
        /// Lee los valores de los atributos de la instancia.
        /// </summary>
        public void LeerDeInstancia()
        {
            if (Instancia != null && Property != null)
            {
                this.valor = Property.GetValue(Instancia, null);
            }
        }

        public bool Es(string s)
        {
            return s.ToLower().Equals(Nombre.ToLower());
        }

        public override string ToString()
        {
            return Tipo.Name + " " + Nombre + "=" + Valor.ToString();
        }

        internal Atributos Clone()
        {
            return new Atributos(Nombre, Valor, Property, null, SoloLectura, Autogenerado);
        }
    }
}
