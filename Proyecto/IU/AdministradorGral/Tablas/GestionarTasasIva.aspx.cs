using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.AdministradorGral.Tablas
{
    public partial class GestionarTasasIva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_tasaiva);
            this.ControlAbm1.Titulo = "Gestionar tasas de IVA";
            this.ControlAbm1.Descripcion = "Permite administrar las tasas de IVA.";
            this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) };
            this.ControlAbm1.OnShow();
        }
    }
}
