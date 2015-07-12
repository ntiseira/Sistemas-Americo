using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("empresa")]
	public class Entity_empresa
	{
		private long idempresa;
		[Identificador(Autogenerado=true)]
		public long Idempresa
		{
			get { return idempresa;}
			set { idempresa = value;}
		}

		private string razonsocial;
		public string Razonsocial
		{
			get { return razonsocial;}
			set { razonsocial = value;}
		}

		private long cuit;
		public long Cuit
		{
			get { return cuit;}
			set { cuit = value;}
		}

		private string mail;
		public string Mail
		{
			get { return mail;}
			set { mail = value;}
		}

		private int tiposocial;
		public int Tiposocial
		{
			get { return tiposocial;}
			set { tiposocial = value;}
		}

	}
}

