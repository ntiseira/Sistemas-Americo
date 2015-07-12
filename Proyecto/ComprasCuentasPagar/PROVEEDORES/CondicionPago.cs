using System;
using PhantomDb.Entidades;

namespace ComprasCuentasPagar.PROVEEDORES
{
   [Tabla("CondicionPago")]
   public class CondicionPago
    {

        private int cod_condicionPago;
        [Identificador(Modificable = false)]
        public int Cod_condicionPago
        {
            get { return cod_condicionPago; }
            set { cod_condicionPago = value; }
        }

        private string descripcion;
        [Atributo]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int tipoCondicion;
        [Atributo]
        public int TipoCondicion
        {
            get { return tipoCondicion; }
            set { tipoCondicion = value; }
        }

        private bool cantDiasVencimiento;
        [Atributo]
        public bool CantDiasVencimiento
        {
            get { return cantDiasVencimiento; }
            set { cantDiasVencimiento = value; }
        }

        private DateTime fechaVencimiento;
        [Atributo]
        public DateTime FechaVencimiento
        {
            get { return fechaVencimiento; }
            set { fechaVencimiento = value; }
        }

        private bool anticipo;
        [Atributo]
        public bool Anticipo
        {
            get { return anticipo; }
            set { anticipo = value; }
        }

        private int cantCuotas;
        [Atributo]
        public int CantCuotas
        {
            get { return cantCuotas; }
            set { cantCuotas = value; }
        }

        private string observaciones;
        [Atributo]
        public string Observaciones
        {
            get { return observaciones; }
            set { observaciones = value; }
        }

        private long compras_cod_Compra;
        [Identificador(Modificable = false)]
        public long Compras_cod_Compra
        {
            get { return compras_cod_Compra; }
            set { compras_cod_Compra = value; }
        }

        private long compras_Proveedores_cod_proveedor;
        [Identificador(Modificable = false)]
        public long Compras_Proveedores_cod_proveedor
        {
            get { return compras_Proveedores_cod_proveedor; }
            set { compras_Proveedores_cod_proveedor = value; }
        }

        private long compras_Proveedores_empresa_idempresa;
        [Identificador(Modificable = false)]
        public long Compras_Proveedores_empresa_idempresa
        {
            get { return compras_Proveedores_empresa_idempresa; }
            set { compras_Proveedores_empresa_idempresa = value; }
        }

    }//clase
}//namespace
