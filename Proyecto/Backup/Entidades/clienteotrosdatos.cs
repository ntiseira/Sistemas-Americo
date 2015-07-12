using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("clienteotrosdatos")]
	public class Entity_clienteotrosdatos
	{
		private int cliente_codcliente;
		[Identificador]
		[Columna(false)]
		public int Cliente_codcliente
		{
			get { return cliente_codcliente;}
			set { cliente_codcliente = value;}
		}

		private long cliente_empresa_idempresa;
		[Identificador]
		[Columna(false)]
		public long Cliente_empresa_idempresa
		{
			get { return cliente_empresa_idempresa;}
			set { cliente_empresa_idempresa = value;}
		}

		private string contacto;
		public string Contacto
		{
			get { return contacto;}
			set { contacto = value;}
		}

		private string nombrefantasia;
		[Columna("Nombre fantasía")]
		public string Nombrefantasia
		{
			get { return nombrefantasia;}
			set { nombrefantasia = value;}
		}

		private string lugarpago;
		[Columna("Lugar de pago")]
		public string Lugarpago
		{
			get { return lugarpago;}
			set { lugarpago = value;}
		}

		private string horariopago;
		[Columna("Horarios")]
		public string Horariopago
		{
			get { return horariopago;}
			set { horariopago = value;}
		}

		private string responsablepago;
		[Columna("Responsable")]
		public string Responsablepago
		{
			get { return responsablepago;}
			set { responsablepago = value;}
		}

		private string nota;
		public string Nota
		{
			get { return nota;}
			set { nota = value;}
		}

	}
}

