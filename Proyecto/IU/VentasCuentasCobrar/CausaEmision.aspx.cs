using System;
using ModuloSoporte;
using WebHelper;

namespace IU.VentasCuentasCobrar
{
    public partial class CausaEmision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_causasEmision);
                this.ControlAbm1.Titulo = "Gestionar Causas de emision";
                this.ControlAbm1.Descripcion = "Permite administrar todos las causas de emision.";
                this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("empresa_idempresa", Global.CodEmpresa) };
                this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}