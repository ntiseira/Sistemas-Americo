using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("indice")]
	public class Entity_indice
	{
		private int idindice;
		[Identificador]
		[Columna("C�digo")]
		public int Idindice
		{
			get { return idindice;}
			set { idindice = value;}
		}

		private string descripcion;
		[Columna("Descripci�n")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(Visible =false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

