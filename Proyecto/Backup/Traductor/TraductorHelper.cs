using System.Globalization;

namespace Traductor
{
    public class TraductorHelper
    {
        private static CultureInfo culture = CultureInfo.CurrentCulture;
        public static CultureInfo Culture
        {
            get 
            { 
                if(culture == null)
                {
                    culture = CultureInfo.CurrentCulture;
                }
                return culture; 
            }
        }

        public static string GetCode(string language)
        {
            switch (language)
            {
                case "":
                    return CultureInfo.CurrentCulture.Name;

                case "English":
                    return "en-US";

                default:
                    return "es-AR";
            }
        }

        public static void SetCulture(string code)
        {
            culture = new CultureInfo(code);
        }

        /// <summary>
        /// Obtiene el separador de decimales.
        /// </summary>
        /// <returns></returns>
        public static string GetSeparador()
        {
            var str = string.Format("{0:n}", 0.0);
            while (str.Contains("0"))
            {
                str = str.Replace("0", "");
            }
            return str;
        }
    }
}
