
using PhantomDb.Entidades;
namespace PhantomDb.Armadores
{
    public class Columnas
    {
        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        bool visible;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        Formato formato;
        public Formato Formato
        {
            get { return formato; }
            set { formato = value; }
        }        
        
        private CustomValue[] valoresFijos;
        public CustomValue[] Valores
        {
            get { return valoresFijos; }
            set { valoresFijos = value; }
        }

        public bool ValoresFijos
        {
            get { return valoresFijos != null; }
        }

        public Columnas(string titulo, bool visible)
        {
            Titulo = titulo;
            Visible = visible;
            Formato = Formato.Empty;
            Valores = null;
        }
    }
}
