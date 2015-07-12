using System;
using System.ComponentModel;
using System.Globalization;
using ModuloSoporte.Excepciones;
using ModuloSoporte.Validadores;
using PhantomDb.Entidades;


namespace Siscont.Contabilidad
{
    [Tabla("cuenta")]
    public class DbCuenta
    {
        private int idcuenta;
        [Identificador(Modificable = false)]
        public int Idcuenta
        {
            get { return idcuenta; }
            set { idcuenta = value; }
        }

        private string descripcion;
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

        private int columnaImpresion;
        public int ColumnaImpresion
        {
            get { return columnaImpresion; }
            set { columnaImpresion = value; }
        }


        private string capitulo;
        [Columna("Capítulo")]
        public string Capitulo
        {
            get { return capitulo; }
            set { capitulo = value; }
        }

        private bool imputable;
        /// <summary>
        /// Indica si la cuenta puede participar de un asiento.
        /// </summary>
        public bool Imputable
        {
            get { return imputable; }
            set { imputable = value; }
        }

        private string tipocuenta_descripcion;
        /// <summary>
        /// Tipo de cuenta.
        /// </summary>
        [Columna("Tipo de cuenta")]
        public string Tipocuenta_descripcion
        {
            get { return tipocuenta_descripcion; }
            set { tipocuenta_descripcion = value; }
        }

        private int unidad_idunidad;
        public int Unidad_idunidad
        {
            get { return unidad_idunidad; }
            set { unidad_idunidad = value; }
        }

        private int ejercicio_codEjercicio;
        [Identificador(Modificable=false)]
        public int Ejercicio_codEjercicio
        {
            get { return ejercicio_codEjercicio; }
            set { ejercicio_codEjercicio = value; }
        }

        private int ejercicio_empresa_idempresa;
        [Identificador(Modificable = false)]
        public int Ejercicio_empresa_idempresa
        {
            get { return ejercicio_empresa_idempresa; }
            set { ejercicio_empresa_idempresa = value; }
        }

        private int planCuentas_codPlanCuentas;
        public int PlanCuentas_codPlanCuentas
        {
            get { return planCuentas_codPlanCuentas; }
            set { planCuentas_codPlanCuentas = value; }
        }

        private int planCuentas_ejercicio_codEjercicio;
        public int PlanCuentas_ejercicio_codEjercicio
        {
            get { return planCuentas_ejercicio_codEjercicio; }
            set { planCuentas_ejercicio_codEjercicio = value; }
        }

        private int planCuentas_ejercicio_empresa_idempresa;
        public int PlanCuentas_ejercicio_empresa_idempresa
        {
            get { return planCuentas_ejercicio_empresa_idempresa; }
            set { planCuentas_ejercicio_empresa_idempresa = value; }
        }
    }
}
