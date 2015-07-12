using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.UI.WebControls;
using Ext.Net;
using PhantomDb.Entidades;
using WebChart;
using WebHelper;

namespace IU.Generico
{
    public partial class GraficoConFiltro : System.Web.UI.UserControl
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

        private Type tabla;
        public Type Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        #region parametros

        private string campoFiltroParametro;
        public string CampoFiltroParametro
        {
            get { return campoFiltroParametro; }
            set { campoFiltroParametro = value; }
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
        private WebHelper.Storer st;

        protected void Page_Load(object sender, EventArgs e)
        {
            configurarColores(Titulo);

            st = new WebHelper.Storer(Tabla);
           
            cargarFiltros(st);
            chart = new ColumnChart();
            chart.Fill.Color = Color.FromArgb(50, Color.SteelBlue);
            chart.Line.Color = Color.SteelBlue;
            chart.Line.Width = 4;
            chart.Legend = Leyenda;

            chart.DataBind();
        }

        protected void Button_Click(object sender, EventArgs e)
        {
            string name = CampoFiltro.Text;
            Atributos a = st.GetAtributosFromColumna(name);
            string valor = ValorFiltro.Text;
            GridFilter gf = Storer.GetFilter(GridFilters1, a.Nombre);
            try
            {
                switch (Storer.GetBasicType(a.Tipo))
                {
                    case WebHelper.Storer.BasicType.Number:
                        {
                            NumericFilter filtro = (NumericFilter)gf;
                            filtro.SetValue(float.Parse(valor));
                        }
                        break;
                    case WebHelper.Storer.BasicType.Text:
                        {
                            StringFilter filtro = (StringFilter)gf;
                            filtro.SetValue(valor);
                        }
                        break;
                    case WebHelper.Storer.BasicType.Date:
                        {
                            DateFilter filtro = (DateFilter)gf;
                            filtro.SetValue(DateTime.Parse(valor));
                        }
                        break;
                    case WebHelper.Storer.BasicType.Bool:
                        {
                            BooleanFilter filtro = (BooleanFilter)gf;
                            filtro.SetValue(bool.Parse(valor));
                        }
                        break;
                }

                gf.SetActive(true);
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
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


        public void cargarFiltros(Storer st)
        {
            List<object[]> names = new List<object[]>();

            foreach (Atributos s in st.Armador.Atributos)
            {
                //Si no se definió una columna, o si se configuró una columna visible
                //entonces, agregamos el atributo.
                if (s.Columna == null)
                {
                    names.Add(new object[] { s.Nombre, s.Nombre });
                }
                else if (s.Columna.Visible)
                {
                    names.Add(new object[] { s.Nombre, s.Columna.Titulo });
                }
            }

            Store1.DataSource = names;
            Store1.DataBind();

            st.ObjectToFilters(ref this.GridFilters1);
        }

        public void agregarChartPoint(string valor1, float valor2)
        {
            chart.Data.Add(new ChartPoint(valor1, valor2));
            ChartControl1.Charts.Add(chart);
            ChartControl1.RedrawChart();
        }


        protected void buttonClean_OnClick(object sender, DirectEventArgs e)
        {
            foreach (GridFilter gf in GridFilters1.Filters)
            {
                gf.SetActive(false);
            }
        }



    }
}