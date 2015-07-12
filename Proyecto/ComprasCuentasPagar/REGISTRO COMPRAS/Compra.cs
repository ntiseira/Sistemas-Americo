using System;
using PhantomDb.Entidades;

namespace ComprasCuentasPagar.REGISTRO_COMPRAS
{
    [Tabla("Compras")]
    public class Compra
    {
        private long cod_Compra;
        [Identificador(Modificable = false)]
        public long Cod_Compra
        {
            get { return cod_Compra; }
            set { cod_Compra = value; }
        }

        private DateTime fecha;
        [Atributo]
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }


        private long proveedores_cod_proveedor;
        [Identificador(Modificable = false)]
        public long Proveedores_cod_proveedor
        {
            get { return proveedores_cod_proveedor; }
            set { proveedores_cod_proveedor = value; }
        }

        private long proveedores_empresa_idempresa;
        [Identificador(Modificable = false)]
        public long Proveedores_empresa_idempresa
        {
            get { return proveedores_empresa_idempresa; }
            set { proveedores_empresa_idempresa = value; }
        }

    }
}
