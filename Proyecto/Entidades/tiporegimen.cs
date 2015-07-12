using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tiporegimen")]
	public class Entity_tiporegimen
	{
		private int idtiporegimen;
		[Identificador(Autogenerado=true)]
		public int Idtiporegimen
		{
			get { return idtiporegimen;}
			set { idtiporegimen = value;}
		}

		private string descrip;
		public string Descrip
		{
			get { return descrip;}
			set { descrip = value;}
		}

	}
}

