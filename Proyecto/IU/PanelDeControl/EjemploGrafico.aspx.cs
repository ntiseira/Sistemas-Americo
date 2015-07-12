using System;
using WebChart;
using System.Drawing;

namespace IU.PanelDeControl
{
    public partial class EjemploGrafico : System.Web.UI.Page
    {
        private Chart charts;
        public Chart Charts
        {
            get { return charts; }
            set { charts = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            cargarEjemplo();
            //Grafico1.agregarChartPoint("aaaaaa", 111111);
        }

        private void cargarEjemplo()
        {
            ColumnChart chart = new ColumnChart();
            chart.Fill.Color = Color.FromArgb(50, Color.SteelBlue);
            chart.Line.Color = Color.SteelBlue;
            chart.Line.Width = 4;

            chart.Legend = "Compras por mes";
            chart.Data.Add(new ChartPoint("Ene", 10));
            chart.Data.Add(new ChartPoint("Feb", 20));
            chart.Data.Add(new ChartPoint("Mar", 14));
            chart.Data.Add(new ChartPoint("Abr", 30));
            chart.Data.Add(new ChartPoint("May", 18));
            chart.Data.Add(new ChartPoint("Jun", 7));
            chart.Data.Add(new ChartPoint("Jul", 8));
            chart.Data.Add(new ChartPoint("Ago", 18));
            chart.Data.Add(new ChartPoint("Sep", 24));
            chart.Data.Add(new ChartPoint("Oct", 30));
            chart.Data.Add(new ChartPoint("Nov", 17));
            chart.Data.Add(new ChartPoint("Dic", 5));
        }
    }
}
