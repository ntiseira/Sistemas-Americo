using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("tiposcomprobante")]
	public class Entity_tipocomprobante
	{
		private int codcomprobante;
		[Identificador]
        public int idtipocomprobante
		{
			get { return codcomprobante;}
			set { codcomprobante = value;}
		}

		private string Descripcion;
		public string descrip
		{
			get { return Descripcion;}
			set { Descripcion = value;}
		}

        private long empresa_idempresa;
        [Identificador]
        [Columna(false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }
		
	}
}

