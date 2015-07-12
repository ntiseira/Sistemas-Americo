using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tabla")]
	public class Entity_tabla
	{
		private int idtabla;
		[Identificador(Autogenerado=true)]
		public int Idtabla
		{
			get { return idtabla;}
			set { idtabla = value;}
		}

		private string nombre;
		public string Nombre
		{
			get { return nombre;}
			set { nombre = value;}
		}

	}
}

