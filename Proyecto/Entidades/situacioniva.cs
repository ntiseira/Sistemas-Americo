using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("situacioniva")]
	public class Entity_situacioniva
	{
		private int idsituacioniva;
		[Identificador(Autogenerado=true)]
		public int Idsituacioniva
		{
			get { return idsituacioniva;}
			set { idsituacioniva = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

	}
}

