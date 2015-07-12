using PhantomDb.Entidades;
namespace Siscont.AdministradorGeneral.Tablas 
{
	public class TasaIva 
    {
		/// <summary>
		/// Código identificador. Utiliza un int debido a que no se requieren demasiados.
		/// El sistema anterior usaba solo 2 dígitos.
		/// </summary>
        private int idtasaiva;
        [Identificador]
        public int Idtasaiva
        {
            get { return idtasaiva; }
            set { idtasaiva = value; }
        }

		/// <summary>
		/// Sobretasa correspondiente a los responsables inscriptos.
		/// </summary>
        private float tasaInscriptos;
        public float TasaInscriptos
        {
            get { return tasaInscriptos; }
            set { tasaInscriptos = value; }
        }

		/// <summary>
		/// Sobretasa correspondiente a los responsables no inscriptos.
		/// </summary>
        private float tasaNoInscriptos;
        public float TasaNoInscriptos
        {
            get { return tasaNoInscriptos; }
            set { tasaNoInscriptos = value; }
        }

        private int empresa_idempresa;
        [Identificador(Modificable=false)]
        public int Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }

		public TasaIva(){

		}

		~TasaIva(){

		}

		public virtual void Dispose(){

		}

	}//end TasaIva

}//end namespace Siscont.AdministradorGeneral.Tablas