using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("cambiomoneda")]
	public class Entity_cambiomoneda
	{
		private DateTime fechacambio;
		[Identificador]
		[Columna(Titulo="Fecha",Formato=Formato.DateType)]
		public DateTime Fechacambio
		{
			get { return fechacambio;}
			set { fechacambio = value;}
		}

		private float compra;
		public float Compra
		{
			get { return compra;}
			set { compra = value;}
		}

		private float venta;
		public float Venta
		{
			get { return venta;}
			set { venta = value;}
		}

		private int moneda_idmoneda;
		[Identificador]
		[Columna(false)]
		public int Moneda_idmoneda
		{
			get { return moneda_idmoneda;}
			set { moneda_idmoneda = value;}
		}

	}
}

