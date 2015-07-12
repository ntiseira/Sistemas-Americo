using PhantomDb.Entidades;

namespace ComprasCuentasPagar.PROVEEDORES
{
   [Tabla("Proveedores")]
   public class Proveedor
   {

       #region datos personales proveedor

        private long codigo;
        [Identificador(Nombre="Cod_proveedor",Modificable=false)]
        public long Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string razonSocial;
        [Atributo]
        public string RazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        private bool habilitado;
        [Atributo]
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private string domicilio;
        [Atributo]
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        private string localidad;
        [Atributo]
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        private int provincia;
        [Atributo]
        [Relacion(Destino = typeof( Entidades.Entity_provincia), CampoId = 0, CampoSecundario = 1)]
        public int provincia_codProv
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private string telefono;
        [Atributo]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string fax;
        [Atributo]
        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        private string mail;
        [Atributo]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private string codigoPostal;
        [Atributo]
        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        private string contacto;
        [Atributo]
        public string Contacto
        {
            get { return contacto; }
            set { contacto = value; }
        }

        private string paginaWeb;
        [Atributo]
        public string Web
        {
            get { return paginaWeb; }
            set { paginaWeb = value; }
        }

       #endregion


        #region datos impositivos

        private string situacionIva;
        [Atributo]
        public string SituacionIva
        {
            get { return situacionIva; }
            set { situacionIva = value; }
        }

        private string ganancias;
        [Atributo]
        public string Ganancias
        {
            get { return ganancias; }
            set { ganancias = value; }
        }

        private long cuit_cuil;
        [Atributo]
        [Columna("Cuit / Cuil")]
        public long Cuit_cuil
        {
            get { return cuit_cuil; }
            set { cuit_cuil = value; }
        }

        private string ingresosBrutos;
        [Atributo]
        public string TipoIngresosBrutos
        {
            get { return ingresosBrutos; }
            set { ingresosBrutos = value; }
        }

        private long ingresosBrutosNum;
        [Atributo]
        public long NroIngresosBrutos
        {
            get { return ingresosBrutosNum; }
            set { ingresosBrutosNum = value; }
        }

        private long empresa_idempresa;
        [Identificador(Modificable=false)]
        [Columna("Código de Empresa", false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }


       #endregion


   }//clase
}//namespace
