
namespace AdministradorGeneral.Parsers
{
    public class Tag
    {
        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        string contenido;
        public string Contenido
        {
            get { return contenido; }
            set { contenido = value; }
        }

        public string Start
        {
            get { return string.Format("<{0} {1}>", Nombre, Contenido); }
        }

        public string End
        {
            get { return string.Format("</{0}>", Nombre); }
        }

        public override string ToString()
        {
            return Start+End;
        }
    }
}
