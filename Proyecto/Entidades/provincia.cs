using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("provincia")]
	public class Entity_provincia
	{
        private int id;
		[Identificador]
        public int Id
		{
            get { return id; }
            set { id = value; }
		}

        private string nombre;
        public string Nombre
		{
            get { return nombre; }
            set { nombre = value; }
		}

        private string cpa;
        public string Cpa
		{
            get { return cpa; }
            set { cpa = value; }
		}

	}
}

