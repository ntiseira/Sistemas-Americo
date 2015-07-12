using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("causasemision")]
	public class Entity_causasEmision
	{
		private int codcausasemision;
		[Identificador(Autogenerado=true)]
       // [Columna("Código")]
		public int CodCausasEmision
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

		private long Empresa_idempresa;     
    //    [Columna(Titulo="Empresa", Visible=true)]
        public long empresa_idempresa
		{
            get { return Empresa_idempresa; }
            set { Empresa_idempresa = value; }
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

