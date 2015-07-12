using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipocliente")]
	public class Entity_tipocliente
	{
		private int idtipocliente;
		[Identificador(Autogenerado=true)]
		[Columna("Código")]
		public int Idtipocliente
		{
			get { return idtipocliente;}
			set { idtipocliente = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
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

