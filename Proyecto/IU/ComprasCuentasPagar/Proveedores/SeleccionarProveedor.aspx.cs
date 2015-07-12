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

namespace IU.ComprasCuentasPagar.Proveedores
{
    public partial class SeleccionarProveedor : System.Web.UI.Page
    {
        public static void Preparar(string var, string page, System.Web.UI.Page pageObject)
        {
            pageObject.Session["SelectedProv.Var"] = var;   // Proveedor seleccionado
            pageObject.Session["SelectedProv.Page"] = page; // Página de redirección
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
                StoreComboCli.DataSource = ContabilidadGlobal.Admin.ObtenerListaProveedores();
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
                Session[Session["SelectedProv.Var"].ToString()] = int.Parse(ComboBoxClientes.Text);
                Response.Redirect(Session["SelectedProv.Page"].ToString());
            }
            else
            {
                UIHelper.MostrarError("No se ha podido proseguir porque no hay un proveedor seleccionado. Por favor, seleccione un proveedor y haga click en siguiente.", "Error");
            }
        }
    }
}
