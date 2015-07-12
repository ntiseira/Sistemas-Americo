
namespace ModuloSoporte.Security
{
    public class SQLInjection
    {
        static readonly string[] sentences = 
        {
            "insert", "select", "update", "drop", "delete",
            "xp_"
        };

        public static void AplicarSeguridad(ref string s)
        {
            s = s.Replace("'", "`");
            s = s.Replace("\"", "`");
            s = s.Replace("/*", "/+");
            s = s.Replace("*/", "+/");
        }

        public static bool IsSqlSentence(string text)
        {
            foreach (string s in SQLInjection.sentences)
            {
                int i = text.ToLower().IndexOf(s);
                while (i > 0)
                {
                    switch (text[--i])
                    {
                        // Si es un separador, entonces es una sentencia
                        case ';':
                            return true;

                        // Si es un separador, intriga...
                        case '\r':
                        case '\n':
                        case '\t':
                        case ' ':
                            break;

                        // Si es un caracter, entonces no.
                        default:
                            i = 0;
                            break;
                    }
                }
            }

            return false;
        }
    }
}
