using System;
using PhantomDb.Entidades;

namespace SueldosJornales
{
    [Tabla("Feriados")]
    public class Feriado
    {
        private int feriadosCol;
        [Identificador(Autogenerado = true)]
        [Columna("Código de Feriado")]
        public int FeriadosCol
        {
            get { return feriadosCol; }
            set { feriadosCol = value; }
        }

        private string descripcion;
        [Atributo]
        [Columna("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private DateTime fecha;
        [Atributo]
        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private long empresa_idempresa;
        [Identificador(Nombre = "empresa_idempresa")]
        [Columna("Código de Empresa")]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }
    }
}
