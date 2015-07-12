using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("lineadescuento")]
	public class Entity_lineadescuento
	{
		private int idlineadescuento;
		[Identificador(Autogenerado=true)]
        [Columna(Titulo="Código")]
		public int Idlineadescuento
		{
			get { return idlineadescuento;}
			set { idlineadescuento = value;}
		}

		private int descuentoscomerciales_iddescuentoscomerciales;
		[Identificador]
        [Columna(Titulo = "Código Descuento Comercial",Visible=false)]
		public int Descuentoscomerciales_iddescuentoscomerciales
		{
			get { return descuentoscomerciales_iddescuentoscomerciales;}
			set { descuentoscomerciales_iddescuentoscomerciales = value;}
		}

		private long descuentoscomerciales_empresa_idempresa;
		[Identificador]
        [Columna(Titulo = "Empresa",Visible=false)]
		public long Descuentoscomerciales_empresa_idempresa
		{
			get { return descuentoscomerciales_empresa_idempresa;}
			set { descuentoscomerciales_empresa_idempresa = value;}
		}

		private float porcentaje;
        [Atributo(EsPorcentaje = true)]
		public float Porcentaje
		{
			get { return porcentaje;}
			set { porcentaje = value;}
		}

		private bool recargo;
        [Columna(Titulo = "¿Es recargo?")]
		public bool Recargo
		{
			get { return recargo;}
			set { recargo = value;}
		}

	}
}

