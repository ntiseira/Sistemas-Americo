using System;
using WebHelper;

namespace IU.Contabilidad.TipoMovimiento
{
    public partial class Gestionar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Siscont.Contabilidad.TipoMovimiento);
            this.ControlAbm1.Titulo = "Gestionar tipos de movimientos";
            this.ControlAbm1.Descripcion = "Permite administrar los tipos de movimientos de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("CodEmpresa", ContabilidadGlobal.Admin.CodEmpresa) };
            this.ControlAbm1.OnShow();
        }
    }
}
