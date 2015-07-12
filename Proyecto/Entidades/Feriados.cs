using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("Feriados")]
	public class Entity_Feriados
	{
		private long feriadoscol;
		[Identificador(Autogenerado=true)]
		public long Feriadoscol
		{
			get { return feriadoscol;}
			set { feriadoscol = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
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

