using PhantomDb.Entidades;

namespace Siscont.Contabilidad
{
    public class TipoAsiento
    {
        private string descripcion;
        [Identificador(Modificable=true)]
        [Columna("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private bool habilitado;
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private long codEmpresa;
        [Identificador(Modificable = false, Nombre = "empresa_idempresa")]
        [Columna("Código de empresa", false)]
        public long CodEmpresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }

        public TipoAsiento()
        {
        }
    }
}
