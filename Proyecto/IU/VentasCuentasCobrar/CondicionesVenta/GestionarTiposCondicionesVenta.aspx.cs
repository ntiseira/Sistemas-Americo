using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.VentasCuentasCobrar.CondicionesVenta
{
    public partial class GestionarTiposCondicionesVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_tipocondicionventa);
                this.ControlAbm1.Titulo = "Gestionar tipos de condiciones de venta";
                this.ControlAbm1.Descripcion = "Permite administrar los tipos de condiciones de venta.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
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
