using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebHelper;
using IU.Contabilidad;

namespace IU.VentasCuentasCobrar
{
    public partial class TalonarioGenerico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
               this.ControlAbm1.Tipo = typeof(Entidades.Entity_talonario);
                this.ControlAbm1.Titulo = "Talonarios";
                this.ControlAbm1.MostrarFiltros = false;
                this.ControlAbm1.Descripcion = "Trabaje sobre la fila mostrada.";
                this.ControlAbm1.Valores = new SqlValor[] 
                {                    
                    new SqlValor("tiposcomprobante_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
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