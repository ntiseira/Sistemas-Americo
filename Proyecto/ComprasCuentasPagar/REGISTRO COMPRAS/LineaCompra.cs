using PhantomDb.Entidades;

namespace ComprasCuentasPagar.REGISTRO_COMPRAS
{
    [Tabla("LineaCompras")]
    public class LineaCompra
    {

      private long cod_LineaCompras;
      [Identificador(Modificable=false)]
      public long Cod_LineaCompras
        {
            get { return cod_LineaCompras; }
            set { cod_LineaCompras = value; }
        }

      private string descripcion;
      [Atributo]
      public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

      private float importe;
      [Atributo]
      public float Importe
      {
          get { return importe; }
          set { importe = value; }
      }

      private int cantidad;
      [Atributo]
      public int Cantidad
      {
          get { return cantidad; }
          set { cantidad = value; }
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
