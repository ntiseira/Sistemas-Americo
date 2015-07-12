using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tiposcomprobante")]
	public class Entity_tiposcomprobante
	{
		private string idtipocomprobante;
		[Identificador (Autogenerado=true)]
        [Columna(Titulo="Código")]
		public string Idtipocomprobante
		{
			get { return idtipocomprobante;}
			set { idtipocomprobante = value;}
		}

		private string descrip;
		[Columna(Titulo = "Descripción")]
		public string Descrip
		{
			get { return descrip;}
			set { descrip = value;}
		}

		private string clase;
		public string Clase
		{
			get { return clase;}
			set { clase = value;}
		}

        private string letra;
        [Atributo(EsLetra = true)]
        public string Letra
        {
            get { return letra; }
            set { letra = value; }
        }


  
		private long empresa_idempresa;
		[Identificador]
		[Columna(Titulo = "Empresa",Visible=false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

	
	}
}

