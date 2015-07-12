using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipoOperacion")]
	public class Entity_tipoOperacion
	{
		private int codtipooperacion;
		[Identificador]
		[Columna("C�digo")]
		public int Codtipooperacion
		{
			get { return codtipooperacion;}
			set { codtipooperacion = value;}
		}

		private string descripcion;
		[Columna("Descripci�n")]
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

