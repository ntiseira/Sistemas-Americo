using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("Horarios")]
	public class Entity_Horarios
	{
		private long idhorarios;
		[Identificador(Autogenerado=true)]
		public long Idhorarios
		{
			get { return idhorarios;}
			set { idhorarios = value;}
		}

		private int horarioentrada;
		public int Horarioentrada
		{
			get { return horarioentrada;}
			set { horarioentrada = value;}
		}

		private int horariosalida;
		public int Horariosalida
		{
			get { return horariosalida;}
			set { horariosalida = value;}
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

