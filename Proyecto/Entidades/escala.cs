using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("escala")]
	public class Entity_escala
	{
		private int idescala;
		[Identificador(Autogenerado=true)]
		public int Idescala
		{
			get { return idescala;}
			set { idescala = value;}
		}

		private float desde;
		public float Desde
		{
			get { return desde;}
			set { desde = value;}
		}

		private float hasta;
		public float Hasta
		{
			get { return hasta;}
			set { hasta = value;}
		}

		private float importeporcentaje;
		public float Importeporcentaje
		{
			get { return importeporcentaje;}
			set { importeporcentaje = value;}
		}

		private int regimenesespeciales_idregimen;
		[Identificador]
		public int Regimenesespeciales_idregimen
		{
			get { return regimenesespeciales_idregimen;}
			set { regimenesespeciales_idregimen = value;}
		}

		private long regimenesespeciales_empresa_idempresa;
		[Identificador]
		public long Regimenesespeciales_empresa_idempresa
		{
			get { return regimenesespeciales_empresa_idempresa;}
			set { regimenesespeciales_empresa_idempresa = value;}
		}

	}
}

