using Siscont.AdministradorGeneral.Tablas;

#warning CLASE INCOMPLETA, ver pág. 61.

namespace Siscont.Contabilidad
{
    public class CuentaImputable : Cuenta
    {
        string codOptativo;
        /// <summary>
        /// Código optativo, diseñado para facilitar la carga de asientos 
        /// utilizando un código de menor cantidad de caracteres que el 
        /// original de la cuenta.
        /// </summary>
        public string CodOptativo
        {
            get { return codOptativo; }
            set { codOptativo = value; }
        }

        string leyendaDebe;
        /// <summary>
        /// Texto que aparecerá en la leyenda de los asientos "debe".
        /// </summary>
        public string LeyendaDebe
        {
            get { return leyendaDebe; }
            set { leyendaDebe = value; }
        }

        string leyendaHaber;
        /// <summary>
        /// Texto que aparecerá en la leyenda de los asientos "haber".
        /// </summary>
        public string LeyendaHaber
        {
            get { return leyendaHaber; }
            set { leyendaHaber = value; }
        }

        Moneda moneda;
        /// <summary>
        /// Moneda que utiliza la cuenta.
        /// </summary>
        public Moneda Moneda
        {
            get { return moneda; }
            set { moneda = value; }
        }

        Unidad unidad;
        /// <summary>
        /// Unidad.
        /// </summary>
        public Unidad Unidad
        {
            get { return unidad; }
            set { unidad = value; }
        }

        bool monetaria;
        /// <summary>
        /// Indica si la cuenta se clasifica entre las monetarias a efecto 
        /// de la inflación.
        /// </summary>
        public bool Monetaria
        {
            get { return monetaria; }
            set { monetaria = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public CuentaImputable()
        {

        }
    }
}
