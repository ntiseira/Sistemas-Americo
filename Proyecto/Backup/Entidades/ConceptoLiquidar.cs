using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("ConceptoLiquidar")]
	public class Entity_ConceptoLiquidar
	{
		private int codigo;
		[Identificador(Autogenerado=true)]
		public int Codigo
		{
			get { return codigo;}
			set { codigo = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private float porcentaje;
		public float Porcentaje
		{
			get { return porcentaje;}
			set { porcentaje = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private int tipoconcepto_codigo;
		[Identificador]
		public int Tipoconcepto_codigo
		{
			get { return tipoconcepto_codigo;}
			set { tipoconcepto_codigo = value;}
		}

		private long liquidacion_codigo;
		[Identificador]
		public long Liquidacion_codigo
		{
			get { return liquidacion_codigo;}
			set { liquidacion_codigo = value;}
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

