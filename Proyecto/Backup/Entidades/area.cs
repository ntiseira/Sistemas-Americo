using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("area")]
	public class Entity_area
	{
		private int idarea;
		[Identificador]
		[Columna("Código")]
		public int Idarea
		{
			get { return idarea;}
			set { idarea = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

