using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("conceptonoiva")]
	public class Entity_conceptonoiva
	{
		private int idconceptonoiva;
		[Identificador]
		[Columna("Código")]
		public int Idconceptonoiva
		{
			get { return idconceptonoiva;}
			set { idconceptonoiva = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
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

		private short calculo;
		[Columna(Titulo="Modo de cálculo", ValoresFijos="Sobre precio de costo:0,Sobre precio de venta:1,Monto fijo por unidad:2")]
		public short Calculo
		{
			get { return calculo;}
			set { calculo = value;}
		}

		private short sobre;
		[Columna(Titulo = "Aplicado sobre", ValoresFijos = "Neto gravado:0,Neto gravado y no gravado:1")]
		public short Sobre
		{
			get { return sobre;}
			set { sobre = value;}
		}

		private float tasaneto;
		[Columna("Tasa (sobre neto)")]
		public float Tasaneto
		{
			get { return tasaneto;}
			set { tasaneto = value;}
		}

		private float tasatotal;
		[Columna("Tasa (sobre total)")]
		public float Tasatotal
		{
			get { return tasatotal;}
			set { tasatotal = value;}
		}

		private float montofijoporunidad;
		public float Montofijoporunidad
		{
			get { return montofijoporunidad;}
			set { montofijoporunidad = value;}
		}

		private bool costo;
		public bool Costo
		{
			get { return costo;}
			set { costo = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

