using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("proveedoresdatosimposit")]
	public class Entity_proveedoresdatosimposit
	{
		private string situacioniva;
        [Columna(Titulo="Situación I.V.A.", ValoresFijos=Documento.SituacionIva)]
		public string Situacioniva
		{
			get { return situacioniva;}
			set { situacioniva = value;}
		}

		private string tipodocumento;
		[Columna(Titulo="Tipo de documento",ValoresFijos=Documento.Documentos)]
		public string Tipodocumento
		{
			get { return tipodocumento;}
			set { tipodocumento = value;}
		}

		private long numdocumento;
		[Columna("Número de documento")]
		public long Numdocumento
		{
			get { return numdocumento;}
			set { numdocumento = value;}
		}

		private string ganancias;
		[Columna(ValoresFijos = Documento.Ganancias)]
		public string Ganancias
		{
			get { return ganancias;}
			set { ganancias = value;}
		}

		private string tipoingresosbrutos;
		[Columna("Ingresos brutos")]
		public string Tipoingresosbrutos
		{
			get { return tipoingresosbrutos;}
			set { tipoingresosbrutos = value;}
		}

		private long numingresosbrutos;
		[Columna("Número ingresos brutos")]
		public long Numingresosbrutos
		{
			get { return numingresosbrutos;}
			set { numingresosbrutos = value;}
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

