using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebHelper;
using ModuloSoporte;
using Ext.Net;

namespace IU.VentasCuentasCobrar.CuentaCorrienteyCobranzas
{
    public partial class GestionarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
                new SqlValor("empresa_idempresa", Global.CodEmpresa) 
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_lineadescuento);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                 new SqlValor("cliente_codCliente", Session["codigo_cliente"]), 
                    new SqlValor("banco_empresa_idempresa", Global.CodEmpresa),
                    new SqlValor("cliente_empresa_idempresa", Global.CodEmpresa)
            };
            this.ControlAbm2.OnShow();
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
                Entidades.Entity_cliente cli = (Entidades.Entity_cliente)row;               
                Session["codigo_cliente"] = cli.Codcliente;
            }

            this.ControlAbm2.ActualizarConsultas();
        }
    }
}