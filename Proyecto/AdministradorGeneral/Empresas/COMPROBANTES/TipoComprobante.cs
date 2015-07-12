using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdministradorGeneral.Comprobantes
{
   public class TipoComprobante
    {

       private string codigoComprobante;
       private bool habilitado;
       private ClaseComprobante clase;
       private string descripcion;
       private bool loteComprobantes; //aca se indica si en la interfaz se indicara un lote , desde hasta, para el comprobante
       private bool letraIdentificatoria;
       private bool puntoVenta;
       private bool nroIdentificatorio;


       //Comportamiento

       private bool comprobanteRemite;
       private bool comprobanteFactura;
       private bool generaCantPendientesRemitir;
       private bool generaCantPendientesFacturar;
       private bool estadisticas;

       //Otros datos


       private bool importacion;
       private bool exportacion;
       private bool ingresaCausaEmision;
#warning Comprobante para descuento
       private string codigoComprobanteLibroIva;


       //TALONARIO






    }//clase
}//namespace
