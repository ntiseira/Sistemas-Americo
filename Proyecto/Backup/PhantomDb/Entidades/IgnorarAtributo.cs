using System;
using System.Collections.Generic;
using System.Text;

namespace PhantomDb.Entidades
{
    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field |
        AttributeTargets.Parameter | AttributeTargets.ReturnValue
        , AllowMultiple = false)]
    public class IgnorarAtributo : Atributo
    {
        public IgnorarAtributo()
            : base()
        {

        }
    }
}
