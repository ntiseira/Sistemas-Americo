using System;
using ModuloSoporte;
using WebHelper;
using Ext.Net;
using SueldosJornales;

namespace IU.SueldosJornales
{
    public partial class Liquidacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["GestionarLiquidacion_codigo"] = 0;
            }
            //PARAMETROS CONTROL CHILD 1
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
            //PARAMETROS CONTROL CHILD 2
            this.ControlAbm2.Tipo = typeof(ConceptoLiquidar);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Liquidacion_Sueldos_empleados_empresa_idempresa", Global.CodEmpresa)
            };
            this.ControlAbm2.OnShow();
            //PARAMETROS CONTROL CHILD 3
            this.ControlAbm3.Tipo = typeof(Sueldo);
            this.ControlAbm3.Titulo = "";
            this.ControlAbm3.MostrarDescripcion = false;
            this.ControlAbm3.Valores = new SqlValor[] 
            { 
                new SqlValor("empleados_empresa_idempresa", Global.CodEmpresa)
            };
            this.ControlAbm3.OnShow();
        }

        void ControlAbm1_AlSeleccionar(object sender, EventArgs e)
        {
            object row = this.ControlAbm1.SelectedItem;

            if (row == null)
            {
                this.ControlAbm2.Valores[0].Valor = 0;
            }
            else
            {
                SJLiquidacion liq = (SJLiquidacion)row;
                this.ControlAbm2.Valores[0].Valor = liq.Codigo;
                Session["GestionarLiquidacion_codigo"] = liq.Codigo;
            }

            this.ControlAbm2.ActualizarConsultas();
        }



    }
}
