using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("anulacioncomprobante")]
	public class Entity_anulacioncomprobante
	{
		private int idanulacioncomprobante;
		[Identificador]
		public int Idanulacioncomprobante
		{
			get { return idanulacioncomprobante;}
			set { idanulacioncomprobante = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
		}

		private DateTime fechacontabilizacion;
		public DateTime Fechacontabilizacion
		{
			get { return fechacontabilizacion;}
			set { fechacontabilizacion = value;}
		}

		private DateTime fechadeclaracion;
		public DateTime Fechadeclaracion
		{
			get { return fechadeclaracion;}
			set { fechadeclaracion = value;}
		}

	}
}

