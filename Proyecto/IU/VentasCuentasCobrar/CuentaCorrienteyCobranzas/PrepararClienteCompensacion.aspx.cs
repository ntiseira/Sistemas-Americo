using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using IU.Contabilidad;

namespace IU.VentasCuentasCobrar.CuentaCorrienteyCobranzas
{
    public partial class PrepararClienteCompensacion : System.Web.UI.Page
    {
     

        public static void PrepararCliente(string var, string page, System.Web.UI.Page pageObject)
        {
            pageObject.Session["SelectedClient.Var"] = var;   // Cliente seleccionado
            pageObject.Session["SelectedClient.Page"] = page; // Página de redirección
       
        }

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
        protected void BotonNext_Click(object sender, DirectEventArgs e)
        {
            if (!ComboBoxClientes.Text.Equals(""))
            {
                Session[Session["SelectedClient.Var"].ToString()] = int.Parse(ComboBoxClientes.Text);
                Response.Redirect(Session["SelectedClient.Page"].ToString());
            }
            else
            {
                UIHelper.MostrarError("No se ha podido proseguir porque no hay un cliente seleccionado. Por favor, seleccione un cliente y haga click en siguiente.", "Error");
            }
        }




    }
}