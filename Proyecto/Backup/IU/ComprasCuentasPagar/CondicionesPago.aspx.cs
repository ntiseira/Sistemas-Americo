using System;
using WebHelper;
using ModuloSoporte;

namespace IU.ComprasCuentasPagar
{
    public partial class CondicionesPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_CondicionPago);
                this.ControlAbm1.Titulo = "Gestionar condiciones de pago";
                this.ControlAbm1.Descripcion = "Permite administrar las condiciones de pago.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Compras_proveedores_empresa_idempresa", Global.CodEmpresa)
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
