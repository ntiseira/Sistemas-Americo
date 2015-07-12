using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("lineaVenta")]
	public class Entity_lineaVenta
	{
		private long codlineaventa;
		[Identificador]
		public long Codlineaventa
		{
			get { return codlineaventa;}
			set { codlineaventa = value;}
		}

        private int codConcepto;

        public int CodConcepto
        {
            get { return codConcepto; }
            set { codConcepto = value; }
        }

	

		private float importe;
		public float Importe
		{
			get { return importe;}
			set { importe = value;}
		}

		private int cantidad;
		public int Cantidad
		{
			get { return cantidad;}
			set { cantidad = value;}
		}

		private long venta_codventa;
		[Identificador]
		public long Venta_codventa
		{
			get { return venta_codventa;}
			set { venta_codventa = value;}
		}

	}
}

