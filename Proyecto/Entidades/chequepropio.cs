using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("chequepropio")]
	public class Entity_chequepropio
	{
		private int cheque_idcheque;
		[Identificador]
		[Columna(Visible = false)]
		public int Cheque_idcheque
		{
			get { return cheque_idcheque;}
			set { cheque_idcheque = value;}
		}

		private long cheque_empresa_idempresa;
		[Identificador]
		[Columna(Visible = false)]
		public long Cheque_empresa_idempresa
		{
			get { return cheque_empresa_idempresa;}
			set { cheque_empresa_idempresa = value;}
		}

		private int proveedor_idproveedor;
		public int Proveedor_idproveedor
		{
			get { return proveedor_idproveedor;}
			set { proveedor_idproveedor = value;}
		}

		private long proveedor_empresa_idempresa;
		public long Proveedor_empresa_idempresa
		{
			get { return proveedor_empresa_idempresa;}
			set { proveedor_empresa_idempresa = value;}
		}

	}
}

