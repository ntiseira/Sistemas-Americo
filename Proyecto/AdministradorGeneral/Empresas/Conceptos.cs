using PhantomDb.Entidades;

namespace AdministradorGeneral.Empresas
{
    [Tabla("concepto")]
   public class Conceptos
    {
        private int cod;
        [Identificador(Modificable=false)]
        [Columna("Código")]             //Permite ingresar una nomenclatura para distinguir el concepto
        public int codConcepto
        {
            get { return cod; }
            set { cod = value; }
        }

        private string descripcion;
        [Columna("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        private string clase;    
        [Columna(Titulo = "Clase", ValoresFijos = "Normal:Normal,Sólo IVA:Sólo IVA,Sólo No Gravado:Sólo No Gravado,Otros:Otros")]
        public string Clase
        {
            get { return clase; }
            set { clase = value; }
        }
        private string observaciones;
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        private int tipo;
        [Columna(Titulo = "Tipo de Concepto", ValoresFijos = "Mercadería de Reventa:Mercadería de Reventa,Elaboración Propia:Elaboración Propia,Producto en proceso:Producto en proceso,Materia prima:Materia prima,Material:Material,Servicio:Servicio,Otros:Otros")]
        public int Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
       
       // COMPRAS
        private string tasaIvaCompras;//Aca hay que asociarlo con el registro de tasas de iva del administrador general
        [Identificador(Modificable = true)]
        [Columna("Tasa Iva Compras")]
        public string TasaIvaCompras
        {
            get { return tasaIvaCompras; }
            set { tasaIvaCompras = value; }
        }

        private bool exentoCompras;
        [Columna("Exento compras")]
        public bool ExentoCompras
        {
            get { return exentoCompras; }
            set { exentoCompras = value; }
        }

       
        private string imputacion;
        [Columna("Imputacion")]
        public string Imputacion
        {
            get { return imputacion; }
            set { imputacion = value; }
        }
        
        
        private string rubro;          
        /*Permite ingresar el rubro al que pertenece el concepto, las opciones son:
         * Compra de bienes en el mercado local
        " Locaciones
        " Prestaciones de Servicios
        " Otros conceptos
        " Tur IVA
        " Compra de bienes en el exterior
        " Compra de servicios en el exterior*/
        
         public string Rubro
        {
            get { return rubro; }
            set { rubro = value; }
        }
       
      
       //VENTAS

        private string tasaIvaVentas;//Aca hay que asociarlo con el registro de tasas de iva del administrador general
        [Atributo]
        [Columna("Tasa iva ventas")]
        public string TasaIvaVentas
        {
            get { return tasaIvaVentas; }
            set { tasaIvaVentas = value; }
        }


        private bool exentoVentas;
        [Columna("Exento ventas")]
        public bool ExentoVentas
        {
            get { return exentoVentas; }
            set { exentoVentas = value; }
        }

        private bool exportacionVentas;
        [Columna("Exportación Ventas")]
        public bool ExportacionVentas
        {
            get { return exportacionVentas; }
            set { exportacionVentas = value; }
        }
      
        private string mon;

        [Atributo]
        [Columna("Moneda")]
        public string moneda_idmoneda
        {
            get { return mon; }
            set { mon = value; }
        }

        private double netoGravado;
        [Columna("Neto gravado")]
        public double NetoGravado
        {
            get { return netoGravado; }
            set { netoGravado = value; }
        }
        private double precioFinal;

        [Atributo]
        [Columna("Precio final")]
        public double PrecioFinal
        {
            get { return precioFinal; }
            set { precioFinal = value; }
        }


        private long venta_codVenta;
        [Identificador(Modificable = false)]
        [Columna("Código de Venta", false)]
        public long Venta_codVenta
        {
            get { return venta_codVenta; }
            set { venta_codVenta = value; }
        }

        private int venta_comprobanteVenta_codComprobanteVenta;
        [Columna("Código de Comprobante de Venta", false)]
        public int Venta_comprobanteVenta_codComprobanteVenta
        {
            get { return venta_comprobanteVenta_codComprobanteVenta; }
            set { venta_comprobanteVenta_codComprobanteVenta = value; }
        }

    
           

    }//clase
}//namespace
