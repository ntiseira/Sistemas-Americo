using Siscont.Contabilidad;

namespace IU.Contabilidad
{
    public static class ContabilidadGlobal
    {
        private static AdministradorContabilidad admin = null;
        public static AdministradorContabilidad Admin
        {
            get 
            {
                if (ContabilidadGlobal.admin == null)
                    ContabilidadGlobal.Admin = new AdministradorContabilidad();
                return ContabilidadGlobal.admin; 
            }
            set { ContabilidadGlobal.admin = value; }
        }
    }
}
