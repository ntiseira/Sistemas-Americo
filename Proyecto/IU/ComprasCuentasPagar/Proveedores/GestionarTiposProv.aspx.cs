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
using WebHelper;

namespace IU.ComprasCuentasPagar.Proveedores
{
    public partial class GestionarTiposProv : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_tipoproveedor);
                this.ControlAbm1.Titulo = "Gestionar tipos de proveedores";
                this.ControlAbm1.Descripcion = "Permite administrar los tipos de proveedores de la empresa.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ModuloSoporte.Global.CodEmpresa) 
                };
                this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
