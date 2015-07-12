using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("talonario")]
	public class Entity_talonario
	{
 
		private int nroTalonario;
        [Identificador (Modificable=false)]
	    public int NroTalonario
		{

			get { return nroTalonario;}
			set { nroTalonario = value;}

		}

        private string descripcion;
		public string Descripcion
		{
            get { return descripcion; }
            set { descripcion = value; }
		}

        private long desde;
      
	//	[Columna(Titulo = "Nro. Desde")]
		public long Desde
		{
            get { return desde; }
            set { desde = value; }
		}

		private long hasta;       
	//	[Columna(Titulo = "Nro. Hasta")]
		public long Hasta
		{
            get { return hasta; }
            set { hasta = value; }
		}

     

		private bool utilizado;
        public bool Utilizado
		{
            get { return utilizado; }
            set { utilizado = value; }
		}

		private string aplicacion;
      //  [Columna(Titulo="Aplicación")]
        public string Aplicacion
		{
            get { return aplicacion; }
            set { aplicacion = value; }
		}


        private long ultimoUtilizado;
      
        public long UltimoUtilizado
        {
            get { return ultimoUtilizado; }
            set { ultimoUtilizado = value; }
        }

		private string Tiposcomprobante_idtipocomprobante;
		[Identificador]
	//	[Columna(Titulo = "Tipo de comprobante")]
	   [Relacion(Destino = typeof(Entidades.Entity_tipocomprobante), CampoId = 0, CampoSecundario = 1)]
        public string tiposcomprobante_idtipocomprobante
		{
			get { return Tiposcomprobante_idtipocomprobante;}
			set { Tiposcomprobante_idtipocomprobante = value;}
		}

		private long Tiposcomprobante_empresa_idempresa;		
//		[Columna(Visible = false)]
        public long tiposcomprobante_empresa_idempresa
		{
			get { return Tiposcomprobante_empresa_idempresa;}
			set { Tiposcomprobante_empresa_idempresa = value;}
		}

	}
}

