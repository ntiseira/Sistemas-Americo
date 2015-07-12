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

namespace IU.PanelDeControl.Estadisticas.EstadisticasDeCompras
{
    public partial class EstadisticasClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GraficoConFiltro1.Titulo = "Estadísticas de Clientes";
            GraficoConFiltro1.Tabla = typeof(Entidades.Entity_cliente);
            GraficoConFiltro1.CampoClaveParametro = "codCliente";
            GraficoConFiltro1.CampoFiltroParametro = "localidad";
        }
    }
}
