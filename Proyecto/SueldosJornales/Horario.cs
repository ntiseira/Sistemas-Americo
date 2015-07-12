using PhantomDb.Entidades;

namespace SueldosJornales
{
    [Tabla("Horarios")]
    public class Horario
    {

        private long idHorarios;
        [Identificador(Autogenerado = true)]
        [Columna("Código de Horario")]
        public long IdHorarios
        {
            get { return idHorarios; }
            set { idHorarios = value; }
        }

        private string horarioEntrada;
        [Columna("Horario de entrada")]
        public string HorarioEntrada
        {
            get { return horarioEntrada; }
            set { horarioEntrada = value; }
        }

        private string horarioSalida;
        [Columna("Horario de salida")]
        public string HorarioSalida
        {
            get { return horarioSalida; }
            set { horarioSalida = value; }
        }

        private long empleados_legajo;
        [Relacion(Destino = typeof(Entidades.Entity_empleados), CampoId = 0, CampoSecundario = 2)]
        [Columna("Empleado")]
        public long Empleados_legajo
        {
            get { return empleados_legajo; }
            set { empleados_legajo = value; }
        }

        private long empleados_empresa_idempresa;
        [Columna("Empresa", false)]
        public long empleados_sucursal_empresa_idempresa
        {
            get { return empleados_empresa_idempresa; }
            set { empleados_empresa_idempresa = value; }
        }

        private long empleados_sucursal_codigoSucursal;
        [Columna("Sucursal")]
        public long Empleados_sucursal_codigoSucursal
        {
            get { return empleados_sucursal_codigoSucursal; }
            set { empleados_sucursal_codigoSucursal = value; }
        }

    }
}
