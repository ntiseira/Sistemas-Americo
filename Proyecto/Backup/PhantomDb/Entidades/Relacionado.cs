using System;
using System.Collections;
using System.Collections.Generic;

namespace PhantomDb.Entidades
{
    public class Relacionado
    {
        string nombre;
        /// <summary>
        /// Nombre del atributo.
        /// </summary>
        internal string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        Type destino;
        public Type Destino
        {
            get { return destino; }
            set { destino = value; }
        }

        string campoDestino;
        public string CampoDestino
        {
            get { return campoDestino; }
            set { campoDestino = value; }
        }

        bool permitirNull;
        public bool PermitirNull
        {
            get { return permitirNull; }
            set { permitirNull = value; }
        }

        public bool ExisteCampoDisplay
        {
            get { return campoSecundario != campoId; }
        }

        int campoId;
        /// <summary>
        /// Campo que contiene el valor clave
        /// </summary>
        public int CampoId
        {
            get { return campoId; }
            set { campoId = value; }
        }

        int campoSecundario;
        /// <summary>
        /// Campo que tiene un string para display. Puede ser el mismo que el clave.
        /// </summary>
        public int CampoSecundario
        {
            get { return campoSecundario; }
            set { campoSecundario = value; }
        }

        string where;
        public string Where
        {
            get { return where; }
            set { where = value; }
        }

        ArrayList resultados2 = new ArrayList();

        public ArrayList Resultados2
        {
            get { return resultados2; }
            set { resultados2 = value; }
        }

        public DataSet_String Consultar = null;

        Dictionary<object, object> resultados = new Dictionary<object,object>();
        /// <summary>
        /// Llenado por armador.
        /// </summary>
        public Dictionary<object, object> Resultados
        {
            get { return resultados; }
            set { resultados = value; }
        }

        Atributos atributo = null;
        public Atributos Atributo
        {
            get { return atributo; }
            set { atributo = value; }
        }
    }
}
