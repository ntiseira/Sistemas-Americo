using System;
using IU.Contabilidad;
using WebHelper;

namespace IU.AdministradorGral.Tablas
{
    public partial class GestionarBancos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_banco);
                this.ControlAbm1.Titulo = "Gestionar bancos";
                this.ControlAbm1.Descripcion = "Permite administrar los datos correspondientes a los bancos.";
                this.ControlAbm1.Valores = new SqlValor[] { new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) };
                this.ControlAbm1.OnShow();
            }
            catch (Exception ex)
            {
                IU.UIHelper.MostrarExcepcionSimple(ex, "Error al cargar el contenido.");
            }
        }
    }
}
