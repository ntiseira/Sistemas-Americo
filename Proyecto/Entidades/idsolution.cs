using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("idsolution")]
	public class Entity_idsolution
	{
		private int id;
		[Identificador(Autogenerado=true)]
		public int Id
		{
			get { return id;}
			set { id = value;}
		}

		private int idrelacion;
		[Atributo]
		public int Idrelacion
		{
			get { return idrelacion;}
			set { idrelacion = value;}
		}

		private string tabla;
		[Identificador]
		public string Tabla
		{
			get { return tabla;}
			set { tabla = value;}
		}

	}
}

