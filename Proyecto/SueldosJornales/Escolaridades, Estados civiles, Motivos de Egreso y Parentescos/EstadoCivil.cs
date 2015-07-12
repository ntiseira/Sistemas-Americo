using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SueldosJornales.Escolaridades__Estados_civiles__Motivos_de_Egreso_y_Parentescos
{
    /*Cada elemento de esta tabla representa los distintos estados civiles que luego
    se relacionarán con cada legajo. P.ej.: Casado/a, Soltero/a, etc.*/
    public class EstadoCivil
    {

        private string codigo;
        private string estadoCivil;

        public EstadoCivil(string codigo, string estadoCivil) 
        {
            this.codigo = codigo;
            this.estadoCivil = estadoCivil;
        }
    }
}
