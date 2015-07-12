using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ModuloSoporte.Validadores
{
    public class ValidadorEmail : IValidador
    {
       private bool email_bien_escrito(String email)
       {
           String expresion;
           expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
           if (Regex.IsMatch(email, expresion))
           {
               if (Regex.Replace(email, expresion, String.Empty).Length == 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           else
           {
               return false;
           }
       }

        

       public void Validar()
       {
           throw new NotImplementedException();
       }
    }
}
