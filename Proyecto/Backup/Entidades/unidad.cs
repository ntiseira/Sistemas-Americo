using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("unidad")]
	public class Entity_unidad
	{
		private int idunidad;
		[Identificador]
		[Columna("Código")]
		public int Idunidad
		{
			get { return idunidad;}
			set { idunidad = value;}
		}

		private float cotizacion;
		[Columna("Cotización")]
		public float Cotizacion
		{
			get { return cotizacion;}
			set { cotizacion = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private DateTime fechavigencia;
		public DateTime Fechavigencia
		{
			get { return fechavigencia;}
			set { fechavigencia = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

