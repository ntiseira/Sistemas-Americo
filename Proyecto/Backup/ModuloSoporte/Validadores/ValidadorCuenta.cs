using System;
using ModuloSoporte.Excepciones;

namespace ModuloSoporte.Validadores
{
    /// <summary>
    /// Valida un código de cuenta.
    /// Un código de cuenta no puede ser cero.
    /// </summary>
    public class ValidadorCuenta : IValidador
    {
        string miCodCuenta;

        public ValidadorCuenta(object codCuenta)
        {
            try
            {
                this.miCodCuenta = codCuenta.ToString();
            }
            catch
            {
                this.miCodCuenta = "";
            }
        }

        #region IValidador Members

        /// <summary>
        /// Valida el código de la cuenta.
        /// </summary>
        /// <exception cref="Excepciones.ExcepcionFormatoIncorrecto">El código <b>debe</b> ser de siete caracteres.</exception>
        /// <exception cref="Excepciones.ExcepcionFormatoIncorrecto">El código no puede ser cero.</exception>
        public void Validar()
        {
            if (this.miCodCuenta.Length != 7)
            {
                throw new Excepciones.ExcepcionFormatoIncorrecto("Formato de código de cuenta incorrecto. El código debe ser de siete dígitos.");
            }

            try
            {
                long cod = long.Parse(this.miCodCuenta);
                if(cod == 0)
                    throw new Excepciones.ExcepcionFormatoIncorrecto("Formato de código de cuenta incorrecto. El código no puede ser cero.");
            }
            catch { }
        }

        #endregion
    }
}
