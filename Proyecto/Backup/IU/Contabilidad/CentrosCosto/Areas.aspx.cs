using System;
using WebHelper;

namespace IU.Contabilidad.CentrosCosto
{
    public partial class Areas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_area);
            this.ControlAbm1.Titulo = "Gestionar áreas";
            this.ControlAbm1.Descripcion = "Permite administrar áreas.";
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
            };
            this.ControlAbm1.OnShow();
        }
    }
}
