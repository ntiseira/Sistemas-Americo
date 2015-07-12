using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VentasCuentasCobrar
{
   public class DatosAdicionales
    {

       private string paginaWeb;
       private string tipoSocial; //ej soc anonima
       private int envergadura; //tipo de magnitud de la empresa: Mediana, grande
       private string horarioAtencion; 
       private DateTime fechaDeAltaCliente; //desde que fecha es cliente del estudio
       private string nota;

       public DatosAdicionales(string pagW, string tSocial, int e, DateTime fAlta, string n)
       {
           this.paginaWeb = pagW;
           this.tipoSocial = tSocial;
           this.fechaDeAltaCliente = fAlta;
           this.nota = n;      
       }
      








    }//clase
}//namespace

