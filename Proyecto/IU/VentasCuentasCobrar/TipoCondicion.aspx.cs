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
using MySql.Data;
using WebHelper;
using VentasCuentasCobrar.FACTURACION;

namespace IU.VentasCuentasCobrar
{
    public partial class TipoCondicion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // harcodeado el CodEmpresa
            this.ControlAbm.Tipo = typeof(TipoCondicionVenta);
            this.ControlAbm.Titulo = "Gestionar Tipos de condiciones de venta";
            this.ControlAbm.Descripcion = "Permite administrar los tipos de condiciones de venta.";
            this.ControlAbm.Valores = new SqlValor[] { new SqlValor("empresa_idempresa", long.Parse("1")) };
            this.ControlAbm.OnShow();
        }
    }
}
