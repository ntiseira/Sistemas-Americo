using System;
using PhantomDb.Entidades;
using Entidades;
using Traductor;

namespace Siscont.Contabilidad
{
    public class Movimiento
    {
        Entity_movimiento datos;
        public Entity_movimiento Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        /// <summary>
        /// Código de identificación.
        /// </summary>
        public int Cod
        {
            get { return Datos.Idmovimiento; }
            set { Datos.Idmovimiento = value; }
        }

        /// <summary>
        /// Indica si es un movimiento de "debe" o de "haber".
        /// True - Haber
        /// False - Debe
        /// </summary>
        public bool DebeHaber
        {
            get { return Datos.Debehaber; }
            set { Datos.Debehaber = value; }
        }

        /// <summary>
        /// Leyenda.
        /// </summary>
        public string Leyenda
        {
            get { return Datos.Leyenda; }
            set { Datos.Leyenda = value; }
        }

        /// <summary>
        /// Monto del debe o haber.
        /// </summary>
        public float Monto
        {
            get { return (float)Datos.Monto; }
            set { Datos.Monto = (float)value; }
        }

        public string Descripcion
        {
            get { return Datos.Descripcion; }
            set { Datos.Descripcion = value; }
        }

        /// <summary>
        /// Obtiene o establece el "debe" del pase, poniendo el haber en cero.
        /// </summary>
        [IgnorarAtributo]
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
        [IgnorarAtributo]
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
        /// Cuenta a la que corresponde el movimiento.
        /// </summary>
        [IgnorarAtributo]
        public Cuenta Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

        /// <summary>
        /// Obtiene una línea para mostrar en el libro diario.
        /// </summary>
        public LineaLibroDiario GetLineaLibroDiario()
        {
            return new LineaLibroDiario
            {
                Cuenta = this.Datos.Cuenta_idcuenta,     /* Cuenta */
                Descripcion = this.Datos.Descripcion,         /* Descripción */
                Debe = this.Debe.ToString(),                      /* Debe */
                Haber = this.Haber.ToString(),                     /* Haber */
                Leyenda = this.Leyenda                    /* Leyenda */
            };
        }
        /// <summary>
        /// Constructor.
        /// </summary>
        public Movimiento()
        {
            Datos = new Entity_movimiento();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Movimiento(Entity_movimiento datos)
        {
            Datos = datos;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Movimiento(PreMovimiento prem)
        {
            Datos = new Entity_movimiento
                {
                    Descripcion = prem.Descripcion,
                    Leyenda = prem.Leyenda,
                    Monto = float.Parse(prem.Debe) >0 ? float.Parse(prem.Debe):float.Parse(prem.Haber),
                    Debehaber = (float.Parse(prem.Debe) == 0),
                    Cuenta_idcuenta = prem.Cuenta,
                    Tipomovimiento_descripcion = prem.Tipo
                };
        }

        public static string ObtenerValorFormateado(int entero, int dec)
        {
            return string.Format("{0}{1}{2}", entero, TraductorHelper.GetSeparador(), dec);
        }

    }
}
