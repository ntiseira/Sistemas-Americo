using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("proveedoresotrosdatos")]
	public class Entity_proveedoresotrosdatos
	{
		private string contacto;
		public string Contacto
		{
			get { return contacto;}
			set { contacto = value;}
		}

		private string web;
		public string Web
		{
			get { return web;}
			set { web = value;}
		}

		private string nota;
		public string Nota
		{
			get { return nota;}
			set { nota = value;}
		}

		private int proveedor_idproveedor;
		[Identificador]
		[Columna(false)]
		public int Proveedor_idproveedor
		{
			get { return proveedor_idproveedor;}
			set { proveedor_idproveedor = value;}
		}

		private long proveedor_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Proveedor_empresa_idempresa
		{
			get { return proveedor_empresa_idempresa;}
			set { proveedor_empresa_idempresa = value;}
		}

	}
}

