using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.VentasCuentasCobrar.CondicionesVenta
{
    public partial class GestionarCondicionesVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_condicionesventa);
                this.ControlAbm1.Titulo = "Gestionar condiciones de venta";
                this.ControlAbm1.Descripcion = "Permite administrar las condiciones de una venta.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) ,
                    new SqlValor("Tipocondicionventa_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) ,
                    new SqlValor("Descuentosfinancieros_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
                };
                this.ControlAbm1.ValoresCombo = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                    new SqlValor("Habilitado", true) 
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
