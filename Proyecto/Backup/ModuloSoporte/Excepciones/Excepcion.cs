using System;

namespace ModuloSoporte.Excepciones
{
    public class Excepcion : Exception, IExcepcionValidador
    {
        public Excepcion(string mensaje)
            : base(mensaje)
        {

        }
    }
}
