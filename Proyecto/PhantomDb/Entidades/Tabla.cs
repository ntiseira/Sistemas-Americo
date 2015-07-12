using System;

namespace PhantomDb.Entidades
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=false)]
    public class Tabla : Attribute
    {
        string nombre;
        /// <summary>
        /// Nombre de la tabla.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public Tabla()
            : base()
        {
            Nombre = "";
        }

        public Tabla(string nombre) 
            : base()
        {
            Nombre = nombre;
        }
    }
}
