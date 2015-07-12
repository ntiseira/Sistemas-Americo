using System;
using System.Collections.Generic;
using System.Text;
using ModuloSoporte;
using PhantomDb.Entidades;

namespace Siscont.Contabilidad
{
    /// <summary>
    /// Unidad de medida.
    /// </summary>
    /// <example>Metro, kilómetro, etc.</example>
    public class Unidad
    {
        private int idunidad;
        [Identificador(Modificable = false)]
        [Columna("Código")]
        public int IdUnidad
        {
            get { return idunidad; }
            set { idunidad = value; }
        }

        float cotizacion;
        [Columna("Cotización")]
        public float Cotizacion
        {
            get { return cotizacion; }
            set { cotizacion = value; }
        }

        private string descripcion;
        [Identificador(Modificable = false)]
        [Columna("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private DateTime fechaVigencia;
        public DateTime FechaVigencia
        {
            get { return fechaVigencia; }
            set { fechaVigencia = value; }
        }

        private bool habilitado;
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private long codEmpresa;
        [Identificador(Modificable = false)]
        [Columna("Código de empresa", false)]
        public long Empresa_idempresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }

        public Unidad()
        {

        }
    }
}
