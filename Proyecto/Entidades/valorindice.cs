using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("valorindice")]
	public class Entity_valorindice
	{
		private string idvalorindice;
		[Identificador]
		[Columna("Código")]
		public string Idvalorindice
		{
			get { return idvalorindice;}
			set { idvalorindice = value;}
		}

		private float valor;
		public float Valor
		{
			get { return valor;}
			set { valor = value;}
		}

		private int indice_idindice;
		[Identificador]
		[Columna(false)]
		public int Indice_idindice
		{
			get { return indice_idindice;}
			set { indice_idindice = value;}
		}

		private long indice_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Indice_empresa_idempresa
		{
			get { return indice_empresa_idempresa;}
			set { indice_empresa_idempresa = value;}
		}

	}
}

