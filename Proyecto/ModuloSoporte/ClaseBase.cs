using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuloSoporte
{
    /// <summary>
    /// Clase que implementa la estructura básica de las tablas utilizadas en el 
    /// sistema.
    /// No da soporte a lo de habilitación y deshabilitación de clases.
    /// </summary>
    /// <seealso cref="ClaseBaseHabilitable"/>
    /// <typeparam name="T">Tipo de id.</typeparam>
    public class ClaseBase<T>
    {
        private T cod;
        public T Cod
        {
            get { return cod; }
            set { cod = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public ClaseBase()
            : this(default(T), "")
        {
        }

        public ClaseBase(T cod, string descripcion)
        {
            Cod = cod;
            Descripcion = descripcion;
        }
    }    
    
    /// <summary>
    /// Clase que implementa la estructura básica de las tablas utilizadas en el 
    /// sistema.
    /// </summary>
    /// <typeparam name="T">Tipo de id.</typeparam>
    public class ClaseBaseHabilitable<T> : ClaseBase<T>
    {
        private bool habilitado;
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }

        public ClaseBaseHabilitable()
            : this(default(T), "", false)
        {
        }

        public ClaseBaseHabilitable(T cod, string descripcion, bool habilitado)
            : base(cod, descripcion)
        {
            Habilitado = habilitado;
        }
    }
}
