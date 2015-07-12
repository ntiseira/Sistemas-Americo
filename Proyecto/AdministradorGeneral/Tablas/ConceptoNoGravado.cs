using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

namespace AdministradorGeneral.Tablas
{
    public class ConceptoNoGravado
    {
        Entity_conceptonoiva datos = null;
        public Entity_conceptonoiva Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        public ConceptoNoGravado()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tei">Tasa efectiva de iva.</param>
        /// <param name="tiva">Tasa de iva. De cero a cien.</param>
        /// <param name="iva">Importe de iva.</param>
        /// <param name="total">Importe total.</param>
        /// <returns></returns>
        public float ImporteNoGravadoFromTasaEfectivaSobreTotal(float tei, float tiva, float iva, float total) 
        {
            return total - ((iva * 100) / tiva) - (tei * total) / 100;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tasa">Tasa de cero a cien.</param>
        /// <param name="total">Total de importe.</param>
        /// <returns></returns>
        public float ImporteNoGravadoFromTasaSobreNeto(float tasa, float total)
        {
            return total * tasa / 100;
        }

    }
}
