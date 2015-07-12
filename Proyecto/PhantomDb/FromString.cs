using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhantomDb
{
    public static class FromString
    {
        public static object GetFromString(Type t, string value, bool exception)
        {
            var retorno = GetFromString(t, value);

            if (exception)
            {
                if (t != typeof(string) && retorno.GetType() == typeof(string))
                {
                    throw new Exception("El valor no pudo ser convertido.");
                }
                else
                {
                    return retorno;
                }
            }
            else
            {
                return retorno;
            }
        }
        public static object GetFromString(Type t, string value)
        {
            switch (t.Name.ToString().ToLower())
            {
                case "bool":
                case "boolean":
                    {
                        if (value.Length != 1)
                            return Boolean.Parse(value);
                        else
                            return value.Equals("1");
                    }
                case "byte":
                    return Byte.Parse(value);
                case "char":
                    return Char.Parse(value);
                case "datetime":
                    return DateTime.Parse(value);
                case "short":
                case "int16":
                    return Int16.Parse(value);
                case "int":
                case "int32":
                    return Int32.Parse(value);
                case "long":
                case "int64":
                    return Int64.Parse(value);
                case "uint16":
                    return UInt16.Parse(value);
                case "uint32":
                    return UInt32.Parse(value);
                case "uint64":
                    return UInt64.Parse(value);
                default:
                    return value;
            }
        }
    }
}
