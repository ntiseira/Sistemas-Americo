using System;
using WebHelper;

namespace IU.VentasCuentasCobrar.Clientes
{
    public partial class GestionarTiposClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_tipocliente);
                this.ControlAbm1.Titulo = "Gestionar tipos de clientes";
                this.ControlAbm1.Descripcion = "Permite administrar los tipos de clientes.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ModuloSoporte.Global.CodEmpresa) 
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
