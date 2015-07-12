
namespace ModuloSoporte
{
    public static class Global
    {
        private static string usuario = "";
        public static string Usuario
        {
            get { return Global.usuario; }
            set { Global.usuario = value; }
        }

        private static string tipoUsuario = "";
        public static string TipoUsuario
        {
            get { return Global.tipoUsuario; }
            set { Global.tipoUsuario = value; }
        }

        private static long codEmpresa = 0;
        public static long CodEmpresa
        {
            get { return Global.codEmpresa; }
            set { Global.codEmpresa = value; }
        }

        private static string nombreEmpresa = "";
        public static string NombreEmpresa
        {
            get { return Global.nombreEmpresa; }
            set { Global.nombreEmpresa = value; }
        }

        private static long codSucursal = 0;
        public static long CodSucursal
        {
            get { return Global.codSucursal; }
            set { Global.codSucursal = value; }
        }

        private static string nombreSucursal = "";
        public static string NombreSucursal
        {
            get { return Global.nombreSucursal; }
            set { Global.nombreSucursal = value; }
        }

        public static void CerrarSesion()
        {
            Usuario = "";
            NombreEmpresa = "";
            NombreSucursal = "";
            CodEmpresa = 0;
            TipoUsuario = "";
            CodSucursal = 0;
        }
    }
}
