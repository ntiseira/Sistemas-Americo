using System;


namespace PhantomDb.Entidades
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field | 
        AttributeTargets.Parameter | AttributeTargets.ReturnValue
        , AllowMultiple = false)]
    public class Atributo : Attribute
    {
        string nombre;
        /// <summary>
        /// Nombre del atributo dentro de la tabla.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
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





        bool autogenerado;
        /// <summary>
        /// Indica si el campo es generado por el motor de base de datos al momento de
        /// dar de alta. Ejemplo: campo autonumérico.
        /// </summary>
        public bool Autogenerado
        {
            get { return autogenerado; }
            set { autogenerado = value; }
        }

        bool modificable;
        /// <summary>
        /// Indica si el campo puede ser modificado.
        /// </summary>
        public bool Modificable
        {
            get { return modificable; }
            set { modificable = value; }
        }

        Type tipo = null;
        /// <summary>
        /// Tipo de atributo dentro de la base de datos.
        /// </summary>
        public Type TipoPersonalizado
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public Atributo()
            : this("", false, true)
        {
        }

        public Atributo(string nombre)
            : this(nombre, false, true)
        {
        }

        public Atributo(string nombre, bool autogenerado)
            : this(nombre, autogenerado, true)
        {
        }

        public Atributo(string nombre, bool autogenerado, bool modificable)
            : this(nombre, autogenerado, modificable, null)
        {
        }
                
         public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado)
            : this(nombre, autogenerado, modificable, tipoPersonalizado,false)
        {
        }
         public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado, bool cuit)
             : this(nombre, autogenerado, modificable, tipoPersonalizado, cuit,false)
         {
         }

         public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado, bool cuit, bool importe)
             : this(nombre, autogenerado, modificable, tipoPersonalizado, cuit, importe, false)
         {
         }

         public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado, bool cuit, bool importe, bool numerico)
             : this(nombre, autogenerado, modificable, tipoPersonalizado, cuit, importe, numerico, false)
         {
         }

         public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado, bool cuit, bool importe, bool numerico, bool dni)
             : this(nombre, autogenerado, modificable, tipoPersonalizado, cuit, importe, numerico, dni, false)
         {
         }

         public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado, bool cuit, bool importe, bool numerico, bool dni, bool porcentaje)
             : this(nombre, autogenerado, modificable, tipoPersonalizado, cuit, importe, numerico, dni, porcentaje, false)
         {
         }

        public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado, bool cuit, bool importe, bool numerico, bool dni, bool porcentaje, bool mail)
            : base()
        {
            Nombre = nombre;
            Autogenerado = autogenerado;
            Modificable = modificable;
            TipoPersonalizado = tipoPersonalizado;
            this.EsCuit = cuit;
            this.EsDni = dni;
            this.EsImporte = importe;
            this.EsMail = mail;
            this.EsPorcentaje = porcentaje;
            this.EsNumerico = numerico;
      
        }
    
    



    }//clase
}//namespace
