using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("descuentoscomerciales")]
	public class Entity_descuentoscomerciales
	{
		private int iddescuentoscomerciales;
		[Identificador(Autogenerado=true)]
        [Columna(Titulo="Código")]
		public int Iddescuentoscomerciales
		{
			get { return iddescuentoscomerciales;}
			set { iddescuentoscomerciales = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private long empresa_idempresa;
		[Columna(Titulo="Empresa",Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

