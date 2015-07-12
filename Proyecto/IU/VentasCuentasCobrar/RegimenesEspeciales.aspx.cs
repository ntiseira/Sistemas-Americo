using System;
using ModuloSoporte;
using VentasCuentasCobrar;
using WebHelper;

namespace IU.VentasCuentasCobrar
{
    public partial class RegimenesEspeciales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // harcodeado el CodEmpresa
            this.ControlAbm.Tipo = typeof(RegimenEspecial);
            this.ControlAbm.Titulo = "Gestionar los regimenes especiales";
            this.ControlAbm.Descripcion = "Permite administrar los regimenes especiales de facturacion";
            this.ControlAbm.Valores = new SqlValor[] { new SqlValor("empresa_idempresa", Global.CodEmpresa) };
            this.ControlAbm.OnShow();
        }




    }//clase
}//namespace
