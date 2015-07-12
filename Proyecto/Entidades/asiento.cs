using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("asiento")]
	public class Entity_asiento
	{
		private int idasiento;
		[Identificador(Autogenerado=true)]
		[Columna("Código")]
		public int Idasiento
		{
			get { return idasiento;}
			set { idasiento = value;}
		}

		private string descripcion;
		[Columna("Descripción")]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private bool editable;
		public bool Editable
		{
			get { return editable;}
			set { editable = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
		}

		private bool habilitado;
		public bool Habilitado
		{
			get { return habilitado;}
			set { habilitado = value;}
		}

		private bool generadosistema;
		[Columna("Sistema")]
		public bool Generadosistema
		{
			get { return generadosistema;}
			set { generadosistema = value;}
		}

		private int ejercicio_codejercicio;
		[Identificador]
		[Columna(Visible=false)]
		public int Ejercicio_codejercicio
		{
			get { return ejercicio_codejercicio;}
			set { ejercicio_codejercicio = value;}
		}

		private long ejercicio_empresa_idempresa;
		[Identificador]
		[Columna(Visible = false)]
		public long Ejercicio_empresa_idempresa
		{
			get { return ejercicio_empresa_idempresa;}
			set { ejercicio_empresa_idempresa = value;}
		}

		private string tipoasiento_descripcion;
		[Columna("Tipo")]
		[Relacion(Destino = typeof(Entity_tipoasiento))]
		public string Tipoasiento_descripcion
		{
			get { return tipoasiento_descripcion;}
			set { tipoasiento_descripcion = value;}
		}

		private long tipoasiento_empresa_idempresa;
		[Columna(Visible = false)]
		public long Tipoasiento_empresa_idempresa
		{
			get { return tipoasiento_empresa_idempresa;}
			set { tipoasiento_empresa_idempresa = value;}
		}

	}
}

