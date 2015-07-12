using System;
using System.ComponentModel;
using System.Globalization;
using ModuloSoporte.Excepciones;
using ModuloSoporte.Validadores;
using PhantomDb.Entidades;

#warning Tener cuidado al eliminar una cuenta.

namespace Siscont.Contabilidad
{
    public class Cuenta
    {
        private static string formatoCodCuenta = "0.0.0/00/00";
        public static string FormatoCodCuenta
        {
            get { return Cuenta.formatoCodCuenta; }
            set { Cuenta.formatoCodCuenta = value; }
        }

        private int idcuenta;
        public int Idcuenta
        {
            get { return idcuenta; }
            set { idcuenta = value; }
        }

        private string codCuenta;
        /// <summary>
        /// Código de siete dígitos. El formato de salida será: #.#.#/##/##. Este
        /// de igual manera puede ser modificado.
        /// </summary>
        /// <example>
        /// Ejemplo de uso:
        /// <code>
        /// Cuenta c = new Cuenta();
        /// c.CodCuenta = "1234567";
        /// </code>
        /// </example>
        /// <exception cref="Excepciones.ExcepcionFormatoIncorrecto">Excepción en caso de formato incorrecto.</exception>
        public string CodCuenta
        {
            get 
            {
                MaskedTextProvider masker = new MaskedTextProvider(Cuenta.FormatoCodCuenta, CultureInfo.InvariantCulture);
                if (!masker.Set(codCuenta))
                    throw new ExcepcionFormatoIncorrecto("Error al intentar dar formato al código de la cuenta.");
                return masker.ToDisplayString(); 
            }
            set 
            {
                codCuenta = value;
                ValidadorCuenta validador = new ValidadorCuenta(this.codCuenta);
                validador.Validar();
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private bool habilitado;
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private int columnaImpresion;
        public int ColumnaImpresion
        {
            get { return columnaImpresion; }
            set { columnaImpresion = value; }
        }

        private Capitulo capitulo;
        /// <summary>
        /// Capítulo de la cuenta dentro de los listados.
        /// </summary>
        public Capitulo Capitulo
        {
            get { return capitulo; }
            set { capitulo = value; }
        }

        private bool imputable;
        /// <summary>
        /// Indica si la cuenta puede participar de un asiento.
        /// </summary>
        public bool Imputable
        {
            get { return imputable; }
            set { imputable = value; }
        }

        private bool ultimoNivel;
        /// <summary>
        /// Último nivel de detalle.
        /// Para más información ver el descripción en el modelo de análisis.
        /// </summary>
        public bool UltimoNivel
        {
            get { return ultimoNivel; }
            set { ultimoNivel = value; }
        }

        private TipoCuenta tipoCuenta;
        /// <summary>
        /// Tipo de cuenta.
        /// </summary>
        public TipoCuenta TipoCuenta
        {
            get { return tipoCuenta; }
            set { tipoCuenta = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Cuenta()
        {
        }

        /// <summary>
        /// Setea el código de la cuenta. 
        /// </summary>
        /// <remarks><b>Nota: No es el código autonumérico.</b></remarks>
        /// <param name="cod"></param>
        public void SetCodCuenta(long cod)
        {
            this.CodCuenta = cod.ToString();
        }
    }
}
