using System;

namespace ModuloSoporte.Excepciones
{
    public class ExcepcionFormatoIncorrecto : Exception, IExcepcionValidador
    {
        public ExcepcionFormatoIncorrecto(string mensaje)
            : base(mensaje)
        { }
    }
}
