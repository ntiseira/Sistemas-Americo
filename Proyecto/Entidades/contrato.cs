using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("contrato")]
	public class Entity_contrato
	{
		private int codcontrato;
		[Identificador]
		public int Codcontrato
		{
			get { return codcontrato;}
			set { codcontrato = value;}
		}

		private int nroinscripcion;
		public int Nroinscripcion
		{
			get { return nroinscripcion;}
			set { nroinscripcion = value;}
		}

		private string tipoinstrumento;
		public string Tipoinstrumento
		{
			get { return tipoinstrumento;}
			set { tipoinstrumento = value;}
		}

		private DateTime fechafirma;
		public DateTime Fechafirma
		{
			get { return fechafirma;}
			set { fechafirma = value;}
		}

		private int folio;
		public int Folio
		{
			get { return folio;}
			set { folio = value;}
		}

		private int tomo;
		public int Tomo
		{
			get { return tomo;}
			set { tomo = value;}
		}

		private string jurisdiccion;
		public string Jurisdiccion
		{
			get { return jurisdiccion;}
			set { jurisdiccion = value;}
		}

		private string organismo;
		public string Organismo
		{
			get { return organismo;}
			set { organismo = value;}
		}

		private long matricula;
		public long Matricula
		{
			get { return matricula;}
			set { matricula = value;}
		}

		private long legajo;
		public long Legajo
		{
			get { return legajo;}
			set { legajo = value;}
		}

		private int plazobalance;
		public int Plazobalance
		{
			get { return plazobalance;}
			set { plazobalance = value;}
		}

		private string frecuencia;
		public string Frecuencia
		{
			get { return frecuencia;}
			set { frecuencia = value;}
		}

		private string firma;
		public string Firma
		{
			get { return firma;}
			set { firma = value;}
		}

		private long empresa_idempresa;
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

