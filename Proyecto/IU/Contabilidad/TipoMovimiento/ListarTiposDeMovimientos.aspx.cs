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

namespace IU.Contabilidad.TipoMovimiento
{
    public partial class ListarTiposDeMovimientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ControlListar1.DataSource = IU.Contabilidad.ContabilidadGlobal.Admin.ObtenerListaTiposMovimientos();
            ControlListar1.OnShow();
        }
    }
}
