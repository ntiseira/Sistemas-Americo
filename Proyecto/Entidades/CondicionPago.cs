using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("CondicionPago")]
	public class Entity_CondicionPago
	{
		private int cod_condicionpago;
		[Identificador]
		public int Cod_condicionpago
		{
			get { return cod_condicionpago;}
			set { cod_condicionpago = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private string tipocondicion;
		public string Tipocondicion
		{
			get { return tipocondicion;}
			set { tipocondicion = value;}
		}

		private int cantdiasvencimiento;
		public int Cantdiasvencimiento
		{
			get { return cantdiasvencimiento;}
			set { cantdiasvencimiento = value;}
		}

		private DateTime fechavencimiento;
		public DateTime Fechavencimiento
		{
			get { return fechavencimiento;}
			set { fechavencimiento = value;}
		}

		private int cantcuotas;
		public int Cantcuotas
		{
			get { return cantcuotas;}
			set { cantcuotas = value;}
		}

		private int diaentrecuotas;
		public int Diaentrecuotas
		{
			get { return diaentrecuotas;}
			set { diaentrecuotas = value;}
		}

		private bool anticipo;
		public bool Anticipo
		{
			get { return anticipo;}
			set { anticipo = value;}
		}

		private string observaciones;
		public string Observaciones
		{
			get { return observaciones;}
			set { observaciones = value;}
		}

		private int compras_cod_compra;
		[Identificador]
		public int Compras_cod_compra
		{
			get { return compras_cod_compra;}
			set { compras_cod_compra = value;}
		}

		private int compras_proveedores_cod_proveedor;
		[Identificador]
		public int Compras_proveedores_cod_proveedor
		{
			get { return compras_proveedores_cod_proveedor;}
			set { compras_proveedores_cod_proveedor = value;}
		}

		private long compras_proveedores_empresa_idempresa;
		[Identificador]
		public long Compras_proveedores_empresa_idempresa
		{
			get { return compras_proveedores_empresa_idempresa;}
			set { compras_proveedores_empresa_idempresa = value;}
		}

	}
}

