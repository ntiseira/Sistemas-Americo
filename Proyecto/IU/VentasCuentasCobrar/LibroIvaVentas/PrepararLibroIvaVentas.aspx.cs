﻿using System;
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
using IU.VentasCuentasCobrar.Reportes;
using IU.VentasCuentasCobrar.Reportes.DataSetLibroIvaVentasTableAdapters;
using CrystalDecisions.Shared;
using ModuloSoporte;

namespace IU.VentasCuentasCobrar.LibroIvaVentas
{
    public partial class PrepararLibroIvaVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!X.IsAjaxRequest)
            {
                CargarDatosEnCombo();
            }
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
                int cliente = int.Parse(ComboBoxClientes.Value.ToString());

                if (CheckboxMesActual.Checked == true || CheckboxFechas.Checked == false)
                {

                    DateTime fechaDesde = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 01);
                    DateTime fechaHasta = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 01).AddDays(-1);


                    Reportes.LibroIvaVentas resumen = new Reportes.LibroIvaVentas();
                    DataSetLibroIvaVentas datos = new DataSetLibroIvaVentas();


                    obtenerLibroIvaVentasTableAdapter prueba = new obtenerLibroIvaVentasTableAdapter();
                    prueba.Fill(datos.obtenerLibroIvaVentas, cliente, fechaDesde, fechaHasta);

                    string fullpath = Request.MapPath("~\\VentasCuentasCobrar\\Reportes\\ReportesGenerados\\LibroIvaVentas.pdf");

                    
                    resumen.SetDataSource(datos);
                    resumen.ExportToDisk(ExportFormatType.PortableDocFormat, fullpath);
                    Response.ContentType = "application/pdf";

                }
                else
                {
                    if (CheckboxFechas.Checked == true)
                    {

                        Reportes.LibroIvaVentas resumen = new Reportes.LibroIvaVentas();
                        DataSetLibroIvaVentas datos = new DataSetLibroIvaVentas();
                        DateTime fechaDesde = DateFieldDesde.SelectedDate;
                        DateTime fechaHasta = DateFieldHasta.MinDate;

                        obtenerLibroIvaVentasTableAdapter prueba = new obtenerLibroIvaVentasTableAdapter();
                        prueba.Fill(datos.obtenerLibroIvaVentas, cliente, fechaDesde, fechaHasta);

                        string fullpath = Request.MapPath("~\\VentasCuentasCobrar\\Reportes\\ReportesGenerados\\LibroIvaVentas.pdf");


                        resumen.SetDataSource(datos);
                        resumen.ExportToDisk(ExportFormatType.PortableDocFormat, fullpath);
                        Response.ContentType = "application/pdf";
                    }
                }
       
                Response.Redirect("LibroIvaVentas.aspx");
            }
            else
            {
                UIHelper.MostrarError("No se ha podido proseguir porque no hay un cliente seleccionado. Por favor, seleccione un cliente y haga click en siguiente.", "Error");
            }
        }






      






    
    }
}