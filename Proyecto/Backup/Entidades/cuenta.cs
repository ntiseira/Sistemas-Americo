using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("cuenta")]
	public class Entity_cuenta
	{
		private string idcuenta;
		[Identificador]
		[Columna("Código")]
		public string Idcuenta
		{
			get { return idcuenta;}
			set { idcuenta = value;}
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

		private int columnaimpresion;
		[Columna("Columna de impresión")]
		public int Columnaimpresion
		{
			get { return columnaimpresion;}
			set { columnaimpresion = value;}
		}

		private string capitulo;
		[Columna("Capítulo")]
		public string Capitulo
		{
			get { return capitulo;}
			set { capitulo = value;}
		}

		private bool imputable;
		public bool Imputable
		{
			get { return imputable;}
			set { imputable = value;}
		}

		private string tipocuenta_descripcion;
		[Columna("Tipo de cuenta")]
		[Relacion(Destino = typeof(Entity_tipocuenta), CampoId = 0, CampoSecundario = 0)]
		public string Tipocuenta_descripcion
		{
			get { return tipocuenta_descripcion;}
			set { tipocuenta_descripcion = value;}
		}

		private int unidad_idunidad;
		[Columna("Unidad")]
		[Relacion(Destino = typeof(Entity_unidad), CampoId = 0, CampoSecundario = 2)]
		public int Unidad_idunidad
		{
			get { return unidad_idunidad;}
			set { unidad_idunidad = value;}
		}

		private int plancuentas_codplancuentas;
		[Identificador]
		[Columna(Titulo="Plan de cuentas", Visible=false)]
		public int Plancuentas_codplancuentas
		{
			get { return plancuentas_codplancuentas;}
			set { plancuentas_codplancuentas = value;}
		}

		private int plancuentas_ejercicio_codejercicio;
		[Identificador]
		[Columna(false)]
		public int Plancuentas_ejercicio_codejercicio
		{
			get { return plancuentas_ejercicio_codejercicio;}
			set { plancuentas_ejercicio_codejercicio = value;}
		}

		private long plancuentas_ejercicio_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Plancuentas_ejercicio_empresa_idempresa
		{
			get { return plancuentas_ejercicio_empresa_idempresa;}
			set { plancuentas_ejercicio_empresa_idempresa = value;}
		}

	}
}

