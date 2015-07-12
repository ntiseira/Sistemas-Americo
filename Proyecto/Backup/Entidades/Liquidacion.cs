using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("Liquidacion")]
	public class Entity_Liquidacion
	{
		private long codigo;
		[Identificador(Autogenerado=true)]
		public long Codigo
		{
			get { return codigo;}
			set { codigo = value;}
		}

		private DateTime fechaliquidacion;
		public DateTime Fechaliquidacion
		{
			get { return fechaliquidacion;}
			set { fechaliquidacion = value;}
		}

		private DateTime fechaganancias;
		public DateTime Fechaganancias
		{
			get { return fechaganancias;}
			set { fechaganancias = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string tipoliquidacion;
		public string Tipoliquidacion
		{
			get { return tipoliquidacion;}
			set { tipoliquidacion = value;}
		}

		private string estado;
		public string Estado
		{
			get { return estado;}
			set { estado = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

