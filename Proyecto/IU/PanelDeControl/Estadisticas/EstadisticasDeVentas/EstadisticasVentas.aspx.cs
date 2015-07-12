using System;

namespace IU.PanelDeControl
{
    public partial class EstadisticasVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Grafico1.Titulo = "Estadísticas de Ventas Mensuales";
            Grafico1.Tabla = "comprobantesventa";
            Grafico1.CampoClaveParametro = "idcomprobantesventa";
            Grafico1.CampoFechaParametro = "fecha";
            Grafico1.Leyenda = "Cant. de ventas por mes";

            Grafico1.DataBind();
        }
    }
}
