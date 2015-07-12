using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("condicionVenta")]
	public class Entity_condicionVenta
	{
		private int codcondicion;
		[Identificador(Autogenerado=true)]
		[Columna(Titulo = "C�digo")]
		public int Codcondicion
		{
			get { return codcondicion;}
			set { codcondicion = value;}
		}

		private string descripcion;
		public string Descripcion
		{
			get { return descripcion;}
			set { descripcion = value;}
		}

		private DateTime fechavencimiento;
		public DateTime Fechavencimiento
		{
			get { return fechavencimiento;}
			set { fechavencimiento = value;}
		}

		private int cantdiasvencimiento;
		public int Cantdiasvencimiento
		{
			get { return cantdiasvencimiento;}
			set { cantdiasvencimiento = value;}
		}

		private string observaciones;
		public string Observaciones
		{
			get { return observaciones;}
			set { observaciones = value;}
		}

		private int cantcuotas;
		public int Cantcuotas
		{
			get { return cantcuotas;}
			set { cantcuotas = value;}
		}

		private bool anticipo;
		public bool Anticipo
		{
			get { return anticipo;}
			set { anticipo = value;}
		}

		private string tipocondicion;
		public string Tipocondicion
		{
			get { return tipocondicion;}
			set { tipocondicion = value;}
		}

		private long descuentofinanciero_coddescuento;
		[Identificador]
		[Columna(Titulo = "C�digo Descuento")]
		public long Descuentofinanciero_coddescuento
		{
			get { return descuentofinanciero_coddescuento;}
			set { descuentofinanciero_coddescuento = value;}
		}

		private long comprobanteventa_codcomprobanteventa;
		[Identificador]
		[Columna(Titulo = "C�digo Comprobante de venta")]
		public long Comprobanteventa_codcomprobanteventa
		{
			get { return comprobanteventa_codcomprobanteventa;}
			set { comprobanteventa_codcomprobanteventa = value;}
		}

		private long comprobanteventa_talonario_nrotalonario;
		[Identificador]
		[Columna(Titulo = "C�digo Talonario")]
		public long Comprobanteventa_talonario_nrotalonario
		{
			get { return comprobanteventa_talonario_nrotalonario;}
			set { comprobanteventa_talonario_nrotalonario = value;}
		}

		private int comprobanteventa_talonario_sucursal_codigosucursal;
		[Identificador]
		[Columna(Titulo="C�digo Sucursal", Visible=false)]
		public int Comprobanteventa_talonario_sucursal_codigosucursal
		{
			get { return comprobanteventa_talonario_sucursal_codigosucursal;}
			set { comprobanteventa_talonario_sucursal_codigosucursal = value;}
		}

		private long comprobanteventa_talonario_sucursal_empresa_idempresa;
		[Identificador]
		[Columna(Titulo = "C�digo Empresa", Visible=false)]
		public long Comprobanteventa_talonario_sucursal_empresa_idempresa
		{
			get { return comprobanteventa_talonario_sucursal_empresa_idempresa;}
			set { comprobanteventa_talonario_sucursal_empresa_idempresa = value;}
		}

		private int comprobanteventa_talonario_tipocomprobante_codcomprobante;
		[Identificador]
		[Columna(Titulo = "C�digo Comprobante")]
		public int Comprobanteventa_talonario_tipocomprobante_codcomprobante
		{
			get { return comprobanteventa_talonario_tipocomprobante_codcomprobante;}
			set { comprobanteventa_talonario_tipocomprobante_codcomprobante = value;}
		}

		private int comprobanteventa_cliente_codcliente;
		[Identificador]
		[Columna(Titulo = "C�digo Cliente")]
		public int Comprobanteventa_cliente_codcliente
		{
			get { return comprobanteventa_cliente_codcliente;}
			set { comprobanteventa_cliente_codcliente = value;}
		}

	}
}

