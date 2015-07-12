using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhantomDb.Entidades
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class Heredar : Attribute
    {
        private Type padre;
        /// <summary>
        /// Clase padre.
        /// </summary>
        public Type Padre
        {
            get { return padre; }
            set { padre = value; }
        }

        public Heredar(Type padre)
        {
            Padre = padre;
        }
    }
}
