using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipoasiento")]
	public class Entity_tipoasiento
	{
		private string descripcion;
		[Identificador]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

