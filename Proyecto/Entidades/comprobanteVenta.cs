using System;
using PhantomDb.Entidades;

namespace Entidades
{
    [Tabla("comprobantesventa")]
	public class Entity_comprobanteVenta
	{
     

        private DateTime fecha;
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        private int cliente_codcliente;
        [Columna(Titulo = "Código de Cliente")]
        [Relacion(Destino = typeof(Entidades.Entity_cliente), CampoId = 0, CampoSecundario = 1)]
        public int Cliente_codcliente
        {
            get { return cliente_codcliente; }
            set { cliente_codcliente = value; }
        }


        private string letra;
        [Columna(Visible = false)]
        public string Letra
        {
            get { return letra; }
            set { letra = value; }
        }

        private int numero;
        [Identificador(Autogenerado = true)]
        [Columna (Visible=false)]
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        
        private double totalNeto;
        [Columna(Visible = false)]
        public double TotalNeto
        {
            get { return totalNeto; }
            set { totalNeto = value; }
        }

        private double totalIva;
        [Columna(Visible = false)]
        public double TotalIva
        {
            get { return totalIva; }
            set { totalIva = value; }
        }

        private double totalRecargo;
        [Columna(Visible = false)]
        public double TotalRecargo
        {
            get { return totalRecargo; }
            set { totalRecargo = value; }
        }

        private double totalDescuento;
        [Columna(Visible = false)]
        public double TotalDescuento
        {
            get { return totalDescuento; }
            set { totalDescuento = value; }
        }

        private double totalOtros;
        [Columna(Visible = false)]
        public double TotalOtros
        {
            get { return totalOtros; }
            set { totalOtros = value; }
        }

        private int talonario_nroTalonario;
        [Columna(Visible = false)]
        public int Talonario_nroTalonario
        {
            get { return talonario_nroTalonario; }
            set { talonario_nroTalonario = value; }
        }

        private int talonario_sucursal_codigoSucursal;
        [Columna(Visible = false)]
        public int Talonario_sucursal_codigoSucursal
        {
            get { return talonario_sucursal_codigoSucursal; }
            set { talonario_sucursal_codigoSucursal = value; }
        }

        private int talonario_tiposcomprobante_idtipocomprobante;
        [Columna(Titulo = "Tipo de Comprobante")]
        [Relacion(Destino = typeof(Entidades.Entity_tipocomprobante), CampoId = 0, CampoSecundario = 1)]
        public int Talonario_tiposcomprobante_idtipocomprobante
        {
            get { return talonario_tiposcomprobante_idtipocomprobante; }
            set { talonario_tiposcomprobante_idtipocomprobante = value; }
        }

        private int tipolista_idtipolista;
        [Columna (Visible=false)]
        public int Tipolista_idtipolista
		{
            get { return tipolista_idtipolista; }
            set { tipolista_idtipolista = value; }
		}


        private bool habilitado;
        [Columna(Visible = false)]
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }
        


        private int moneda_idmoneda;
        [Columna(Titulo = "Moneda")]
        public int Moneda_idmoneda
        {
            get { return moneda_idmoneda; }
            set { moneda_idmoneda = value; }
        }

		private DateTime fechaentrega;
        [Columna(Visible = false)]
		public DateTime Fechaentrega
		{
			get { return fechaentrega;}
			set { fechaentrega = value;}
		}


        private DateTime fechadeclaracion;
        [Columna(Visible = false)]
        public DateTime Fechadeclaracion
        {
            get { return fechadeclaracion; }
            set { fechadeclaracion = value; }
        }

        private DateTime fechacontabilizacion;
        [Columna(Visible = false)]
        public DateTime Fechacontabilizacion
        {
            get { return fechacontabilizacion; }
            set { fechacontabilizacion = value; }
        }




		private DateTime fechaemision;
        [Columna(Visible = false)]
		public DateTime Fechaemision
		{
			get { return fechaemision;}
			set { fechaemision = value;}
		}

        private long empresa_idempresa;
        [Columna(Visible=false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }
		
        private int provincia_codProv;
        [Columna(Visible = false)]
    //    [Relacion(Destino = typeof(Entidades.Entity_provincia), CampoId = 0, CampoSecundario = 1)]
        public int Provincia_codProv
		{
            get { return provincia_codProv; }
            set { provincia_codProv = value; }
		}

        private bool biendeuso;
        [Columna(Visible = false)]
		public bool Biendeuso
		{
            get { return biendeuso; }
            set { biendeuso = value; }
		}
        	

		private double total;
		public double Total
		{
			get { return total;}
			set { total = value;}
		}


        private int regimenesEspeciales_idregimen;
        [Columna(Titulo = "Regimen Especial", Visible=false)]
        public int RegimenesEspeciales_idregimen
        {
            get { return regimenesEspeciales_idregimen; }
            set { regimenesEspeciales_idregimen = value; }
        }



	}
}

