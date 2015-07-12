using System;
using System.Text;

namespace Siscont.Contabilidad
{
    public class LineaLibroDiario
    {
        string cuenta;
        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

        string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        string debe;
        public string Debe
        {
            get { return debe; }
            set { debe = value; }
        }

        string haber;
        public string Haber
        {
            get { return haber; }
            set { haber = value; }
        }

        string leyenda;
        public string Leyenda
        {
            get { return leyenda; }
            set { leyenda = value; }
        }
    }
}
