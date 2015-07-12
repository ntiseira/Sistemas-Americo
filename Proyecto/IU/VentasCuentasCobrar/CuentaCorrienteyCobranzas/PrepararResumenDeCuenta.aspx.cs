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
using Ext.Net;
using IU.Contabilidad;
using ModuloSoporte;
using VentasCuentasCobrar;
using IU.VentasCuentasCobrar.Reportes;
using CrystalDecisions.Shared;
using System.IO;
using IU.VentasCuentasCobrar.Reportes.DataSetResumenCuentaTableAdapters;


namespace IU.VentasCuentasCobrar.CuentaCorrienteyCobranzas
{
    public partial class PrepararResumenDeCuenta: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                CargarDatosEnCombo();
            }
        }

        public object SelectedCliente
        {
            get { return   Session["SelectedClient"]; }
            set { Session["SelectedClient"] = value; }
        }
      
     
        public object SelectedMesActual
        {
            get { return Session["SelectedMesActual"]; }
            set { Session["SelectedMesActual"] = value; }
        }

        public object SelectedFecha
        {
            get { return Session["SelectedFecha"]; }
            set { Session["SelectedFecha"] = value; }
        }

        public object SelectedFechaDesde
        {
            get { return Session["SelectedFechaDesde"]; }
            set { Session["SelectedFechaDesde"] = value; }
        }

        public object SelectedHasta
        {
            get { return Session["SelectedFechaHasta"]; }
            set { Session["SelectedFechaHasta"] = value; }
        }


        public static void Preparar(string var, string page, System.Web.UI.Page pageObject)
        {
            pageObject.Session["SelectedClient.Var"] = var;   // Cliente seleccionado
            pageObject.Session["SelectedClient.Page"] = page; // Página de redirección
        }


        protected void CargarDatosEnCombo()
        {
            try
            {             
                StoreComboCli.DataSource = ContabilidadGlobal.Admin.ObtenerListaClientes();
                StoreComboCli.DataBind();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error al cargar los clientes");
            }
        }


        [DirectMethod]
        protected void Checkbox_Check(object sender, DirectEventArgs e)
        {
            /*if (!CheckboxMesActual.Checked)
                //ComboBox1.Show();
            else
                //ComboBox1.Hide();*/
        }



        private bool Validar()
        {

            bool respu = true;


                if (ComboBoxClientes.SelectedItem.Text == "")
                {
                     X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Datos invalidos",
                        Message = "Debe ingresar un cliente",
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO,
                    }); 
                    respu = false;
                }

                return respu;
        }


        [DirectMethod]
        protected void BotonNext_Click(object sender, DirectEventArgs e)
        {
        
            if (Validar() == true)

            {
                SelectedCliente = int.Parse(ComboBoxClientes.Value.ToString());
                 

                if (CheckboxMesActual.Checked == true || CheckboxFechas.Checked == false)
                {

                    DateTime fechaDesde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01);
                    DateTime fechaHasta = new DateTime(DateTime.Today.Year, DateTime.Today.Month +1, 01).AddDays(-1);

                    SelectedFechaDesde = fechaDesde.ToString();
                    SelectedHasta = fechaHasta.ToString();

                    Resumen resumen = new Resumen();
                    DataSetResumenCuenta datos = new DataSetResumenCuenta();

                 
                   obtenerResumenDeCuentaTableAdapter prueba = new obtenerResumenDeCuentaTableAdapter();
                   prueba.Fill(datos.obtenerResumenDeCuenta, 1, 1, 1, fechaDesde, fechaHasta);
                
                   string fullpath = Request.MapPath("~\\VentasCuentasCobrar\\Reportes\\ReportesGenerados\\ResumenCuentaCorriente.pdf");
                                 
                    resumen.SetDataSource(datos);
                    resumen.ExportToDisk(ExportFormatType.PortableDocFormat, fullpath);
                    Response.ContentType = "application/pdf";
                                   
                }
                else
                {
                    if (CheckboxFechas.Checked == true)
                    {
                        DateTime fechaDesde = DateFieldDesde.SelectedDate;
                        DateTime fechaHasta = DateFieldHasta.SelectedDate;
                       

                        SelectedFechaDesde = fechaDesde.ToString();
                        SelectedHasta = fechaHasta.ToString();

                        Resumen resumen = new Resumen();
                        DataSetResumenCuenta datos = new DataSetResumenCuenta();


                        obtenerResumenDeCuentaTableAdapter prueba = new obtenerResumenDeCuentaTableAdapter();
                        prueba.Fill(datos.obtenerResumenDeCuenta, 1, 1, 1, fechaDesde, fechaHasta);

                        string fullpath = Request.MapPath("~\\VentasCuentasCobrar\\Reportes\\ReportesGenerados\\ResumenCuentaCorriente.pdf");

                        resumen.SetDataSource(datos);
                        resumen.ExportToDisk(ExportFormatType.PortableDocFormat, fullpath);
                        Response.ContentType = "application/pdf";
                    }                            
                }
            
                Response.Redirect("DarResumenDeCuenta.aspx");
            }            
            else
            {
                UIHelper.MostrarError("No se ha podido proseguir porque no hay un cliente seleccionado. Por favor, seleccione un cliente y haga click en siguiente.", "Error");
            }
        }
        
    }
}
