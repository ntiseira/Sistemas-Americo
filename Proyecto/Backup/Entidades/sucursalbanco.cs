using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("sucursalbanco")]
	public class Entity_sucursalbanco
	{
		private int idsucursalbanco;
		[Identificador]
		[Columna("Código")]
		public int Idsucursalbanco
		{
			get { return idsucursalbanco;}
			set { idsucursalbanco = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private int cuit;
		public int Cuit
		{
			get { return cuit;}
			set { cuit = value;}
		}

		private string tel;
		public string Tel
		{
			get { return tel;}
			set { tel = value;}
		}

		private string direccion;
		public string Direccion
		{
			get { return direccion;}
			set { direccion = value;}
		}

		private int banco_idbanco;
		[Identificador]
		[Columna(Visible = false)]
		public int Banco_idbanco
		{
			get { return banco_idbanco;}
			set { banco_idbanco = value;}
		}

		private long banco_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Banco_empresa_idempresa
		{
			get { return banco_empresa_idempresa;}
			set { banco_empresa_idempresa = value;}
		}

	}
}

