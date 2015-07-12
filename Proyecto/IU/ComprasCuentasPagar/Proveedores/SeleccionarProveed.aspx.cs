using System;
using Ext.Net;
using IU.Contabilidad;

namespace IU.ComprasCuentasPagar.Proveedores
{
    public partial class SeleccionarProveed : System.Web.UI.Page
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
                StoreComboCli.DataSource = ContabilidadGlobal.Admin.ObtenerListaProveedores();
                StoreComboCli.DataBind();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error al cargar los proveedores");
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
                UIHelper.MostrarError("No se ha podido proseguir porque no hay un proveedor seleccionado. Por favor, seleccione uno y haga click en siguiente.", "Error");
            }
        }

    }
}
