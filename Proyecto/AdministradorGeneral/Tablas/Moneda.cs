
using Siscont.AdministradorGeneral.Tablas;
using System.Collections.Generic;
using ModuloSoporte;

namespace Siscont.AdministradorGeneral.Tablas 
{
	public class Moneda : ClaseBase<long>
    {
        public const int Peso = 1;
        public const int Dolar = 2;
        public const int Euro = 3;

        private string simbolo;
        /// <summary>
        /// Símbolo que representa a la moneda.
        /// </summary>
        /// <example>
        /// Ejemplo: $.
        /// </example>
        public string Simbolo
        {
            get { return simbolo; }
            set { simbolo = value; }
        }

        private IList<Cambio> cambios = new List<Cambio>();
        /// <summary>
        /// 
        /// </summary>
        public IList<Cambio> Cambios
        {
            get { return cambios; }
            set { cambios = value; }
        }

        /// <summary>
        /// 
        /// </summary>
		public Moneda(){

		}

	}//end Moneda
}//end namespace Siscont.AdministradorGeneral.Tablas