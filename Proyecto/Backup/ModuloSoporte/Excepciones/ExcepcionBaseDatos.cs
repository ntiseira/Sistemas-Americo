using System;

namespace ModuloSoporte.Excepciones
{
    public class ExcepcionBaseDatos : Exception, IExcepcionValidador
    {
        public ExcepcionBaseDatos()
            : base("Ha ocurrido un error al intentar establecer conexión con las bases de datos.")
        { }
    }
}
