using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tipoproveedor")]
	public class Entity_tipoproveedor
	{
		private int idtipoproveedor;
		[Identificador(Autogenerado=true)]
		[Columna("Código")]
		public int Idtipoproveedor
		{
			get { return idtipoproveedor;}
			set { idtipoproveedor = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
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
		[Columna(Visible=false,Titulo="Empresa")]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

