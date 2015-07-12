using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SueldosJornales
{
    /*las escalas del Impuesto a las Ganancias
    correspondientes a los distintos períodos mensuales para la respectiva
    retención.*/
    public class ImpuestoGanancia
    {

        private string codigo;
        private string periodo;
        private float gananciaDesde;
        private float gananciaHasta;
        private float montoFijo;
        private float porcentaje;
        private float excedente;

        public ImpuestoGanancia(string cod, string peri, float ganD, float ganH, float mont, float porcent, float exce)
        {
            this.codigo = cod;
            this.periodo = peri;
            this.gananciaDesde = ganD;
            this.gananciaHasta = ganH;
            this.montoFijo = mont;
            this.porcentaje = porcent;
            this.excedente = exce;
        }
    }
}

/*

 * Período: debe indicarse el período al cual se refiere el rango de la escala
que se está definiendo. Cada período corresponde unívocamente con un
mes calendario. Enero es el período 1, febrero el 2, marzo el 3 y así sucesivamente.
Este campo sólo acepta números del 1 al 12.

 * Ganancia Desde: indicar el monto con el cual comienza el rango que se define, para
el respectivo período.

 * Ganancia Hasta: se debe indicar el monto con el cual finaliza el rango.

 * Monto fijo: es el monto constante que corresponde al rango y que suma en
la determinación del tributo a retener.
Porcentaje: indicar el porcentaje a aplicar sobre el excedente de la cifra
que se indica en el campo siguiente para la determinación del tributo a
retener.

 * Excedente: el porcentaje del campo anterior se calculará sobre el monto
que supere a la cifra que se indique en este campo.
 
*/