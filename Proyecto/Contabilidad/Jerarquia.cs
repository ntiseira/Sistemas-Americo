using System;

namespace Siscont.Contabilidad
{
    public class Jerarquia
    {
        int nivel;
        public int Nivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        int caracteres;
        public int Caracteres
        {
            get { return caracteres; }
            set { caracteres = value; }
        }

        public Jerarquia()
        {
        }
    }
}
