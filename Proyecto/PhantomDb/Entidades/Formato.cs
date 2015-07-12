
namespace PhantomDb.Entidades
{
    public class Formato
    {
        public const string DateType = "date";
        public const string DateTimeType = "datetime";
        public const string TimeType = "time";

        private string tipo;
        public string Tipo
        {
          get { return tipo; }
          set { tipo = value; }
        }

        private string valor;
        public string Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        private Formato()
        {
            Tipo = "empty";
            Valor = "";
        }

        internal static Formato Empty { get { return new Formato(); }}
        internal static Formato DateTime { get { return new Formato { Tipo = DateTimeType, Valor = "dd/MM/yyyy HH:mm:ss" }; } }
        internal static Formato Date { get { return new Formato { Tipo = DateType, Valor = "dd/MM/yyyy" }; } }
        internal static Formato Time { get { return new Formato { Tipo = TimeType, Valor = "HH:mm:ss" }; } }

        public static Formato GetFormat(string name)
        {
            switch (name.ToLower())
            {
                case DateTimeType:
                    return DateTime;

                case DateType:
                    return Date;

                case TimeType:
                    return Time;

                default:
                    return Empty;
            }
        }
    }
}
