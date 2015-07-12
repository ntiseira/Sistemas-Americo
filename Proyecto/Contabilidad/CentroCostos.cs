using System;
using PhantomDb.Entidades;

#warning El centro de costos no debe perder el Dpto y el Area, por más de que se eliminen.

namespace Siscont.Contabilidad
{
    /// <summary>
    /// Centros de costos entre los cuales se distribuirá el importe de los movimientos.
    /// </summary>
    public class CentroCostos
    {
        private int cod;
        [Identificador(Modificable = false, Nombre="idcentrocostos")]
        [Columna("Código")]
        public int Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        private string descripcion;
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

        Departamento dpto;
        [IgnorarAtributo]
        public Departamento Dpto
        {
            get { return dpto; }
            set { dpto = value; }
        }

        Area area;
        [IgnorarAtributo]
        public Area Area
        {
            get { return area; }
            set { area = value; }
        }

        private long codEmpresa;
        [Identificador(Modificable = false, Nombre="empresa_idempresa")]
        [Columna("Código de empresa", false)]
        public long CodEmpresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }

        public CentroCostos()
        {

        }
    }
}
