using PhantomDb.Entidades;

namespace SueldosJornales
{
    /*Esta tiene directa relación con el domicilio de explotación requerido para
    información del ANSES y con la Zona para la reducción de contribu-ciones
    patronales.*/
    [Tabla("lugarespago")]
    public class LugaresPago
    {

        private string codigo;
        [Identificador(Autogenerado = true)]
        [Columna("Código")]
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private string calle;
        public string Calle
        {
            get { return calle; }
            set { calle = value; }
        }

        private int numeroCalle;
        [Columna("Nro. Calle")]
        public int NumeroCalle
        {
            get { return numeroCalle; }
            set { numeroCalle = value; }
        }

        private int piso;
        public int Piso
        {
            get { return piso; }
            set { piso = value; }
        }

        private int departamento;
        public int Departamento
        {
            get { return departamento; }
            set { departamento = value; }
        }

        private string localidad;
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        private int codigoPostal;
        [Columna("Código Postal")]
        public int CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        private string provincia;
        [Relacion(Destino = typeof(Entidades.Entity_provincia), CampoId = 0, CampoSecundario = 1)]
        [Columna("Provincia")]
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }


        private bool habilitado;
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }


        private bool domicilioExplotacion;
        [Columna("Es Domicilio explotación")]
        public bool DomicilioExplotacion
        {
            get { return domicilioExplotacion; }
            set { domicilioExplotacion = value; }
        }


        private long empresa_idempresa;
        [Identificador(Modificable = false)]
        [Columna("Empresa", false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }
        


      /*  domicilioExplotacion: verificación si el lugar de pago que se define es considerado domicilio de explotación para la información
que se remite al ANSES de acuerdo a la Resolución 551/97. Si
se marca esta casilla se habilitan:
     Código de Domicilio de Explotación: indicar el código correspondiente.
No se permite el código 1 puesto que este pertenece al domicilio fiscal.
     Presentado: marcar esta casilla si la información correspondiente se
encuentra presentada al ANSES. Cuando se genera el archivo ASCII
definitivo correspondiente a la información requerida esta casilla se marca
automáticamente.*/

    }
}
