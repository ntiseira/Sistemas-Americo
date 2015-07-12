using System;
using AdministradorGeneral.Empresas;
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
using IU.Generico.Events;
using ModuloSoporte.Security;
using PhantomDb.Entidades;
using WebHelper;
using AdministradorGeneral.Seguridad;
using System.Collections.Generic;
using CapaDatos;
using ModuloSoporte;
using Entidades;
using VentasCuentasCobrar;

namespace IU.VentasCuentasCobrar.Cobranzas
{
    public partial class RegistracionCobranza : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //ComboClientes
            Storer stcli = new Storer(typeof(Entity_cliente));
            OnshowCli(stcli);
            //Combo moneda
            Storer stmon = new Storer(typeof(Entity_moneda));
            OnshowMoneda(stmon);
            //Combo Causa de emision
            Storer stca = new Storer(typeof(Entity_causasEmision));
            OnshowCausa(stca);
        }


        [DirectMethod]
        public void BotonCancelar_Click(object sender, DirectEventArgs e)
        {
            Session["Mensaje"] = "Por favor, cierre la pestaña.";
            Session["Titulo"] = "Operación cancelada";
            Response.Redirect("../../Mensaje.aspx");
        }

        #region Atributos de bases de datos

        private String stringConnection = "";
        public String StringConnection
        {
            get { return stringConnection; }
            set { stringConnection = value; }
        }

        private String select = "";
        public String Select
        {
            get { return select; }
            set { select = value; }
        }
        #endregion


        private void OnshowCli(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;
            // if (Select.Equals(""))
            Select = storeCombo.GetSelect();


            this.SqlDataSource1.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource1.ConnectionString = StringConnection;
            this.SqlDataSource1.SelectCommand = Select;

        }


        private void OnshowMoneda(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;
            // if (Select.Equals(""))
            Select = storeCombo.GetSelect();


            this.SqlDataSource2.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource2.ConnectionString = StringConnection;
            this.SqlDataSource2.SelectCommand = Select;
        }

        private void OnshowCausa(Storer storeCombo)
        {
            if (StringConnection.Equals(""))
                StringConnection = CapaDatos.Datos.ConnectionString;
            // if (Select.Equals(""))
            Select = storeCombo.GetSelect();


            this.SqlDataSource3.ProviderName = "MySql.Data.MySqlClient";
            this.SqlDataSource3.ConnectionString = StringConnection;
            this.SqlDataSource3.SelectCommand = Select;
        }

        [DirectMethod]
        protected void BotonRegistrarCobranza(object sender, EventArgs e)
        {

            int cliente = int.Parse(ComboBoxClientes.SelectedItem.Value.ToString());
            string causaemision = comboCausaEmision.SelectedItem.Text;
            int moneda = int.Parse(ComboMonedas.Value.ToString());        
            DateTime fecha = fechaComprobante.SelectedDate;
            double importeBruto = double.Parse(ImporteBruto.Text);
            double importeNeto = double.Parse(ImporteNeto.Text);
            long codempresa = ContabilidadGlobal.Admin.CodEmpresa;
            int nrocuenta = 0;
            double saldo = 0;
            int idBanco = 0;

            ArrayList array = AdministradorVentas.ObtenerClienteNroCuenta(cliente);
            if (array.Count > 0)
            {
               nrocuenta = int.Parse(array[0].ToString());
               saldo = double.Parse(array[1].ToString());
               idBanco = int.Parse(array[2].ToString());
            }
            if (importeBruto <= saldo)
            {
                bool respu = AdministradorVentas.RegistrarCobranza(fecha, nrocuenta, importeNeto, importeBruto, cliente, codempresa, causaemision, "Cobranzas",  idBanco, saldo);

                if (respu == true)
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = "Carga Exitosa",
                        Message = "Se ha registrado la cobranza",
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO,
                    });
                }            
            else
             {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Error de carga",
                    Message = "El saldo en cuenta corriente es insuficiente para realizar la operacion",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO,

                });
            
                }
            }
        
        
        }





    }
}
