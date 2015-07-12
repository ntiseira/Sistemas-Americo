using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipocheque")]
	public class Entity_tipocheque
	{
		private int idtipocheque;
		[Identificador(Autogenerado=true)]
		public int Idtipocheque
		{
			get { return idtipocheque;}
			set { idtipocheque = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

	}
}

