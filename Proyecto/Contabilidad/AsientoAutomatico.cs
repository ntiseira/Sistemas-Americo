using System;
using System.Collections.Generic;
using System.Text;

namespace Siscont.Contabilidad
{
    public class AsientoAutomatico : Asiento
    {
        private bool sistema;
        /// <summary>
        /// Indica si el asiento automático es generado por el sistema.
        /// </summary>
        public bool Sistema
        {
            get { return sistema; }
            set { sistema = value; }
        }
    }
}
