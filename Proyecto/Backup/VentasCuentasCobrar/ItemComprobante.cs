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


        private int concepto;
        [Identificador]
     //   [Relacion(Destino = typeof(Entidades.Entity_concepto),CampoId=1)]
        public int Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }


     /*   [Identificador]
        [Columna ("Concepto")]
        
        [Relacion(Destino = typeof(Entidades.Entity_concepto), CampoId = 0, CampoSecundario = 1)]
        public int Concepto
        {
            get { return concepto; }
            set { concepto = value; }
        }
        */
      

        private int cantidad;
        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        float importe;
        public float Importe
        {
            get { return importe; }
            set { importe = value; }
        }
    }
}
