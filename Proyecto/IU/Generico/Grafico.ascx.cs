using System;
using System.Drawing;
using System.Web.UI.WebControls;
using Ext.Net;
using IU.PanelDeControl;
using WebChart;

namespace IU.Generico
{
    public partial class Grafico : System.Web.UI.UserControl
    {

        #region propiedades
        
        private string titulo;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        private string leyenda;
        public string Leyenda
        {
            get { return leyenda; }
            set { leyenda = value; }
        }

        private string tabla;
        public string Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        #region parametros

        private string campoFechaParametro;
        public string CampoFechaParametro
        {
            get { return campoFechaParametro; }
            set { campoFechaParametro = value; }
        }

        private string campoClaveParametro;
        public string CampoClaveParametro
        {
            get { return campoClaveParametro; }
            set { campoClaveParametro = value; }
        }

        #endregion

        #endregion

        private ColumnChart chart;

        protected void Page_Load(object sender, EventArgs e)
        {
            configurarColores(Titulo);
            
            chart = new ColumnChart();
            chart.Fill.Color = Color.FromArgb(50, Color.SteelBlue);
            chart.Line.Color = Color.SteelBlue;
            chart.Line.Width = 4;
            chart.Legend = Leyenda;

            chart.DataBind();
        }

        public void agregarChartPoint(string valor1, float valor2) 
        {
            chart.Data.Add(new ChartPoint(valor1, valor2));
            ChartControl1.Charts.Add(chart);
            ChartControl1.RedrawChart();
        }

        // Configuración de Colores
        private void configurarColores(string Titulo)
        {
            ChartControl1.Background.Color = Color.FromArgb(75, Color.SteelBlue);
            ChartControl1.Background.Type = InteriorType.LinearGradient;
            ChartControl1.Background.ForeColor = Color.SteelBlue;
            ChartControl1.Background.EndPoint = new Point(500, 350);
            ChartControl1.Legend.Position = LegendPosition.Bottom;
            ChartControl1.Legend.Width = 40;

            ChartControl1.YAxisFont.ForeColor = Color.SteelBlue;
            ChartControl1.XAxisFont.ForeColor = Color.SteelBlue;

            ChartControl1.ChartTitle.Text = Titulo;
            ChartControl1.ChartTitle.ForeColor = Color.White;

            ChartControl1.Border.Color = Color.SteelBlue;
            ChartControl1.BorderStyle = BorderStyle.Ridge;
        }
       

        protected void Button_Click(object sender, EventArgs e)
        {
            try
            {

                if (FechaDesdeCombo.SelectedDate.ToString() != "" &&
                    FechaHastaCombo.SelectedDate.ToString() != "")
                {
                    FechaDesdeCombo.Visible = false;
                    FechaHastaCombo.Visible = false;
                    Button.Visible = false;

                    //almacena año en fecha auxiliar
                    string fechaAuxiliar = FechaDesdeCombo.SelectedDate.ToString().Substring(6, 4);

                    for (int indice = FechaDesdeCombo.SelectedDate.Month;
                        (indice <= FechaHastaCombo.SelectedDate.Month && FechaDesdeCombo.SelectedDate.Year <= FechaHastaCombo.SelectedDate.Year && indice < 13)
                        || (indice >= FechaHastaCombo.SelectedDate.Month && FechaDesdeCombo.SelectedDate.Year < FechaHastaCombo.SelectedDate.Year && indice < 13); 
                        indice++)
                    {
                        
                        string fecha = fechaAuxiliar+"-"+indice;
                        string query = "SELECT COUNT(" + CampoClaveParametro + ") FROM " + Tabla + 
                            " WHERE " + "YEAR(" + CampoFechaParametro + ")" + " = '" + fechaAuxiliar +
                            "' AND MONTH(" + CampoFechaParametro + ") = '" + indice + "';";
                        
                        agregarChartPoint("mes "+indice,(float)AdministradorPanelControl.darEstadistica(query));
                    }
                }
                
            }
            catch (Exception ex)
            {
                IU.UIHelper.MostrarExcepcion(ex, "Error al intentar acceder");
            }
        }



    }
}