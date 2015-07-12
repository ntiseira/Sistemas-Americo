using System;
using WebHelper;

namespace IU.Contabilidad.CentrosCosto
{
    public partial class Departamentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_departamento);
                this.ControlAbm1.Titulo = "Gestionar departamentos";
                this.ControlAbm1.Descripcion = "Permite administrar los departamentos de la empresa.";
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
