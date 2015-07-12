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
        [Atributo(Modificable = false)]
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string clase;
        [Atributo(Modificable = false)]
		public string Clase
		{
			get { return clase;}
			set { clase = value;}
		}

		private string observaciones;
        [Atributo(Modificable = false)]
		public string Observaciones
		{
			get { return observaciones;}
			set { observaciones = value;}
		}

      
		private string tipo;
        [Atributo(Modificable = false)]
		public string Tipo
		{
			get { return tipo;}
			set { tipo = value;}
		}

        private double tasaiva;
        [Atributo(Modificable = false)]
        public double Tasaiva
        {
            get { return tasaiva; }
            set { tasaiva = value; }
        }


        private double precioNeto;
        [Atributo(Modificable = false)]
        public double PrecioNeto
        {
            get { return precioNeto; }
            set { precioNeto = value; }
        }


        private double precioFinal;
        public double PrecioFinal
        {
            get { return precioFinal; }
            set { precioFinal = value; }
        }
        
        
        private long empresa_idempresa1;
        [Identificador]
        [Columna(false)]
        public long empresa_idempresa
        {
            get { return empresa_idempresa1; }
            set { empresa_idempresa1 = value; }
        }
		
		private int moneda_idmoneda1;
		[Identificador]
        [Relacion(Destino = typeof(Entidades.Entity_moneda), CampoId = 0, CampoSecundario = 1)]
		public int moneda_idmoneda
		{
			get { return moneda_idmoneda1;}
			set { moneda_idmoneda1 = value;}
		}

	}
}

