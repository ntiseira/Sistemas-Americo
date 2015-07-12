using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("jerarquia")]
	public class Entity_jerarquia
	{
		private int idjerarquia;
		[Identificador]
		[Columna("Nivel")]
		public int Idjerarquia
		{
			get { return idjerarquia;}
			set { idjerarquia = value;}
		}

		private int caracteres;
		public int Caracteres
		{
			get { return caracteres;}
			set { caracteres = value;}
		}

		private int plancuentas_codplancuentas;
		[Identificador]
		[Columna(Visible=false)]
		public int Plancuentas_codplancuentas
		{
			get { return plancuentas_codplancuentas;}
			set { plancuentas_codplancuentas = value;}
		}

		private int plancuentas_ejercicio_codejercicio;
		[Identificador]
		[Columna(Visible = false)]
		public int Plancuentas_ejercicio_codejercicio
		{
			get { return plancuentas_ejercicio_codejercicio;}
			set { plancuentas_ejercicio_codejercicio = value;}
		}

		private long plancuentas_ejercicio_empresa_idempresa;
		[Identificador]
		[Columna(Visible = false)]
		public long Plancuentas_ejercicio_empresa_idempresa
		{
			get { return plancuentas_ejercicio_empresa_idempresa;}
			set { plancuentas_ejercicio_empresa_idempresa = value;}
		}

	}
}

