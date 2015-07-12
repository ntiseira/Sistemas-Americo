using System;

namespace ModuloSoporte.Excepciones
{
    public sealed class ExcepcionCampoVacio : Exception, IExcepcionValidador
    {
        string campo;
        /// <summary>
        /// Campo que se encuentra vacío.
        /// </summary>
        public string Campo
        {
            get { return campo; }
            private set { campo = value; }
        }

        public override string Message
        {
            get
            {
                if (Campo.Equals(""))
                {
                    return "Error, se ha encontrado un campo obligatorio vacío.";
                }
                else
                {
                    return String.Format("Por favor, rellene el campo obligatorio \"{0}\".", Campo);
                }
            }
        }

        public ExcepcionCampoVacio()
            : this("")
        { }

        public ExcepcionCampoVacio(string campo)
        {
            Campo = campo;
        }
    }
}
