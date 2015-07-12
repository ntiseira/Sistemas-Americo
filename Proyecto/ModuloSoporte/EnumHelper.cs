using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#warning Probar EnumToString en caso de utilizarlo.

namespace ModuloSoporte
{
    public static class EnumHelper
    {
        public static string EnumToString(Enum e)
        {
            return e.ToString().Replace("_", " ");
        }
    }
}
