using System;
using IU.Contabilidad;
using ModuloSoporte;
using WebHelper;

namespace IU.AdministradorGral.Seguridad
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.TipoUsuario.Equals("Administrador"))
            {
                UIHelper.AccesoDenegado(this);
            }
            else
            {
                this.ControlAbm1.Tipo = typeof(Entidades.Entity_empresa_has_usuarios);
                this.ControlAbm1.Titulo = "Gestionar usuarios";
                this.ControlAbm1.Descripcion = "Permite administrar los permisos de los usuarios con las empresas, realizar asociaciones, etc.";
                this.ControlAbm1.Valores = new SqlValor[] 
                { 
                    new SqlValor("Empresa_idempresa", ContabilidadGlobal.Admin.CodEmpresa)
                };
                this.ControlAbm1.OnShow();
            }
        }
    }
}
