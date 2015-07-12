using System;
using AdministradorGeneral.Seguridad;
using ComprasCuentasPagar;
using Ext.Net;
using IU.Contabilidad;
using WebHelper;

namespace IU.ComprasCuentasPagar.Proveedores
{
    public partial class DatosProveedor : System.Web.UI.Page
    {
        private const string var = "OtrosDatos.Prov";
        private const string oldvar = "OtrosDatos.Prov.Old";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[var] == null || Session[var].ToString().Equals(""))
                {
                    if (!X.IsAjaxRequest)
                    {
                        SeleccionarProveed.Preparar(var, "DatosProveedor.aspx", this);
                        Response.Redirect("SeleccionarProveed.aspx");
                        return;
                    }
                    else
                    {
                        Session[var] = Session[oldvar];
                    }
                }

                var codCliente = (int)Session[var];
                AdministradorCompras.CrearDatosSiNoExisten(codCliente);

                this.ControlAbm1.Tipo = typeof(Entidades.Entity_proveedoresotrosdatos);
                this.ControlAbm1.Titulo = "Otros datos";
                this.ControlAbm1.MostrarFiltros = false;
                this.ControlAbm1.Descripcion = "Trabaje sobre la fila mostrada.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Proveedor_idproveedor", codCliente) ,
                    new SqlValor("Proveedor_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
                };
                this.ControlAbm1.Permisos = Permisos.PermisosGuest;
                this.ControlAbm1.Permisos.Modif = true;
                this.ControlAbm1.OnShow();

                Session[oldvar] = Session[var];
                Session[var] = null;
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

    }
}
