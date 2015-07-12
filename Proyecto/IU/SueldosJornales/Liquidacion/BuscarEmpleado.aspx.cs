using System;
using Ext.Net;
using ModuloSoporte;
using SueldosJornales;
using WebHelper;

namespace IU.SueldosJornales.Liquidacion
{
    public partial class BuscarEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.ControlAbm1.Tipo = typeof(SJLiquidacion);
            this.ControlAbm1.Titulo = "";
            this.ControlAbm1.Descripcion = "Permite administrar las liquidaciones.";
            this.ControlAbm1.MostrarDescripcion = false;
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Sueldos_empleados_empresa_idempresa", Global.CodEmpresa) 
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();
        }

        void ControlAbm1_AlSeleccionar(object sender, EventArgs e)
        {
            object row = this.ControlAbm1.SelectedItem;
        }

    }
}
