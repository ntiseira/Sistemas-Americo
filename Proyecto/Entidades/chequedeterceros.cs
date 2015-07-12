using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("chequedeterceros")]
	public class Entity_chequedeterceros
	{
		private int cheque_idcheque;
		[Identificador]
		[Columna(Visible=false)]
		public int Cheque_idcheque
		{
			get { return cheque_idcheque;}
			set { cheque_idcheque = value;}
		}

		private long cheque_empresa_idempresa;
		[Identificador]
		[Columna(Visible=false)]
		public long Cheque_empresa_idempresa
		{
			get { return cheque_empresa_idempresa;}
			set { cheque_empresa_idempresa = value;}
		}

		private int cliente_codcliente;
		[Columna("Cliente")]
		[Relacion(Destino = typeof(Entity_cliente), CampoId = 0, CampoSecundario = 0)]
		public int Cliente_codcliente
		{
			get { return cliente_codcliente;}
			set { cliente_codcliente = value;}
		}

	}
}

