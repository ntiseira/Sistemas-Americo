using System;
using Ext.Net;
using ModuloSoporte;
using WebHelper;

namespace IU.VentasCuentasCobrar.Descuentos
{
    public partial class DescuentoComercial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                Session["id_descuento"] = 0;
            }

            this.ControlAbm1.Tipo = typeof(Entidades.Entity_descuentoscomerciales);
            this.ControlAbm1.Titulo = "";
            this.ControlAbm1.MostrarDescripcion = false;
            this.ControlAbm1.Valores = new SqlValor[] 
            { 
                new SqlValor("Empresa_idempresa", Global.CodEmpresa) 
            };
            this.ControlAbm1.AlSeleccionar += new EventHandler(ControlAbm1_AlSeleccionar);
            this.ControlAbm1.OnShow();

            this.ControlAbm2.Tipo = typeof(Entidades.Entity_lineadescuento);
            this.ControlAbm2.Titulo = "";
            this.ControlAbm2.MostrarDescripcion = false;
            this.ControlAbm2.Valores = new SqlValor[] 
            { 
                new SqlValor("Descuentoscomerciales_iddescuentoscomerciales", Session["id_descuento"]), // Índice inexistente, dado que no se seleccionó ninguno//
                new SqlValor("Descuentoscomerciales_empresa_idempresa", Global.CodEmpresa)
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
                var indx = (Entidades.Entity_descuentoscomerciales)row;
             
               
                this.ControlAbm2.Valores[0].Valor = indx.Iddescuentoscomerciales;
                Session["id_descuento"] = indx.Iddescuentoscomerciales;
            }

            this.ControlAbm2.ActualizarConsultas();
        }


    }//clase
}//namespace
