using System;
using System.Collections.Generic;
using System.Text;

namespace PhantomDb.Entidades
{
    public enum EnumDebil
    {
        Ninguno,
        Origen,
        Destino
    }

    [AttributeUsage(
        AttributeTargets.Property | AttributeTargets.Field |
        AttributeTargets.Parameter | AttributeTargets.ReturnValue
        , AllowMultiple = false)]
    public class Relacion : Attribute
    {
        EnumDebil debil;
        /// <summary>
        /// Indica el destino de la relación. SIRVE REALMENTE???
        /// </summary>
        public EnumDebil Debil
        {
            get { return debil; }
            set { debil = value; }
        }

        Type destino;
        public Type Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        int campoId = 0;
        /// <summary>
        /// Campo que contiene el valor clave
        /// </summary>
        public int CampoId
        {
            get { return campoId; }
            set { campoId = value; }
        }

        int campoSecundario = 0;
        /// <summary>
        /// Campo que tiene un string para display. Puede ser el mismo que el clave.
        /// </summary>
        public int CampoSecundario
        {
            get { return campoSecundario; }
            set { campoSecundario = value; }
        }

        bool permitirNull = false;
        /// <summary>
        /// Indica si la fk es o no es NOT NULL.
        /// </summary>
        public bool PermitirNull
        {
            get { return permitirNull; }
            set { permitirNull = value; }
        }

        string where;
        /// <summary>
        /// {d} = destino, {o} = origen
        /// </summary>
        public string Where
        {
            get { return where; }
            set { where = value; }
        }

        public Relacion()
            : this(EnumDebil.Ninguno, null)
        {

        }

        public Relacion(EnumDebil debil, Type destino)
        {
            CampoId = 0;
            CampoSecundario = 0;
            Debil = debil;
            Destino = destino;
        }
    }
}
