using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.ComprasCuentasPagar.Proveedores
{
    public partial class GestionarTiposProveed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_tipoproveedor);
                this.ControlAbm1.Titulo = "Gestionar tipos de proveedor";
                this.ControlAbm1.Descripcion = "Permite administrar los tipos de proveedor de una empresa.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
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
