using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("departamento")]
	public class Entity_departamento
	{
		private int iddepartamento;
		[Identificador]
		public int Iddepartamento
		{
			get { return iddepartamento;}
			set { iddepartamento = value;}
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
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

