using System;
using PhantomDb.Entidades;

namespace Entidades
{
	[Tabla("lineadeVenta")]
	public class Entity_lineaVenta
	{
        [ Identificador (Autogenerado=true)]
        [Atributo(Modificable = false)]
        private int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        [Atributo(Modificable = false)]
        private int concepto_codConcepto;
        [Columna(Titulo = "Concepto")]
        
        public int Concepto_codConcepto
        {
            get { return concepto_codConcepto; }
            set { concepto_codConcepto = value; }
        }

        [Atributo(Modificable = false)]
        private int concepto_moneda_idmoneda;
        [Columna(Titulo = "Moneda")]
        public int Concepto_moneda_idmoneda
        {
            get { return concepto_moneda_idmoneda; }
            set { concepto_moneda_idmoneda = value; }
        }

        [Atributo(Modificable = false)]
        private int cantidad;
        [Columna(Titulo = "Cantidad")]
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        [Atributo(Modificable = false)]
        double tasaIva;
        [Columna(Titulo = "Tasa Iva")]
        public double TasaIva
        {
            get { return tasaIva; }
            set { tasaIva = value; }
        }

        [Atributo(Modificable = false)]
        double importeNeto;
        [Columna(Titulo = "Importe Neto")]
        public double ImporteNeto
        {
            get { return importeNeto; }
            set { importeNeto = value; }
        }

        [Atributo(Modificable = false)]
        double importe;
        [Columna(Titulo = "Importe Total")]
        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }

        private long comprobantesventa_idcomprobantesventa;

        public long Comprobantesventa_idcomprobantesventa
        {
            get { return comprobantesventa_idcomprobantesventa; }
            set { comprobantesventa_idcomprobantesventa = value; }
        }

	}
}

