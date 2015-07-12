using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;
namespace AdministradorGeneral.Empresas
{

 public class TipoConcepto
    {

        private int codigo;
        [Identificador(Modificable = false)]
        [Columna("Código")]
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        private string descripcion;

        [Columna("Descripcion")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private bool habilitado;

        [Columna("Habilitado")]
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }


        private long codEmpresa;
        [Identificador(Modificable = false)]
        [Columna("Código de empresa", false)]
        public long empresa_idempresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }
 
 
    }//clase
}//namespace
