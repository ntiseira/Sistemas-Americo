using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentasCuentasCobrar
{
   public  class Impuesto
   {

       private int codigoImpuesto;
       private string descripcion;

       public Impuesto(int cod, string des)
       {
           this.codigoImpuesto = cod;
           this.descripcion = des;       
       }



    }//clase
}//namespace
