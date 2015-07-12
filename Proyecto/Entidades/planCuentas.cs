using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("planCuentas")]
	public class Entity_planCuentas
	{
		private int codplancuentas;
		[Identificador]
		[Columna(Titulo="Código")]
		public int Codplancuentas
		{
			get { return codplancuentas;}
			set { codplancuentas = value;}
		}

		private string descripcion;
		[Columna(Titulo = "Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string mascara;
		[Columna(Titulo = "Máscara")]
		public string Mascara
		{
			get { return mascara;}
			set { mascara = value;}
		}

		private int ejercicio_codejercicio;
		[Identificador]
		[Columna(false)]
		public int Ejercicio_codejercicio
		{
			get { return ejercicio_codejercicio;}
			set { ejercicio_codejercicio = value;}
		}

		private long ejercicio_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Ejercicio_empresa_idempresa
		{
			get { return ejercicio_empresa_idempresa;}
			set { ejercicio_empresa_idempresa = value;}
		}

	}
}

