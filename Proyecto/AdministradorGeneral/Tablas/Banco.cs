using PhantomDb.Entidades;

namespace Siscont.AdministradorGeneral.Tablas
{
    public class Banco
    {
        private int idbanco;
        [Identificador]
        [Columna("Código")]
        public int Idbanco
        {
            get { return idbanco; }
            set { idbanco = value; }
        }

        private string descripcion;
        [Columna("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private long empresa_idempresa;
        [Identificador]
        [Columna(false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }

        public Banco()
        {

        }
    }
}