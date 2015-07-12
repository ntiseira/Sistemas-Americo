using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("causasEmision")]
	public class Entity_causasEmision
	{
		private int codcausasemision;
		[Identificador(Autogenerado=true)]
       // [Columna("Código")]
		public int Codcausasemision
		{
			get { return codcausasemision;}
			set { codcausasemision = value;}
		}

		private string descripcion;
        //[Columna("Descripción")]
        public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private long empresa_idempresa;
        [Identificador(Autogenerado = false)]
    //    [Columna(Titulo="Empresa", Visible=true)]
        public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private string codigo;
    // [Columna("Causa")]
		public string Codigo
		{
			get { return codigo;}
			set { codigo = value;}
		}

	}
}

