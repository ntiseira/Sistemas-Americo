using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("regimenesEspeciales")]
	public class Entity_regimenesEspeciales
	{
		private int idregimen;
		[Identificador(Autogenerado=true)]
        [Columna (Visible=false)]
		public int Idregimen
		{
			get { return idregimen;}
			set { idregimen = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string impuesto;
		public string Impuesto
		{
			get { return impuesto;}
			set { impuesto = value;}
		}

		private bool computoventascontribuyente;
		public bool Computoventascontribuyente
		{
			get { return computoventascontribuyente;}
			set { computoventascontribuyente = value;}
		}

		private bool computoventasdgi;
		public bool Computoventasdgi
		{
			get { return computoventasdgi;}
			set { computoventasdgi = value;}
		}

        private int basecalculo;
        public int Basecalculo
		{
			get { return basecalculo;}
			set { basecalculo = value;}
		}

        private int tipomontominimo;
        public int Tipomontominimo
		{
			get { return tipomontominimo;}
			set { tipomontominimo = value;}
		}

		private float montominimo;
		public float Montominimo
		{
			get { return montominimo;}
			set { montominimo = value;}
		}

		private int tipopercepcionminima;
        public int Tipopercepcionminima
		{
			get { return tipopercepcionminima;}
			set { tipopercepcionminima = value;}
		}

		private float percepcionminima;
		public float Percepcionminima
		{
			get { return percepcionminima;}
			set { percepcionminima = value;}
		}

		private float porcentaje;
		public float Porcentaje
		{
			get { return porcentaje;}
			set { porcentaje = value;}
		}

		private float monto;
		public float Monto
		{
			get { return monto;}
			set { monto = value;}
		}

		private int tiporegimen_idtiporegimen;
        [Identificador]
        [Columna("Tipo de regimen")]
        [Relacion(Destino = typeof(Entidades.Entity_tiporegimen), CampoId = 0, CampoSecundario = 1)]
		public int Tiporegimen_idtiporegimen
		{
			get { return tiporegimen_idtiporegimen;}
			set { tiporegimen_idtiporegimen = value;}
		}

		private long empresa_idempresa;
		[Identificador]  
        [Columna (Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

