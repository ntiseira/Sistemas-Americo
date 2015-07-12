using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipoOperacion")]
	public class Entity_tipoOperacion
	{
		private int codtipooperacion;
		[Identificador]
		[Columna("Código")]
		public int Codtipooperacion
		{
			get { return codtipooperacion;}
			set { codtipooperacion = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private long empresa_idempresa;
		[Columna(Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

