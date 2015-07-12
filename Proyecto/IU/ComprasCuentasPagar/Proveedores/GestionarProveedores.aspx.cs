using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.ComprasCuentasPagar.Proveedores
{
    public partial class GestionarProveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_proveedor);
                this.ControlAbm1.Titulo = "Gestionar proveedores";
                this.ControlAbm1.Descripcion = "Permite administrar los proveedores de una empresa.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Tipoproveedor_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
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
