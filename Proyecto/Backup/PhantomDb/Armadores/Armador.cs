using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using PhantomDb.Entidades;

namespace PhantomDb.Armadores
{
    public partial class Armador
    {
        #region Atributos

        string nombre = "";
        /// <summary>
        /// Nombre de la tabla.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        Type tipo;
        /// <summary>
        /// Tipo.
        /// </summary>
        public Type Tipo
        {
            get { return tipo; }
            protected set { tipo = value; }
        }

        IList<Atributos> identificadores;
        /// <summary>
        /// Atributos identificadores.
        /// </summary>
        public IList<Atributos> Identificadores
        {
            get { return identificadores; }
            set { identificadores = value; }
        }

        IList<Atributos> atributos;
        /// <summary>
        /// Atributos.
        /// </summary>
        public IList<Atributos> Atributos
        {
            get { return atributos; }
            set { atributos = value; }
        }

        Dictionary<string, Columnas> columnas;
        /// <summary>
        /// Columnas.
        /// </summary>
        public Dictionary<string, Columnas> Columnas
        {
            get { return columnas; }
            set { columnas = value; }
        }

        List<Relacionado> relaciones;
        /// <summary>
        /// Relaciones.
        /// </summary>
        public List<Relacionado> Relaciones
        {
            get { return relaciones; }
            set { relaciones = value; }
        }

        object instanciaAsociada = null;
        /// <summary>
        /// Instancia asociada al armador.
        /// </summary>
        public object InstanciaAsociada
        {
            get { return instanciaAsociada; }
            set
            {
                instanciaAsociada = value;
                foreach (Atributos a in Atributos)
                {
                    a.Instancia = value;
                }
            }
        }

        /// <summary>
        /// Indica si el armador posee un atributo autonumérico.
        /// </summary>
        public bool PoseeAutonumerico 
        {
            get
            {
                foreach (var a in Atributos)
                {
                    if (a.Autogenerado)
                        return true;
                }

                return false;
            }
        }

        #endregion

        public Armador()
            : base()
        {
        }

        public Armador(Type t)
            : this(t, null)
        {
        }

        public Armador(Type t, object o)
            : this(t, o, null)
        {

        }

        public Armador(Type t, object o, DataSet_String consultar)
        {
            this.Consultar = consultar;
            this.GenerarNombreArmador(t);
            Atributos = new List<Atributos>();
            Identificadores = new List<Atributos>();
            Columnas = new Dictionary<string, Columnas>();
            Relaciones = new List<Relacionado>();
            InstanciaAsociada = o;
            Tipo = t;
        }

        /// <summary>
        /// Agrega un atributo.
        /// </summary>
        /// <param name="a"></param>
        public void Agregar(Atributos a)
        {
            Atributos.Add(a);
        }

        /// <summary>
        /// Obtiene un atributo en base a su nombre en tabla.
        /// </summary>
        /// <param name="nombre">Nombre, no importan mayúsculas o minúsculas.</param>
        /// <returns></returns>
        public Atributos GetAtributo(string nombre)
        {
            int i = 0;

            while (i < Atributos.Count && !Atributos[i].Nombre.ToLower().Equals(nombre.ToLower()))
            {
                i++;
            }

            if (i < Atributos.Count)
            {
                return Atributos[i];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Agrega un atributo, y lo coloca en la lista de identificadores.
        /// </summary>
        /// <param name="a"></param>
        public void AgregarIdentificador(Atributos a)
        {
            Identificadores.Add(a);
            Atributos.Add(a);
        }

        private Atributos EncontrarAtributo(string atributo)
        {
            foreach (Atributos a in Atributos)
            {
                if (a.Atributo.Equals(atributo))
                    return a;
            }

            return null;
        }

        public bool EsIdentificador(Atributos a)
        {
            foreach (Atributos i in Identificadores)
            {
                if (a.Nombre.Equals(i.Nombre))
                {
                    return true;
                }
            }

            return false;
        }

        internal void AgregarColumna(Columnas c)
        {
            Columnas.Add(c.Nombre, c);
        }

        internal void AsociarColumnas()
        {
            foreach (Columnas c in Columnas.Values)
            {
                Atributos at = EncontrarAtributo(c.Nombre);
                if (at != null)
                {
                    at.Columna = c;
                }
            }
        }
        internal void AsociarRelaciones()
        {
            foreach (var r in Relaciones)
            {
                Atributos at = EncontrarAtributo(r.Nombre);
                if (at != null)
                {
                    at.Relacion = r;
                }
            }
        }

        internal void AgregarRelacion(Relacionado r)
        {
            if (this.Consultar != null)
            {
                Relaciones.Add(r);
                var matcheador = new ArmadorFactory(this.Consultar).CreateFromClass(r.Destino);
                string select;

                if (r.ExisteCampoDisplay)
                {
                    select = string.Format(
                        "d.{0}, d.{1}",
                        matcheador.Atributos[r.CampoId].Nombre,
                        matcheador.Atributos[r.CampoSecundario].Nombre);
                }
                else
                {
                    select = string.Format("d.{0}",
                        matcheador.Atributos[r.CampoId].Nombre);
                }

                DataSet ds;
                //if (r.Where.Equals(""))
                //{
                ds = matcheador.Consultar(string.Format("SELECT * FROM {0}", matcheador.Nombre));
                //}
                //else
                //{
                //    ds = matcheador.Consultar(string.Format(
                //    "SELECT {0} FROM d.{1}, o.{2} WHERE {3};", "d.*", matcheador.Nombre, Nombre, r.Where.Replace("{d}","d").Replace("{o}","o")
                //    ));
                //}

                foreach (ArrayList objeto in DataSetProcessor.GetTotalObjetos(ds)) // Code from Armador.CargarInstancias
                {
                    matcheador.InstanciaAsociada = null;
                    matcheador.AsignarAtributos(objeto);
                    matcheador.CopyToInstance();
                    List<Atributos> atributos = new List<Atributos>();
                    foreach (Atributos at in matcheador.Atributos)
                    {
                        atributos.Add(at.Clone());
                    }
                    r.Resultados2.Add(atributos);
                    r.Resultados.Add(
                        matcheador.Atributos[r.CampoId].Valor,
                        matcheador.Atributos[r.CampoSecundario].Valor.ToString());

                }
            }
        }

        /// <summary>
        /// ToString.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Nombre);
            return sb.ToString();
        }
    }
}
