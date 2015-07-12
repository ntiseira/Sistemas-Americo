using System;

namespace Siscont.Contabilidad
{
    public class Pase
    {
        long cod;
        /// <summary>
        /// Código de identificación.
        /// </summary>
        public long Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        bool debeHaber;
        /// <summary>
        /// Indica si es un pasa de "debe" o de "haber".
        /// True - Haber
        /// False - Debe
        /// </summary>
        public bool DebeHaber
        {
            get { return debeHaber; }
            set { debeHaber = value; }
        }

        string leyenda;
        /// <summary>
        /// Leyenda.
        /// </summary>
        public string Leyenda
        {
            get { return leyenda; }
            set { leyenda = value; }
        }

        float monto;
        /// <summary>
        /// Monto del debe o haber.
        /// </summary>
        public float Monto
        {
            get { return monto; }
            set { monto = value; }
        }

        /// <summary>
        /// Obtiene o establece el "debe" del pase, poniendo el haber en cero.
        /// </summary>
        public float Debe
        {
            get
            {
                return DebeHaber ? 0.0f : Monto;
            }

            set
            {
                Monto = value;
                DebeHaber = false;
            }
        }

        /// <summary>
        /// Obtiene o establece el "haber" del pase, poniendo al debe en cero.
        /// </summary>
        public float Haber
        {
            get
            {
                return DebeHaber ? Monto : 0.0f;
            }

            set
            {
                Monto = value;
                DebeHaber = true;
            }
        }

        Cuenta cuenta;
        /// <summary>
        /// Cuenta a la que corresponde el pase.
        /// </summary>
        public Cuenta Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Pase()
        {

        }
    }
}
