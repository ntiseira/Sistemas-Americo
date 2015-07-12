using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("actividadesdgr")]
	public class Entity_actividadesdgr
	{
		private int codact;
		[Identificador]
		public int Codact
		{
			get { return codact;}
			set { codact = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

	}
}

