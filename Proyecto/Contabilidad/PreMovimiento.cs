using System;

namespace Siscont.Contabilidad
{
    public class PreMovimiento : LineaLibroDiario
    {
        private int cod;
        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        private string tipo;
        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
