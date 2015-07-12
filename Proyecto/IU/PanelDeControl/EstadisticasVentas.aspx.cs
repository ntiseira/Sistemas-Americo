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

namespace IU.PanelDeControl
{
    public partial class EstadisticasVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Grafico1.Titulo = "Estadísticas de Ventas Mensuales";
            Grafico1.Tabla = "venta";
            Grafico1.CampoClaveParametro = "total";
            Grafico1.CampoFechaParametro = "fecha";
            Grafico1.Leyenda = "Cant. de ventas por mes";
        }
    }
}
