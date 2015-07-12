using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tiposocial")]
	public class Entity_tiposocial
	{
		private int codtipo;
		[Identificador]
		public int Codtipo
		{
			get { return codtipo;}
			set { codtipo = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

	}
}

