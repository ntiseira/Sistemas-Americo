using System;
using ModuloSoporte;
using PhantomDb.Entidades;

namespace Siscont.Contabilidad
{
    /// <summary>
    /// Son usados para clasificar los pases de los asientos y sirven como 
    /// filtro en el Sistema de Confección de balances.
    /// </summary>
    /// <example>
    /// Ejemplos: altas, amortizaciones, bajas, modificaciones, transferencias.
    /// </example>
    public class TipoMovimiento
    {
        private string descripcion;
        [Identificador(Modificable = false)]
        [Columna("Descripción")]
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

        private long codEmpresa;
        [Identificador(Modificable = false, Nombre = "empresa_idempresa")]
        [Columna("Código de empresa", false)]
        public long CodEmpresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }
    }
}
