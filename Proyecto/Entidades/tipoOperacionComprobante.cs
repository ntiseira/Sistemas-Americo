using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipoOperacionComprobante")]
	public class Entity_tipoOperacionComprobante
	{
		private int idtipooperacioncomprobante;
		[Identificador]
		public int Idtipooperacioncomprobante
		{
			get { return idtipooperacioncomprobante;}
			set { idtipooperacioncomprobante = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
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

