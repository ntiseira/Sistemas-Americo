using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using ModuloSoporte;
using WebHelper;

namespace IU.VentasCuentasCobrar.Comprobantes
{
    public partial class TiposComprobante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm.Tipo = typeof(Entidades.Entity_tiposcomprobante);
                this.ControlAbm.Titulo = "Gestionar tipos de comprobantes";
                this.ControlAbm.Descripcion = "Permite administrar los diferentes tipos de comprobantes de la empresa "+Global.NombreEmpresa+".";
                this.ControlAbm.Valores = new SqlValor[] 
                {
                    new SqlValor("Empresa_idempresa",Global.CodSucursal)
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
