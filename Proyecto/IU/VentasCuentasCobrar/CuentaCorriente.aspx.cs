using System;
using WebHelper;

namespace IU.VentasCuentasCobrar
{
    public partial class cuentaCorriente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                this.ControlAbm.Tipo = typeof(Entidades.Entity_CuentaCorriente);
                this.ControlAbm.Titulo = "Gestionar cuentas corrientes";
                this.ControlAbm.Descripcion = "Permite administrar las cuentas corrientes de los clientes.";
                this.ControlAbm.Valores = new SqlValor[] 
                {
                    new SqlValor("Banco_empresa_idempresa", ModuloSoporte.Global.CodEmpresa) 
                };
                this.ControlAbm.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }//clase
}//namespace
