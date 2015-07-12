
namespace PhantomDb.Entidades
{
    public class CustomValue
    {
        string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        object valor;
        public object Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public CustomValue(string nombre)
            : this(nombre, null)
        {
        }

        public CustomValue(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
