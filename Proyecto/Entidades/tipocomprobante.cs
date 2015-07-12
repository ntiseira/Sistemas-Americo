using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tiposcomprobante")]
	public class Entity_tipocomprobante
	{
        private int idtipocomprobante;
		[Identificador]
        public int Idtipocomprobante
		{
            get { return idtipocomprobante; }
            set { idtipocomprobante = value; }
		}

        private string descrip;
		public string Descrip
		{
            get { return descrip; }
            set { descrip = value; }
		}

        private long empresa_idempresa;
        [Identificador]
        [Columna(false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }

        private string clase;

        public string Clase
        {
            get { return clase; }
            set { clase = value; }
        }

        private string letra;

        public string Letra
        {
            get { return letra; }
            set { letra = value; }
        }

		
	}
}

