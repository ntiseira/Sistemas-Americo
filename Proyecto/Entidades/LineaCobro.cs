using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("LineaCobro")]
	public class Entity_LineaCobro
	{
		private int cod_cobro;
		[Identificador(Autogenerado=true)]
		public int Cod_cobro
		{
			get { return cod_cobro;}
			set { cod_cobro = value;}
		}

		private int cobranza_cod_cobranza;
		public int Cobranza_cod_cobranza
		{
			get { return cobranza_cod_cobranza;}
			set { cobranza_cod_cobranza = value;}
		}

	}
}

