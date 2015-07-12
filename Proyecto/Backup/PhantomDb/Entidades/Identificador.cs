using System;
using System.Collections.Generic;
using System.Text;

namespace PhantomDb.Entidades
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field |
        AttributeTargets.Parameter | AttributeTargets.ReturnValue
        , AllowMultiple = false)]
    public class Identificador : Atributo
    {
        public Identificador()
            : base()
        {

        }

        public Identificador(string nombre)
            : base(nombre)
        {
            Nombre = nombre;
        }
    }
}
