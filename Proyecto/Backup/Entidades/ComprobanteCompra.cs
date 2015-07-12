using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("ComprobanteCompra")]
	public class Entity_ComprobanteCompra
	{
		private long cod_comprobante;
		[Identificador]
		[Columna("Código")]
		public long Cod_comprobante
		{
			get { return cod_comprobante;}
			set { cod_comprobante = value;}
		}

		private DateTime fecharecepcion;
		[Columna("Recepción")]
		public DateTime Fecharecepcion
		{
			get { return fecharecepcion;}
			set { fecharecepcion = value;}
		}

		private double compfinancieroimplicito;
		public double Compfinancieroimplicito
		{
			get { return compfinancieroimplicito;}
			set { compfinancieroimplicito = value;}
		}

		private DateTime fecha;
		public DateTime Fecha
		{
			get { return fecha;}
			set { fecha = value;}
		}

		private string tipocomprobante;
		[Columna("Tipo")]
		public string Tipocomprobante
		{
			get { return tipocomprobante;}
			set { tipocomprobante = value;}
		}

		private DateTime fechacontabilizacion;
		public DateTime Fechacontabilizacion
		{
			get { return fechacontabilizacion;}
			set { fechacontabilizacion = value;}
		}

		private DateTime periododeclaracionjurada;
		public DateTime Periododeclaracionjurada
		{
			get { return periododeclaracionjurada;}
			set { periododeclaracionjurada = value;}
		}

		private int sucursal_codigosucursal;
		[Columna(Visible = false)]
		public int Sucursal_codigosucursal
		{
			get { return sucursal_codigosucursal;}
			set { sucursal_codigosucursal = value;}
		}

		private long sucursal_empresa_idempresa;
		[Columna(Visible = false)]
		public long Sucursal_empresa_idempresa
		{
			get { return sucursal_empresa_idempresa;}
			set { sucursal_empresa_idempresa = value;}
		}

		private int proveedores_cod_proveedor;
		[Identificador]
		[Columna(Titulo = "Proveedor")]
		[Relacion(Destino = typeof(Entity_proveedor), CampoId = 0, CampoSecundario = 1)]
		public int Proveedores_cod_proveedor
		{
			get { return proveedores_cod_proveedor;}
			set { proveedores_cod_proveedor = value;}
		}

		private long proveedores_empresa_idempresa;
		[Identificador]
		[Columna(Visible = false)]
		public long Proveedores_empresa_idempresa
		{
			get { return proveedores_empresa_idempresa;}
			set { proveedores_empresa_idempresa = value;}
		}

		private float descuentosotorgados;
		public float Descuentosotorgados
		{
			get { return descuentosotorgados;}
			set { descuentosotorgados = value;}
		}

		private string causaemision;
		public string Causaemision
		{
			get { return causaemision;}
			set { causaemision = value;}
		}

		private float ivaaplicado;
		public float Ivaaplicado
		{
			get { return ivaaplicado;}
			set { ivaaplicado = value;}
		}

		private float total;
		public float Total
		{
			get { return total;}
			set { total = value;}
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
		[Columna(Visible=false)]
		public long Compras_proveedores_empresa_idempresa
		{
			get { return compras_proveedores_empresa_idempresa;}
			set { compras_proveedores_empresa_idempresa = value;}
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

