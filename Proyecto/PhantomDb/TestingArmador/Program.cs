using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace TestingArmador
{
    class Armame
    {
        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private long id;
        [Identificador]
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
