using System;
using ModuloSoporte;
using System.Collections;

#warning Revisar validador

namespace AdministradorGeneral.Validadores
{
    /// <summary>
    /// Valida un código de CUIT.
    /// </summary>
    public class ValidadorCuit : IValidador
    {
        string CUIT;

        public ValidadorCuit(string cuit)
        {
            this.CUIT = cuit;
        }

        #region IValidador Members

       

        public void Validar(string CUIT)
        {
        //realmente va asi, corregir
         
        }
            


        public void Validar()
        {
        
/*
            ArrayList coeficiente = new ArrayList();
            int i = 0;
            int sumador = 0;
            int veri_nro = 0;
            int resultado = 0;
            string cuit_temp = null;
            coeficiente.Add(5);
            coeficiente.Add(4);
            coeficiente.Add(3);
            coeficiente.Add(2);
            coeficiente.Add(7);
            coeficiente.Add(6);
            coeficiente.Add(5);
            coeficiente.Add(4);
            coeficiente.Add(3);
            coeficiente.Add(2);
            CUIT = String.Trim(CUIT); 
            cuit_temp = "";

            for (i = 1; i <= Strings.Len(CUIT); i++)
            {
                //separo cualquier caracter que no tenga que ver con numeros
                if (Strings.Asc(Strings.Mid(CUIT, i, 1)) >= 48 & Strings.Asc(Strings.Mid(CUIT, i, 1)) <= 57)
                {
                    cuit_temp = cuit_temp + Strings.Mid(CUIT, i, 1);
                }
            }
            cuit_temp = Strings.Trim(cuit_temp);
            if (Strings.Len(cuit_temp) != 11)
            {
                // si to estan todos los digitos
                Interaction.MsgBox("No están todos los dígitos. ", Constants.vbDefaultButton1, "Error en el C.U.I.T.");
            }
            else
            {
                sumador = 0;
                int verificador = (int)Conversion.Val(Strings.Mid(cuit_temp, 11, 1));
                //tomo el digito verificador
                for (i = 0; i <= 9; i++)
                {
                    sumador = sumador + (int)Strings.Mid(cuit_temp, i + 1, 1) * (int)coeficiente.Item(i);
                }
                //separo cada digito y lo multiplico por el coeficiente
                resultado = sumador % 11;
                resultado = 11 - resultado;
                //saco el digito verificador
                if ((resultado == 11)) resultado = 0;
                veri_nro = verificador;
                if (veri_nro != resultado)
                {
                    Interaction.MsgBox("No coincide el dígito verificador. " + Conversion.Str(verificador), Constants.vbDefaultButton1, "Error en el C.U.I.T.");
                }
                else
                {
                    cuit_temp = Strings.Mid(cuit_temp, 1, 2) + "-" + Strings.Mid(cuit_temp, 3, 8) + "-" + Strings.Mid(cuit_temp, 11, 1);
                }
            }
         //   return cuit_temp;*/
        }

        #endregion



    }//Clase
    
}//namespace
