using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("comprobanteVenta")]
	public class Entity_comprobanteVenta
	{
		private long codcomprobanteventa;
		[Identificador (Autogenerado= true)]
        
		public long Codcomprobanteventa
		{
			get { return codcomprobanteventa;}
			set { codcomprobanteventa = value;}
		}

        private char letra;

        public char Letra
        {
            get { return letra; }
            set { letra = value; }
        }
        private int numero;

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        
        private double totalNeto;

        public double TotalNeto
        {
            get { return totalNeto; }
            set { totalNeto = value; }
        }
        private double totalNoGravado;

        public double TotalNoGravado
        {
            get { return totalNoGravado; }
            set { totalNoGravado = value; }
        }
        private double ivaInscripto;

        public double IvaInscripto
        {
            get { return ivaInscripto; }
            set { ivaInscripto = value; }
        }
        private double ivaNoInscripto;

        public double IvaNoInscripto
        {
            get { return ivaNoInscripto; }
            set { ivaNoInscripto = value; }
        }
        private double otros;

        public double Otros
        {
            get { return otros; }
            set { otros = value; }
        }


		private string tipolista;
		public string Tipolista
		{
			get { return tipolista;}
			set { tipolista = value;}
		}

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }
               


		private DateTime fechaentrega;
		public DateTime Fechaentrega
		{
			get { return fechaentrega;}
			set { fechaentrega = value;}
		}

		private DateTime fechaemision;
		public DateTime Fechaemision
		{
			get { return fechaemision;}
			set { fechaemision = value;}
		}

		
		private long lote;
		public long Lote
		{
			get { return lote;}
			set { lote = value;}
		}

		private string mensaje;
		public string Mensaje
		{
			get { return mensaje;}
			set { mensaje = value;}
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

		private int provincia;
        [Relacion(Destino = typeof(Entidades.Entity_provincia), CampoId = 0, CampoSecundario = 1)]
		public int Provincia
		{
			get { return provincia;}
			set { provincia = value;}
		}

		private bool bienuso;
		public bool Bienuso
		{
			get { return bienuso;}
			set { bienuso = value;}
		}
        	

		private double total;
		public double Total
		{
			get { return total;}
			set { total = value;}
		}

		private DateTime plazosentrega;
		public DateTime Plazosentrega
		{
			get { return plazosentrega;}
			set { plazosentrega = value;}
		}

		private int diasmantoferta;
		public int Diasmantoferta
		{
			get { return diasmantoferta;}
			set { diasmantoferta = value;}
		}

		private DateTime fechaentregabienuso;
		public DateTime Fechaentregabienuso
		{
			get { return fechaentregabienuso;}
			set { fechaentregabienuso = value;}
		}

		private bool emitido;
		public bool Emitido
		{
			get { return emitido;}
			set { emitido = value;}
		}

		private DateTime fechaingreso;
		public DateTime Fechaingreso
		{
			get { return fechaingreso;}
			set { fechaingreso = value;}
		}

			
		private int cliente_codcliente;
        [Columna(Titulo = "Código de Cliente")]
        [Relacion(Destino = typeof(Entidades.Entity_cliente), CampoId = 0, CampoSecundario = 1)]
		public int Cliente_codcliente
		{
			get { return cliente_codcliente;}
			set { cliente_codcliente = value;}
		}

	/*	private long venta_codventa;
        [Columna(Titulo = "Código de Venta")]
        [Relacion(Destino = typeof(Entidades.Entity_venta), CampoId = 0, CampoSecundario = 1)]
		public long Venta_codventa
		{
			get { return venta_codventa;}
			set { venta_codventa = value;}
		}

        //private long venta_comprobanteventa_codcomprobanteventa;
        //public long Venta_comprobanteventa_codcomprobanteventa
        //{
        //    get { return venta_comprobanteventa_codcomprobanteventa;}
        //    set { venta_comprobanteventa_codcomprobanteventa = value;}
        //}

		private int venta_vendedor_codvendedor;
        [Columna(Titulo = "Vendedor")]
        [Relacion(Destino = typeof(Entidades.Entity_Vendedor), CampoId = 0, CampoSecundario = 1)]
		public int Venta_vendedor_codvendedor
		{
			get { return venta_vendedor_codvendedor;}
			set { venta_vendedor_codvendedor = value;}
		}

		private int venta_vendedor_sucursal_codigosucursal;
        [Columna(Visible=false)]
        [Relacion(Destino = typeof(Entidades.Entity_sucursal), CampoId = 0, CampoSecundario = 1)]
		public int Venta_vendedor_sucursal_codigosucursal
		{
			get { return venta_vendedor_sucursal_codigosucursal;}
			set { venta_vendedor_sucursal_codigosucursal = value;}
		}

		private long venta_vendedor_sucursal_empresa_idempresa;
        [Columna(Visible = false)]
		public long Venta_vendedor_sucursal_empresa_idempresa
		{
			get { return venta_vendedor_sucursal_empresa_idempresa;}
			set { venta_vendedor_sucursal_empresa_idempresa = value;}
		}
*/


	}
}

