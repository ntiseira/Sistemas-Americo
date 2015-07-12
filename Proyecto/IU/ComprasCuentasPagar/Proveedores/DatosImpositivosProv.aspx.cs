using System;
using ComprasCuentasPagar;
using Ext.Net;
using IU.Contabilidad;
using WebHelper;

namespace IU.ComprasCuentasPagar.Proveedores
{
    public partial class DatosImpositivosProv : System.Web.UI.Page
    {
        private const string var = "DatosImpositivosProv.Prov";
        private const string oldvar = "DatosImpositivosProv.Prov.Old";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session[var] == null || Session[var].ToString().Equals(""))
                {
                    if (!X.IsAjaxRequest)
                    {
                        SeleccionarProveed.Preparar(var, "DatosImpositivosProv.aspx", this);
                        Response.Redirect("SeleccionarProveed.aspx");
                    }
                    else
                    {
                        Session[var] = Session[oldvar];
                    }
                }

                var codCliente = (int)Session[var];
                AdministradorCompras.CrearDatosSiNoExisten(codCliente);

                this.ControlAbm1.Tipo = typeof(Entidades.Entity_proveedoresdatosimposit);
                this.ControlAbm1.Titulo = "Datos impositivos";
                this.ControlAbm1.MostrarFiltros = false;
                this.ControlAbm1.Descripcion = "Trabaje sobre la fila mostrada. Nota: al ingresar un número de documento, no escriba símbolos (ejemplo \".\", \",\", u \"-\"), utilice solo números.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Proveedor_idproveedor", codCliente) ,
                    new SqlValor("Proveedor_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa) 
                };
                this.ControlAbm1.Permisos = AdministradorGeneral.Seguridad.Permisos.PermisosGuest;
                this.ControlAbm1.Permisos.Modif = true;
                this.ControlAbm1.OnShow();
                this.ControlAbm1.AlInsertar += new EventHandler<IU.Generico.Events.EventInsertAbm>(ControlAbm1_AlInsertar);
                this.ControlAbm1.AlModificar += new EventHandler<IU.Generico.Events.EventUpdateAbm>(ControlAbm1_AlModificar);
                Session[oldvar] = Session[var];
                Session[var] = null;
            }
            catch (Exception ex)
            {
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        void ControlAbm1_AlModificar(object sender, IU.Generico.Events.EventUpdateAbm e)
        {
            try
            {
                var obj = (Entidades.Entity_proveedoresdatosimposit)e.Tag;
                if (obj.Tipodocumento.Equals(Entidades.Documento.Cuil))
                {
                    var validador = new ModuloSoporte.Validadores.ValidadorCuit(obj.Numdocumento.ToString());
                    validador.Validar();
                }
            }
            catch (Exception ex)
            {
                e.ParentEventArgs.Cancel = true;
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }

        void ControlAbm1_AlInsertar(object sender, IU.Generico.Events.EventInsertAbm e)
        {
            try
            {
                var obj = (Entidades.Entity_proveedoresdatosimposit)e.Tag;
                if (obj.Tipodocumento.Equals(Entidades.Documento.Cuil))
                {
                    var validador = new ModuloSoporte.Validadores.ValidadorCuit(obj.Numdocumento.ToString());
                    validador.Validar();
                }
            }
            catch (Exception ex)
            {
                e.ParentEventArgs.Cancel = true;
                UIHelper.MostrarExcepcionSimple(ex, "Error");
            }
        }
    }
}
