using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("CategoriaSueldos")]
	public class Entity_CategoriaSueldos
	{
		private long codigo;
		[Identificador(Autogenerado=true)]
		public long Codigo
		{
			get { return codigo;}
			set { codigo = value;}
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

		private float sueldobasico;
		public float Sueldobasico
		{
			get { return sueldobasico;}
			set { sueldobasico = value;}
		}

	}
}

