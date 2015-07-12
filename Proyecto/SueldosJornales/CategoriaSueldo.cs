using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace SueldosJornales
{
    [Tabla("CategoriaSueldos")]
    public class CategoriaSueldo
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
        [Atributo]
        [Columna("Nombre de Categoría")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }


        private long sueldo;
        [Atributo(Nombre = "sueldoBasico")]
        [Columna("Sueldo Básico")]
        public long SueldoBasico
        {
            get { return sueldo; }
            set { sueldo = value; }
        }


        private bool habilitado;
        [Atributo]
        [Columna("Habilitado")]
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        private long empresa_idempresa;
        [Identificador(Modificable = false)]
        [Columna("Código de empresa", false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }

    }
}
