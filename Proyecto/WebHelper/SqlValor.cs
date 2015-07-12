
namespace WebHelper
{
    public class SqlValor
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

        public SqlValor(string nombre)
            : this(nombre, null)
        {
        }

        public SqlValor(string nombre, object valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
