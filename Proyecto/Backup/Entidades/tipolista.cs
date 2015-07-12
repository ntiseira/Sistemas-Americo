using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipolista")]
	public class Entity_tipolista
	{
		private int idtipolista;
		[Identificador(Autogenerado=true)]
		public int Idtipolista
		{
			get { return idtipolista;}
			set { idtipolista = value;}
		}

		private string descrip;
		public string Descrip
		{
			get { return descrip;}
			set { descrip = value;}
		}

	}
}

