using System;
using WebHelper;

namespace IU.VentasCuentasCobrar
{
    public partial class TipoOperacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm.Tipo = typeof(Entidades.Entity_tipoOperacion);
                this.ControlAbm.Titulo = "Gestionar tipos de operación";
                this.ControlAbm.Descripcion = "Permite administrar los tipos de operaciones de comprobantes.";
                this.ControlAbm.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ModuloSoporte.Global.CodEmpresa) 
                };
                this.ControlAbm.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
