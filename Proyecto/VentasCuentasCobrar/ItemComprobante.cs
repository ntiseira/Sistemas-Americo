using System;
using System.Text;
using PhantomDb.Entidades;

namespace VentasCuentasCobrar
{
    public class ItemComprobante
    {
      private  int codigo;
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private int concepto_codConcepto;
        public int Concepto_codConcepto
        {
            get { return concepto_codConcepto; }
            set { concepto_codConcepto = value; }
        }


        private int concepto_moneda_idmoneda;
        public int Concepto_moneda_idmoneda
        {
            get { return concepto_moneda_idmoneda; }
            set { concepto_moneda_idmoneda = value; }
        }


        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        double importe;
        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }
    
    
    }//clase
}//namespace
