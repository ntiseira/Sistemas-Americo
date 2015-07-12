using System;
using WebHelper;

namespace IU.Contabilidad.TipoAsiento
{
    public partial class GestionarTiposDeAsientos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Siscont.Contabilidad.TipoAsiento);
            this.ControlAbm1.Titulo = "Gestionar tipos de asientos";
            this.ControlAbm1.Descripcion = "Permite administrar los tipos de asientos de la empresa.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) };
            this.ControlAbm1.OnShow();
        }
    }
}
