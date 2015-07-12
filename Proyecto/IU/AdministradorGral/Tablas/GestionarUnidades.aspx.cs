using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.AdministradorGral.Tablas
{
    public partial class GestionarUnidades_aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_unidad);
                this.ControlAbm1.Titulo = "Gestionar unidades";
                this.ControlAbm1.Descripcion = "Permite administrar diferentes unidades de medida.";
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
