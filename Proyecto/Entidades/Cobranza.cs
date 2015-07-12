using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("Cobranza")]
	public class Entity_Cobranza
	{
		private int cod_cobranza;
		[Identificador(Autogenerado=true)]
		public int Cod_cobranza
		{
			get { return cod_cobranza;}
			set { cod_cobranza = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
		}

		private double importeneto;
		public double Importeneto
		{
			get { return importeneto;}
			set { importeneto = value;}
		}

		private double importebruto;
		public double Importebruto
		{
			get { return importebruto;}
			set { importebruto = value;}
		}

		private int tipocomprobante_codcomprobante;
		public int Tipocomprobante_codcomprobante
		{
			get { return tipocomprobante_codcomprobante;}
			set { tipocomprobante_codcomprobante = value;}
		}

		private long nrorecibo;
		public long Nrorecibo
		{
			get { return nrorecibo;}
			set { nrorecibo = value;}
		}

	}
}

