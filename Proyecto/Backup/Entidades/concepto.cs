using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("concepto")]
	public class Entity_concepto
	{
		private int codconcepto;
        [Identificador(Autogenerado=true)]
		public int Codconcepto
		{
			get { return codconcepto;}
			set { codconcepto = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string clase;
		public string Clase
		{
			get { return clase;}
			set { clase = value;}
		}

		private string observaciones;
		public string Observaciones
		{
			get { return observaciones;}
			set { observaciones = value;}
		}

      
		private string tipo;    
		public string Tipo
		{
			get { return tipo;}
			set { tipo = value;}
		}

        private double tasaiva;
        public double Tasaiva
        {
            get { return tasaiva; }
            set { tasaiva = value; }
        }


        private double precioneto;
        public double PrecioNeto
        {
            get { return precioneto; }
            set { precioneto = value; }
        }


        private double preciofinal;
        public double PrecioFinal
        {
            get { return preciofinal; }
            set { preciofinal = value; }
        }
        



        private long empresa_idempresa;
        [Identificador]
        [Columna(false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }
		
		private int moneda_idmoneda;
		[Identificador]
		public int Moneda_idmoneda
		{
			get { return moneda_idmoneda;}
			set { moneda_idmoneda = value;}
		}

	}
}

