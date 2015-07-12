using System;
using ModuloSoporte;
using WebHelper;
using IU.Contabilidad;

namespace IU.AdministradorGral.Seguridad
{
    public partial class Sucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.TipoUsuario.Equals("Administrador"))
            {
                UIHelper.AccesoDenegado(this);
            }
            else
            {
                try
                {
                    this.ControlAbm1.Tipo = typeof(Entidades.Entity_usuarios_has_sucursal);
                    this.ControlAbm1.Titulo = "Permisos sucursales";
                    this.ControlAbm1.Descripcion = "Permite administrar los permisos de los usuarios con las sucursales.";
                    this.ControlAbm1.Valores = new SqlValor[] 
                    { 
                        new SqlValor("Sucursal_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
                    };
                    this.ControlAbm1.ValoresCombo = new SqlValor[]
                    {
                        new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa), 
                        new SqlValor("Sucursal_empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
                    };
                    this.ControlAbm1.OnShow();
                }
                catch
                {
                    UIHelper.PaginaMensaje(this, "Error en la base de datos", "Ha ocurrido un error en la base de datos.");
                }
            }
        }
    }
}
