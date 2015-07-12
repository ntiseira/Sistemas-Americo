using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace SueldosJornales
{
    /*Los Conceptos a liquidar: como ser p.ej.: Sueldo básico, Horas extras,
    Retención Jubilatoria, etc. Este punto se verá en detalle más adelante.*/

    [Tabla("ConceptoLiquidar")]
    public class ConceptoLiquidar
    {

        private string codigo;
        [Identificador(Autogenerado = true)]
        [Columna("Código")]
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private float porcentaje;
        [Columna("Porcentaje")]
        public float Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        private string tipoconcepto_codigo;
        [Columna("Tipo de Concepto")]
        [Relacion(Destino = typeof(TipoConcepto), CampoId = 0, CampoSecundario = 1)]
        public string Tipoconcepto_codigo
        {
            get { return tipoconcepto_codigo; }
            set { tipoconcepto_codigo = value; }
        }

        private bool habilitado;
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private long empresa_idempresa;
        [Identificador(Modificable = false)]
        [Columna("Empresa", false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }

        private long liquidacion_codigo;
        [Relacion(Destino = typeof(Entidades.Entity_Liquidacion), CampoId = 0, CampoSecundario = 0)]
        [Columna("Código de Liquidación")]
        public long Liquidacion_codigo
        {
            get { return liquidacion_codigo; }
            set { liquidacion_codigo = value; }
        }



    }
}
