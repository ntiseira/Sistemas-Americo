using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("ejercicio")]
	public class Entity_ejercicio
	{
		private int codejercicio;
		[Identificador]
		public int Codejercicio
		{
			get { return codejercicio;}
			set { codejercicio = value;}
		}

		private DateTime fechainicio;
		public DateTime Fechainicio
		{
			get { return fechainicio;}
			set { fechainicio = value;}
		}

		private DateTime fechafin;
		public DateTime Fechafin
		{
			get { return fechafin;}
			set { fechafin = value;}
		}

		private string estado;
		public string Estado
		{
			get { return estado;}
			set { estado = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

