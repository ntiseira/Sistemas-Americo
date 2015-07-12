using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tasaiva")]
	public class Entity_tasaiva
	{
		private int idtasaiva;
		[Identificador]
		[Columna("Código")]
		public int Idtasaiva
		{
			get { return idtasaiva;}
			set { idtasaiva = value;}
		}


		private float tasa;
		[Columna("Tasa")]
		public float Tasa
		{
			get { return tasa;}
			set { tasa = value;}
		}

        private string descripcion;
        [Columna("Descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

		private long empresa_idempresa;
		[Identificador]
		[Columna(Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	}
}

