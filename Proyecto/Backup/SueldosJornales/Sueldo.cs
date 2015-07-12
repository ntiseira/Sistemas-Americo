using PhantomDb.Entidades;

namespace SueldosJornales
{
    [Tabla("Sueldos")]
    public class Sueldo : Clases.Mensual
    {
        
        private string codigo;
        [Identificador(Autogenerado = true)]
        [Columna("Código")]
        public string Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string categoria;
        [Atributo(Nombre = "CategoriaSueldos_codigo")]
        [Columna("Categoría")]
        [Relacion(Destino = typeof(CategoriaSueldo), CampoId = 0, CampoSecundario = 1)]
        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }


        private long empleados_empresa_idempresa;
        [Atributo(Nombre = "empleados_sucursal_empresa_idempresa")]
        [Columna("Empresa", false)]
        public long Empleados_empresa_idempresa
        {
            get { return empleados_empresa_idempresa; }
            set { empleados_empresa_idempresa = value; }
        }

        private long codigo_sucursal;
        [Atributo(Nombre = "empleados_sucursal_codigoSucursal")]
        [Columna("Sucursal")]
        public long Codigo_sucursal
        {
            get { return codigo_sucursal; }
            set { codigo_sucursal = value; }
        }


        private long empleados_legajo;
        [Atributo]
        [Columna("Legajo de empleado")]
        [Relacion(Destino = typeof(Entidades.Entity_empleados), CampoId = 0, CampoSecundario = 2)]
        public long Empleados_legajo
        {
            get { return empleados_legajo; }
            set { empleados_legajo = value; }
        }


        private long liquidacion_codigo;
        [Atributo]
        public long Liquidacion_codigo
        {
            get { return liquidacion_codigo; }
            set { liquidacion_codigo = value; }
        }


    }
}
