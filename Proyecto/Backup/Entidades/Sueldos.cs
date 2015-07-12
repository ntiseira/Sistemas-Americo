using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("Sueldos")]
	public class Entity_Sueldos
	{
		private long codigo;
		[Identificador(Autogenerado=true)]
		public long Codigo
		{
			get { return codigo;}
			set { codigo = value;}
		}

		private long categoriasueldos_codigo;
		[Identificador]
		public long Categoriasueldos_codigo
		{
			get { return categoriasueldos_codigo;}
			set { categoriasueldos_codigo = value;}
		}

		private long liquidacion_codigo;
		[Identificador]
		public long Liquidacion_codigo
		{
			get { return liquidacion_codigo;}
			set { liquidacion_codigo = value;}
		}

		private int empleados_legajo;
		[Identificador]
		public int Empleados_legajo
		{
			get { return empleados_legajo;}
			set { empleados_legajo = value;}
		}

		private int empleados_sucursal_codigosucursal;
		[Identificador]
		public int Empleados_sucursal_codigosucursal
		{
			get { return empleados_sucursal_codigosucursal;}
			set { empleados_sucursal_codigosucursal = value;}
		}

		private long empleados_sucursal_empresa_idempresa;
		[Identificador]
		public long Empleados_sucursal_empresa_idempresa
		{
			get { return empleados_sucursal_empresa_idempresa;}
			set { empleados_sucursal_empresa_idempresa = value;}
		}

	}
}

