using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("situacionfinanciera")]
	public class Entity_situacionfinanciera
	{
		private int idsituacionfinanciera;
		[Identificador(Autogenerado=true)]
		public int Idsituacionfinanciera
		{
			get { return idsituacionfinanciera;}
			set { idsituacionfinanciera = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
		}

		private bool mora;
		public bool Mora
		{
			get { return mora;}
			set { mora = value;}
		}

		private bool gestionjudicial;
		public bool Gestionjudicial
		{
			get { return gestionjudicial;}
			set { gestionjudicial = value;}
		}

		private bool incobrable;
		public bool Incobrable
		{
			get { return incobrable;}
			set { incobrable = value;}
		}

		private float maximo;
		public float Maximo
		{
			get { return maximo;}
			set { maximo = value;}
		}

		private float total;
		public float Total
		{
			get { return total;}
			set { total = value;}
		}

		private float disponible;
		public float Disponible
		{
			get { return disponible;}
			set { disponible = value;}
		}

		private float total_vencer;
		public float Total_vencer
		{
			get { return total_vencer;}
			set { total_vencer = value;}
		}

		private float total_vencido;
		public float Total_vencido
		{
			get { return total_vencido;}
			set { total_vencido = value;}
		}

		private float total_terceros;
		public float Total_terceros
		{
			get { return total_terceros;}
			set { total_terceros = value;}
		}

		private float total_rechazados;
		public float Total_rechazados
		{
			get { return total_rechazados;}
			set { total_rechazados = value;}
		}

		private float total_pendientes;
		public float Total_pendientes
		{
			get { return total_pendientes;}
			set { total_pendientes = value;}
		}

		private int cliente_codcliente;
		[Identificador]
		public int Cliente_codcliente
		{
			get { return cliente_codcliente;}
			set { cliente_codcliente = value;}
		}

		private long cliente_empresa_idempresa;
		[Identificador]
		public long Cliente_empresa_idempresa
		{
			get { return cliente_empresa_idempresa;}
			set { cliente_empresa_idempresa = value;}
		}

	}
}

