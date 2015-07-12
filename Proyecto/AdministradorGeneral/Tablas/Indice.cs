using Siscont.AdministradorGeneral.Tablas;
using PhantomDb.Entidades;
using System.Collections.Generic;

namespace Siscont.AdministradorGeneral.Tablas 
{
	public class Indice 
    {
        private int idindice;
        [Identificador(Modificable = false)]
        public int Idindice
        {
            get { return idindice; }
            set { idindice = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private bool habilitado;
        [IgnorarAtributo]
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private long empresa_idempresa;
        [Identificador(Modificable=false)]
        [Columna(false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }

        [IgnorarAtributo]
        public IList<ValorIndice> Valores
        {
            get { return null; }
        }

        public Indice()
        {

		}

	}//end Índice
}