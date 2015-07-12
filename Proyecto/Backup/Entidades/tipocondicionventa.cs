using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipocondicionventa")]
	public class Entity_tipocondicionventa
	{
		private int idtipocondicionventa;
		[Identificador]
		[Columna("Código")]
		public int Idtipocondicionventa
		{
			get { return idtipocondicionventa;}
			set { idtipocondicionventa = value;}
		}

		private string descrip;
		[Columna("Descripción")]
		public string Descrip
		{
			get { return descrip;}
			set { descrip = value;}
		}

		private long empresa_idempresa;
		[Identificador(Modificable=false)]
		[Columna(false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

