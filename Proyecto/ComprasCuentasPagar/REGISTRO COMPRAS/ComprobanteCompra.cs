using System;
using PhantomDb.Entidades;

namespace ComprasCuentasPagar.REGISTRO_COMPRAS
{
    public class ComprobanteCompra
    {


        private long cod_comprobante;
        [Identificador(Modificable=false)]
        public long Cod_comprobante
        {
            get { return cod_comprobante; }
            set { cod_comprobante = value; }
        }

        private DateTime fechaRecepcion;
        [Atributo]
        public DateTime FechaRecepcion
        {
            get { return fechaRecepcion; }
            set { fechaRecepcion = value; }
        }

        private int tipoComprobante;
        [Atributo]
        public int TipoComprobante
        {
            get { return tipoComprobante; }
            set { tipoComprobante = value; }
        }

        private int moneda_moneda;
        [Atributo]
        public int Moneda_moneda
        {
            get { return moneda_moneda; }
            set { moneda_moneda = value; }
        }

        private DateTime fechaContabilizacion;
        [Atributo]
        public DateTime FechaContabilizacion
        {
            get { return fechaContabilizacion; }
            set { fechaContabilizacion = value; }
        }

        private DateTime fechaDeclaracionJurada;
        [Atributo]
        public DateTime PeriodoDeclaracionJurada
        {
            get { return fechaDeclaracionJurada; }
            set { fechaDeclaracionJurada = value; }
        }

        private long proveedores_cod_proveedor;
        [Atributo]
        [Columna("Código de Proveedor")]
        [Relacion(Destino = typeof(PROVEEDORES.Proveedor), CampoId = 0, CampoSecundario = 1)]
        public long Proveedores_cod_proveedor
        {
            get { return proveedores_cod_proveedor; }
            set { proveedores_cod_proveedor = value; }
        }

        private long sucursal_codigoSucursal;
        [Atributo]
        [Columna("Código de Sucursal")]
        public long Sucursal_codigoSucursal
        {
            get { return sucursal_codigoSucursal; }
            set { sucursal_codigoSucursal = value; }
        }

        private long moneda_empresa_idempresa;
        [Atributo]
        [Columna("Código de Empresa", false)]
        public long Moneda_empresa_idempresa
        {
            get { return moneda_empresa_idempresa; }
            set { moneda_empresa_idempresa = value; }
        }

        private long sucursal_empresa_idempresa;
        [Atributo]
        [Columna("Código de Empresa", false)]
        public long Sucursal_empresa_idempresa
        {
            get { return sucursal_empresa_idempresa; }
            set { sucursal_empresa_idempresa = value; }
        }

        private long proveedores_empresa_idempresa;
        [Atributo]
        [Columna("Código de Empresa",false)]
        public long Proveedores_empresa_idempresa
        {
            get { return proveedores_empresa_idempresa; }
            set { proveedores_empresa_idempresa = value; }
        }

        private string descuentosOtorgados;
        [Atributo]
        public string DescuentosOtorgados
        {
            get { return descuentosOtorgados; }
            set { descuentosOtorgados = value; }
        }

        private string causaEmision;
        [Atributo]
        public string CausaEmision
        {
            get { return causaEmision; }
            set { causaEmision = value; }
        }

        private double ivaAplicado;
        [Atributo]
        public double IvaAplicado
        {
            get { return ivaAplicado; }
            set { ivaAplicado = value; }
        }

        private double total;
        [Atributo]
        public double Total
        {
            get { return total; }
            set { total = value; }
        }



    }//clase
}//namespace
