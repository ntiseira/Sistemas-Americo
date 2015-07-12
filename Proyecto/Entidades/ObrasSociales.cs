using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("ObrasSociales")]
	public class Entity_ObrasSociales
	{
		private long codigo;
		[Identificador]
		public long Codigo
		{
			get { return codigo;}
			set { codigo = value;}
		}

		private int tiposobrassociales_codigo;
		[Identificador]
		public int Tiposobrassociales_codigo
		{
			get { return tiposobrassociales_codigo;}
			set { tiposobrassociales_codigo = value;}
		}

		private long tiposobrassociales_empresa_idempresa;
		[Identificador]
		public long Tiposobrassociales_empresa_idempresa
		{
			get { return tiposobrassociales_empresa_idempresa;}
			set { tiposobrassociales_empresa_idempresa = value;}
		}

		private int empleados_legajo;
		[Identificador]
		public int Empleados_legajo
		{
			get { return empleados_legajo;}
			set { empleados_legajo = value;}
		}

	}
}

