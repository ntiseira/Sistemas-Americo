using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("RegimenSiap")]
	public class Entity_RegimenSiap
	{
		private int codregimensiap;
		[Identificador(Autogenerado=true)]
        [Columna("C�digo")]
		public int Codregimensiap
		{
			get { return codregimensiap;}
			set { codregimensiap = value;}
		}

		private string descripcion;
		[Columna("Descripci�n")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private long empresa_idempresa;
		[Columna(false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private string codigo;
		public string Codigo
		{
			get { return codigo;}
			set { codigo = value;}
		}

	}
}

