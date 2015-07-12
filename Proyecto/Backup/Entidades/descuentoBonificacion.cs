using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("descuentoBonificacion")]
	public class Entity_descuentoBonificacion
	{
		private int codigodescuento;
		[Identificador(Autogenerado=true)]
		[Columna(Titulo="Código")]
		public int Codigodescuento
		{
			get { return codigodescuento;}
			set { codigodescuento = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private long desde;
		public long Desde
		{
			get { return desde;}
			set { desde = value;}
		}

		private long hasta;
		public long Hasta
		{
			get { return hasta;}
			set { hasta = value;}
		}

		private string descripciontipo;
		public string Descripciontipo
		{
			get { return descripciontipo;}
			set { descripciontipo = value;}
		}

		private string tipo;
		public string Tipo
		{
			get { return tipo;}
			set { tipo = value;}
		}

		private float porcentaje;
		public float Porcentaje
		{
			get { return porcentaje;}
			set { porcentaje = value;}
		}

		private long empresa_idempresa;
		[Atributo(Modificable=false)]
		[Columna(Titulo="Empresa",Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

