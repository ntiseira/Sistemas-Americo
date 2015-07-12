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

        
        string maskRe;

        public string MaskRe
        {
            get { return maskRe; }
            set { maskRe = value; }
        }

        
        public Atributo(string nombre, bool autogenerado, bool modificable, Type tipoPersonalizado)
            : base()
        {
            Nombre = nombre;
            Autogenerado = autogenerado;
            Modificable = modificable;
            TipoPersonalizado = tipoPersonalizado;
        }
    
    



    }//clase
}//namespace
