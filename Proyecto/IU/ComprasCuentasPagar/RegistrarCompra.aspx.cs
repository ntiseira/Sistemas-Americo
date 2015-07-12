using System;
using Ext.Net;
using ModuloSoporte;
using WebHelper;

namespace IU.ComprasCuentasPagar
{
    public partial class RegistrarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["codigo_compra"] = 0;
            }
            this.ControlAbm1.Tipo = typeof(Entidades.Entity_Compras);
            this.ControlAbm1.Titulo = "";
            this.ControlAbm1.MostrarDescripcion = false;
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Proveedores_empresa_idempresa", Global.CodEmpresa) 
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_LineaCompras);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Compras_proveedores_empresa_idempresa", Global.CodEmpresa),
                new SqlValor("Compras_cod_compra", Session["codigo_compra"])
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
                var compra = (Entidades.Entity_Compras)row;
                this.ControlAbm2.Valores[1].Valor = compra.Cod_compra;
                Session["codigo_compra"] = compra.Cod_compra;
            }

            this.ControlAbm2.ActualizarConsultas();

        }










    }
}
