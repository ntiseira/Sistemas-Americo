using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace SueldosJornales
{
    public class CertificadoTrabajo
    {
        

        private long codigo;
        [Identificador(Modificable = false)]
        public long Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private DateTime fechaCertificado;
        [Atributo]
        public DateTime FechaCertificado
        {
            get { return fechaCertificado; }
            set { fechaCertificado = value; }
        }

        //escribir una descripción para el certificado de trabajo
        private string descripcion;
        [Atributo]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private long codEmpleado;
        [Identificador(Modificable = false)]
        public long CodEmpleado
        {
            get { return codEmpleado; }
            set { codEmpleado = value; }
        }

        private long codEmpresa;
        [Identificador(Modificable = false)]
        public long CodEmpresa
        {
            get { return codEmpresa; }
            set { codEmpresa = value; }
        }


    }
}
