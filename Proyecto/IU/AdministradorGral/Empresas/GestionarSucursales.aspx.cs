using System;
using WebHelper;
using IU.Contabilidad;

namespace IU.AdministradorGral.Empresas
{
    public partial class GestionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_sucursal);
            this.ControlAbm1.Titulo = "Gestionar sucursales de la empresa";
            this.ControlAbm1.Descripcion = "Permite administrar las sucursales.";
            this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa),
                };
            this.ControlAbm1.OnShow();
        }
    }
}
