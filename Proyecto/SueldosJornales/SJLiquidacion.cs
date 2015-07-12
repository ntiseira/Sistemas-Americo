using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace SueldosJornales
{
    [Tabla("Liquidacion")]
    public class SJLiquidacion
    {

        private string codigo;
        [Identificador(Autogenerado = true)]
        [Columna("Código")]
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private DateTime fechaLiquidacion;
        [Atributo]
        public DateTime FechaLiquidacion
        {
            get { return fechaLiquidacion; }
            set { fechaLiquidacion = value; }
        }

        private DateTime fechaGanancias;
        [Atributo]
        public DateTime FechaGanancias
        {
            get { return fechaGanancias; }
            set { fechaGanancias = value; }
        }

        private string descripcion;
        [Atributo]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string tipoLiquidacion;//sueldo o jornal
        [Atributo]
        public string TipoLiquidacion
        {
            get { return tipoLiquidacion; }
            set { tipoLiquidacion = value; }
        }

        private string estado; //No liquidada, Liquidada parcialmente, totalmente, cerrada
        [Atributo]
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private string empresa_idempresa;
        [Identificador(Modificable = false)]
        [Columna("Código de Empresa", false)]
        public string Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }

    }
}
