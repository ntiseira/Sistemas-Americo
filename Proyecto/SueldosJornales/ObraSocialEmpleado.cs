using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace SueldosJornales
{
    [Tabla("ObrasSociales")]
    public class ObraSocialEmpleado
    {

        private long codigo;
        [Identificador(Autogenerado = true)]
        [Columna("Código")]
        public long Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private long tiposObrasSociales_empresa_idempresa;
        [Identificador(Modificable = false)]
        [Columna("Empresa", false)]
        public long TiposObrasSociales_empresa_idempresa
        {
            get { return tiposObrasSociales_empresa_idempresa; }
            set { tiposObrasSociales_empresa_idempresa = value; }
        }

        private long tiposObrasSociales_codigo;
        [Identificador(Modificable = false)]        
        [Columna("Tipo Obra Social")]
        [Relacion(Destino = typeof(ObraSocial), CampoId = 0, CampoSecundario = 1)]
        public long TiposObrasSociales_codigo
        {
            get { return tiposObrasSociales_codigo; }
            set { tiposObrasSociales_codigo = value; }
        }

        private int empleados_legajo;
        [Relacion(Destino = typeof(Entidades.Entity_empleados), CampoId = 0, CampoSecundario = 2)]
        [Columna("Empleado")]
        public int Empleados_legajo
        {
            get { return empleados_legajo; }
            set { empleados_legajo = value; }
        }

    }
}
