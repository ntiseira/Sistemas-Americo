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

namespace IU.VentasCuentasCobrar.CuentaCorrienteyCobranzas
{
    public partial class GestionarCuentaCorriente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


               
            try
            {
                if (!X.IsAjaxRequest)
                {
                    Session["codigo_cliente"] = 0;
                }
                
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_cliente);
                this.ControlAbm1.Titulo = "Gestionar cuentas corrientes";
                this.ControlAbm1.Descripcion = "Permite administrar las cuentas corrientes de los clientes.";
                this.ControlAbm1.Valores = new SqlValor[] 
                {
                    new SqlValor("empresa_idempresa", ModuloSoporte.Global.CodEmpresa),
                    
                };
                this.ControlAbm1.OnShow();

             
                this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
                this.ControlAbm1.OnShow();

                this.ControlAbm2.Tipo = typeof(Entidades.CuentaCorriente);
                this.ControlAbm2.Titulo = "";
                this.ControlAbm2.MostrarDescripcion = false;

                this.ControlAbm2.Valores = new SqlValor[] 
                { 
                    new SqlValor("cliente_codcliente", Session["codigo_cliente"]), 
                    new SqlValor("banco_empresa_idempresa", Global.CodEmpresa),
                    new SqlValor("cliente_empresa_idempresa", Global.CodEmpresa)
                };
                this.ControlAbm1.ValoresCombo = new SqlValor[]
                {
                    new SqlValor("banco_empresa_idempresa", Global.CodEmpresa)                 
                   
            };
                
                this.ControlAbm2.OnShow();
            
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
                this.ControlAbm1.Valores[0].Valor = 0;
                this.ControlAbm2.Valores[0].Valor = 0;
            }
            else
            {
                Entidades.Entity_cliente cli = (Entidades.Entity_cliente)row;

                /*
                SJLiquidacion liq = (SJLiquidacion)row;
                this.ControlAbm2.Valores[0].Valor = liq.Codigo;
                */
                Session["codigo_cliente"] = cli.Codcliente;
            }

            this.ControlAbm2.ActualizarConsultas();
            

        



        }



    }//clase
}//namespace
