using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("cheque")]
	public class Entity_cheque
	{
		private int idcheque;
		[Identificador]
		public int Idcheque
		{
			get { return idcheque;}
			set { idcheque = value;}
		}

		private DateTime vencimiento;
		[Columna(Formato=Formato.DateType)]
		public DateTime Vencimiento
		{
			get { return vencimiento;}
			set { vencimiento = value;}
		}

		private float importe;
		public float Importe
		{
			get { return importe;}
			set { importe = value;}
		}

		private string estado;
		[Columna(ValoresFijos="Entregado,En cartera,Anulado,Rechazado")]
		public string Estado
		{
			get { return estado;}
			set { estado = value;}
		}

		private bool origen;
		public bool Origen
		{
			get { return origen;}
			set { origen = value;}
		}

		private int banco_idbanco;
		[Columna("Banco")]
		[Relacion(Destino = typeof(Entity_banco), CampoId = 0, CampoSecundario = 1)]
		public int Banco_idbanco
		{
			get { return banco_idbanco;}
			set { banco_idbanco = value;}
		}

		private long banco_empresa_idempresa;
		[Columna(Visible=false)]
		public long Banco_empresa_idempresa
		{
			get { return banco_empresa_idempresa;}
			set { banco_empresa_idempresa = value;}
		}

		private long empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Empresa_idempresa
		{
			get { return empresa_idempresa;}
			set { empresa_idempresa = value;}
		}

		private int tipocheque_idtipocheque;
		[Columna("Tipo")]
		[Relacion(Destino = typeof(Entity_tipocheque), CampoId = 0, CampoSecundario = 1)]
		public int Tipocheque_idtipocheque
		{
			get { return tipocheque_idtipocheque;}
			set { tipocheque_idtipocheque = value;}
		}

		private int moneda_idmoneda;
		[Columna("Moneda")]
		[Relacion(Destino = typeof(Entity_moneda), CampoId = 0, CampoSecundario = 1)]
		public int Moneda_idmoneda
		{
			get { return moneda_idmoneda;}
			set { moneda_idmoneda = value;}
		}

	}
}

