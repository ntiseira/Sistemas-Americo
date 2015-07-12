using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SueldosJornales.Escolaridades__Estados_civiles__Motivos_de_Egreso_y_Parentescos
{
    public class Egreso
    {

        private string codigo;
        private string descripcion;
        private int codResolucion551_97;
        private bool habilitado;

        public Egreso(string codigo, string descripcion, int codResolucion551_97) 
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.codResolucion551_97 = codResolucion551_97;
            this.habilitado = true;
        }


    }
}
