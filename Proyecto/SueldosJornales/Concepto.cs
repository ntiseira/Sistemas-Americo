using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SueldosJornales
{
    /*Los conceptos pueden se aplicados a todos los empleados o simplemente a
    quienes cumplan determinadas condiciones. Por ejemplo: la Asignación por
    maternidad debe liquidarse únicamente a aquellos empleados de sexo femenino.
    O bien algunos conceptos deben participar solamente en liquidaciones a
    empleados mensualizados, etc.*/
    public class Concepto
    {

        private long codigo;
        private string descripcion;
        private long orden;


        public Concepto(long codigo, string descripcion, long orden) 
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
            this.orden = orden;
        }
    }
}
