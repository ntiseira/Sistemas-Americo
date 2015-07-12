using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("movimiento")]
	public class Entity_movimiento
	{
		private int idmovimiento;
		[Identificador]
		[Columna("Código")]
		public int Idmovimiento
		{
			get { return idmovimiento;}
			set { idmovimiento = value;}
		}

		private bool debehaber;
		[Columna("Debe (si)/Haber (no)")]
		public bool Debehaber
		{
			get { return debehaber;}
			set { debehaber = value;}
		}

		private string leyenda;
		public string Leyenda
		{
			get { return leyenda;}
			set { leyenda = value;}
		}

		private float monto;
		public float Monto
		{
			get { return monto;}
			set { monto = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string tipomovimiento_descripcion;
		[Columna("Tipo")]
		public string Tipomovimiento_descripcion
		{
			get { return tipomovimiento_descripcion;}
			set { tipomovimiento_descripcion = value;}
		}

		private long tipomovimiento_empresa_idempresa;
		[Columna(false)]
		public long Tipomovimiento_empresa_idempresa
		{
			get { return tipomovimiento_empresa_idempresa;}
			set { tipomovimiento_empresa_idempresa = value;}
		}

		private int asiento_idasiento;
		[Identificador(Modificable=false)]
		[Columna(Titulo="Asiento")]
		public int Asiento_idasiento
		{
			get { return asiento_idasiento;}
			set { asiento_idasiento = value;}
		}

		private int asiento_ejercicio_codejercicio;
		[Identificador]
		[Columna(false)]
		public int Asiento_ejercicio_codejercicio
		{
			get { return asiento_ejercicio_codejercicio;}
			set { asiento_ejercicio_codejercicio = value;}
		}

		private long asiento_ejercicio_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Asiento_ejercicio_empresa_idempresa
		{
			get { return asiento_ejercicio_empresa_idempresa;}
			set { asiento_ejercicio_empresa_idempresa = value;}
		}

		private string cuenta_idcuenta;
		[Columna("Cuenta")]
		[Relacion(Destino = typeof(Entity_cuenta), CampoId = 0, CampoSecundario = 0)]
		public string Cuenta_idcuenta
		{
			get { return cuenta_idcuenta;}
			set { cuenta_idcuenta = value;}
		}

		private int cuenta_plancuentas_codplancuentas;
		[Columna(Titulo="Plan de cuentas", Visible=false)]
		public int Cuenta_plancuentas_codplancuentas
		{
			get { return cuenta_plancuentas_codplancuentas;}
			set { cuenta_plancuentas_codplancuentas = value;}
		}

		private int cuenta_plancuentas_ejercicio_codejercicio;
		[Columna(false)]
		public int Cuenta_plancuentas_ejercicio_codejercicio
		{
			get { return cuenta_plancuentas_ejercicio_codejercicio;}
			set { cuenta_plancuentas_ejercicio_codejercicio = value;}
		}

		private long cuenta_plancuentas_ejercicio_empresa_idempresa;
		[Columna(false)]
		public long Cuenta_plancuentas_ejercicio_empresa_idempresa
		{
			get { return cuenta_plancuentas_ejercicio_empresa_idempresa;}
			set { cuenta_plancuentas_ejercicio_empresa_idempresa = value;}
		}

	}
}

