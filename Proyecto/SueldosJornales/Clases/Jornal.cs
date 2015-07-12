using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SueldosJornales.Clases
{
    public class Jornal
    {

        private long codigo;

        public long Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private int cantDias;

        public int CantDias
        {
            get { return cantDias; }
            set { cantDias = value; }
        }
        private float montoDia;
        private float montoTotal;

        public float MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        public void calcularMontoTotal() 
        {
        }

        public Jornal() 
        {
        }
    }
}
