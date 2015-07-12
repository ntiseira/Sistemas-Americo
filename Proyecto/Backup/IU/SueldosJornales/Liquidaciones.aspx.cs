using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using SueldosJornales;
using ModuloSoporte;
using WebHelper;
using Ext.Net;

namespace IU.SueldosJornales
{
    public partial class Liquidaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!X.IsAjaxRequest)
                {
                    Session["codigo_liquidacion"] = 0;
                }
                this.ControlAbm1.Tipo = typeof(SJLiquidacion);
                this.ControlAbm1.Titulo = "";
                this.ControlAbm1.Descripcion = "Permite administrar las liquidaciones de los empleados.";
                this.ControlAbm1.MostrarDescripcion = false;
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", Global.CodEmpresa) 
                };
            
                this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
                this.ControlAbm1.OnShow();

                this.ControlAbm2.Tipo = typeof(Sueldo);
                this.ControlAbm2.Titulo = "";
                this.ControlAbm2.MostrarDescripcion = false;
                this.ControlAbm2.Valores = new SqlValor[] 
                { 
                    new SqlValor("Liquidacion_codigo", Session["codigo_liquidacion"]), 
                    new SqlValor("empleados_sucursal_empresa_idempresa", Global.CodEmpresa)
                };
                this.ControlAbm2.OnShow();

                this.ControlAbm3.Tipo = typeof(ConceptoLiquidar);
                this.ControlAbm3.Titulo = "";
                this.ControlAbm3.MostrarDescripcion = false;
                this.ControlAbm3.Valores = new SqlValor[] 
                { 
                    new SqlValor("Liquidacion_codigo", Session["codigo_liquidacion"]),
                    new SqlValor("Empresa_idempresa", Global.CodEmpresa)
                };
                this.ControlAbm3.OnShow();
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }





        void ControlAbm1_AlSeleccionar(object sender, EventArgs e)
        {
            object row = this.ControlAbm1.SelectedItem;

            if (row == null)
            {
                this.ControlAbm2.Valores[0].Valor = 0;
                this.ControlAbm3.Valores[0].Valor = 0;
            }
            else
            {
                SJLiquidacion liq = (SJLiquidacion)row;
                this.ControlAbm2.Valores[0].Valor = liq.Codigo;
                this.ControlAbm3.Valores[0].Valor = liq.Codigo;
                Session["codigo_liquidacion"] = liq.Codigo;
            }

            this.ControlAbm2.ActualizarConsultas();
            this.ControlAbm3.ActualizarConsultas();

        }


    }
}
