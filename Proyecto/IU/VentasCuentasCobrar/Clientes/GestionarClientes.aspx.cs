using System;
using WebHelper;
using ModuloSoporte;

namespace IU.VentasCuentasCobrar.Clientes
{
    public partial class GestionarClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_cliente);
            this.ControlAbm1.Titulo = "Gestionar tipos de clientes";
            this.ControlAbm1.Descripcion = "Permite administrar los tipos de clientes.";
            this.ControlAbm1.ValoresCombo = new SqlValor[] { new SqlValor("empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", ModuloSoporte.Global.CodEmpresa)
            };
            this.ControlAbm1.OnShow();
        }
    }
}
