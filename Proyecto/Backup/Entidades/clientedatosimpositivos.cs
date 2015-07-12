using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("clientedatosimpositivos")]
	public class Entity_clientedatosimpositivos
	{
		private int cliente_codcliente;
		[Identificador]
		[Columna(false)]
		public int Cliente_codcliente
		{
			get { return cliente_codcliente;}
			set { cliente_codcliente = value;}
		}

		private long cliente_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Cliente_empresa_idempresa
		{
			get { return cliente_empresa_idempresa;}
			set { cliente_empresa_idempresa = value;}
		}

		private string situacioniva;
        [Columna(Titulo = "Situación I.V.A.", ValoresFijos = Documento.SituacionIva)]
        public string Situacioniva
		{
			get { return situacioniva;}
			set { situacioniva = value;}
		}

		private string tipodocumento;
        [Columna(Titulo = "Tipo de documento", ValoresFijos = Documento.Documentos)]
        public string Tipodocumento
		{
			get { return tipodocumento;}
			set { tipodocumento = value;}
		}

		private long numdocumento;
		[Columna("Número de documento", mascara="[0-9]", Formato="[0-9]")]
		public long Numdocumento
		{
			get { return numdocumento;}
			set { numdocumento = value;}
		}

		private string ganancias;
		[Columna(ValoresFijos=Documento.Ganancias)]
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

	}
}

