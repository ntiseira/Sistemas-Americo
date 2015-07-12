using ModuloSoporte;
using System.Collections.Generic;

namespace Siscont.Contabilidad
{
    /// <summary>
    /// Plan de Cuentas.
    /// </summary>
    public class Agrupacion : ClaseBaseHabilitable<long>
    {
        string mascara = "0.0.0/00/00";
        public string Mascara
        {
            get { return mascara; }
            set { mascara = value; }
        }

        IList<NivelJerarquia> niveles;
    }
}
