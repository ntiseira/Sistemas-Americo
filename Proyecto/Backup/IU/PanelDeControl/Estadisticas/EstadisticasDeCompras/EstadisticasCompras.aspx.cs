using System;

namespace IU.PanelDeControl.EstadisticasDeCompras
{
    public partial class EstadisticasCompras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Grafico1.Titulo = "Estadísticas de Compras Mensuales";
            Grafico1.Tabla = "Compras";
            Grafico1.CampoClaveParametro = "total";
            Grafico1.CampoFechaParametro = "fecha";
            Grafico1.Leyenda = "Cant. de compras por mes";
        }
    }
}
