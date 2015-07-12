using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("venta")]
	public class Entity_venta
	{
		private long codventa;
		[Identificador]
		public long Codventa
		{
			get { return codventa;}
			set { codventa = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
		}

		private float total;
		public float Total
		{
			get { return total;}
			set { total = value;}
		}

        //private long comprobanteventa_codcomprobanteventa;
        //[Identificador]
        //public long Comprobanteventa_codcomprobanteventa
        //{
        //    get { return comprobanteventa_codcomprobanteventa;}
        //    set { comprobanteventa_codcomprobanteventa = value;}
        //}

		

	}
}

