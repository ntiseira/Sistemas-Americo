using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("ecommerce")]
	public class Entity_ecommerce
	{
		private int idecommerce;
		[Identificador]
		public int Idecommerce
		{
			get { return idecommerce;}
			set { idecommerce = value;}
		}

		private string url;
		public string Url
		{
			get { return url;}
			set { url = value;}
		}

		private string clave;
		public string Clave
		{
			get { return clave;}
			set { clave = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private int cliente_codcliente;
		[Identificador]
		public int Cliente_codcliente
		{
			get { return cliente_codcliente;}
			set { cliente_codcliente = value;}
		}

		private long cliente_empresa_idempresa;
		[Identificador]
		public long Cliente_empresa_idempresa
		{
			get { return cliente_empresa_idempresa;}
			set { cliente_empresa_idempresa = value;}
		}

	}
}

