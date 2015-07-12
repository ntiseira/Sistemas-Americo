using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("moneda")]
	public class Entity_moneda
	{
		private int idmoneda;
		[Identificador(Autogenerado=true)]
		[Columna("Código")]
		public int Idmoneda
		{
			get { return idmoneda;}
			set { idmoneda = value;}
		}

		private string moneda;
		public string Moneda
		{
			get { return moneda;}
			set { moneda = value;}
		}

		private string simbolo;
		public string Simbolo
		{
			get { return simbolo;}
			set { simbolo = value;}
		}

	}
}

