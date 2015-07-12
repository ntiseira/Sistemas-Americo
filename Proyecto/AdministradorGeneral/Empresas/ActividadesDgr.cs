using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdministradorGeneral.Cliente
{
   public class ActividadesDgr
    {
         //ESTAS SON LAS ACTIVIDADES DGR que sirven de información básica para la liquidación del impuesto sobre los ingresos brutos
       
       private int codigoActividad;
       private string descripcion;
       private bool actividadPrincipal;
       private DateTime fechaAlta;
       private DateTime fechaBaja;
       private DateTime fechaVigencia;
       private double alicuota;
       private double montoMinimo;
       private bool actividadExenta;



       public ActividadesDgr(int cod, string des,bool actPrin, DateTime falta, DateTime fbaja, DateTime fvigencia, double alicuota, double mMin, bool actExenta)
       { 
           this.codigoActividad = cod;
           this.descripcion = des;
           this.actividadPrincipal = actPrin;
           this.fechaAlta = falta;
           this.fechaBaja =fbaja;
           this.fechaVigencia = fvigencia;
           this.alicuota = alicuota;
           this.montoMinimo = mMin;
           this.actividadExenta = actExenta;     
       }





#warning VER BIEN ACTIVIDAD EXENTA
/*ACTIVIDAD EXENTA, PUEDE IMPLICAR DATOS DE HABILITACIONES MUNICIAPLES, Y DATOS COMO
 *NRO DE EXPEDIENTE 
 *DIRECCION
 *LOCALIDAD
 * PROVINCIA
 * FECHA ALTA
 * FECHA BAJA
 * 
 * 
 */
 




    }
}
