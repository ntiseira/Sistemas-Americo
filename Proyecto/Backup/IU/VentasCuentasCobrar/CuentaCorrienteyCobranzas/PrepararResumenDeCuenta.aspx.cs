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


        [DirectMethod]
        protected void BotonNext_Click(object sender, DirectEventArgs e)
        {
           /* if (!ComboBoxClientes.Text.Equals(""))
            {
                Session[Session["SelectedClient.Var"].ToString()] = int.Parse(ComboBoxClientes.Text);
                Response.Redirect(Session["SelectedClient.Page"].ToString());
            }
            else
            {
                UIHelper.MostrarError("No se ha podido proseguir porque no hay un cliente seleccionado. Por favor, seleccione un cliente y haga click en siguiente.", "Error");
            }*/
        }










    }
}
