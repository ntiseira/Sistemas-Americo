using System;
using ModuloSoporte.Excepciones;

namespace ModuloSoporte.Validadores
{
    /// <summary>
    /// Valida un código de cuenta.
    /// Un código de cuenta no puede ser cero.
    /// </summary>
    public class ValidadorUsuario : IValidador
    {
        string usuario;

        public ValidadorUsuario(string usuario)
        {
            try
            {
                this.usuario = usuario;
            }
            catch
            {
                this.usuario = "";
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
            if (this.usuario.Contains("'") || this.usuario.Contains("="))
            {
                throw new Excepcion("Se han encontrado caracteres inválidos en el campo de usuarios.");
            }
            //if (!Regex.IsMatch(usuario, @"^[a-zA-Z'./s]{1,20}$"))
            //{
            //    throw new Excepcion("Se han encontrado caracteres inválidos en el campo de usuarios.");
            //}
        }

        #endregion
    }
}
