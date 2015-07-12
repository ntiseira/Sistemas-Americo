using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("descuentosfinancieros")]
	public class Entity_descuentosfinancieros
	{
		private int iddescuentosfinancieros;
		[Identificador(Autogenerado=true)]
		[Columna("C�digo")]
		public int Iddescuentosfinancieros
		{
			get { return iddescuentosfinancieros;}
			set { iddescuentosfinancieros = value;}
		}

		private string descripcion;
		[Columna("Descripci�n")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private bool descuento;
		// [Columna(Titulo="Opci�n",ValoresFijos="Descuento:1, Recargo:0")]
		public bool Descuento
		{
			get { return descuento;}
			set { descuento = value;}
		}

		private float porcentaje;
		public float Porcentaje
		{
			get { return porcentaje;}
			set { porcentaje = value;}
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

