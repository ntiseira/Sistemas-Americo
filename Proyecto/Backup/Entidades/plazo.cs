using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("plazo")]
	public class Entity_plazo
	{
		private int codplazo;
		[Identificador]
		public int Codplazo
		{
			get { return codplazo;}
			set { codplazo = value;}
		}

		private double porcentaje;
		public double Porcentaje
		{
			get { return porcentaje;}
			set { porcentaje = value;}
		}

		private int dias;
		public int Dias
		{
			get { return dias;}
			set { dias = value;}
		}

	}
}

