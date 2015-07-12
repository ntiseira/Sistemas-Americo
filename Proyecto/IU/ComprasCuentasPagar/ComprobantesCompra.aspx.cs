using System;
using WebHelper;
using ModuloSoporte;

namespace IU.ComprasCuentasPagar
{
    public partial class ComprobantesCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_ComprobanteCompra);
                this.ControlAbm1.Titulo = "Gestionar comprobantes de compra";
                this.ControlAbm1.Descripcion = "Permite administrar los comprobantes de compra.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Sucursal_codigosucursal", Global.CodSucursal), 
                    new SqlValor("Sucursal_empresa_idempresa", Global.CodEmpresa), 
                    new SqlValor("Compras_proveedores_empresa_idempresa", Global.CodEmpresa), 
                    new SqlValor("Proveedores_empresa_idempresa", Global.CodEmpresa) 
                };
                this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
