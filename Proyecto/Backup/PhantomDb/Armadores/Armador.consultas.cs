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
        public DataSet_String Consultar = null;

        #region Consultas
        /// <summary>
        /// Asocia el objeto, copia sus valores, y los inserta en la base 
        /// de datos.
        /// </summary>
        public void Insertar(object o)
        {
            this.AsociarYLeer(o);
            this.Insertar();
        }

        /// <summary>
        /// Ejecuta un Insert (inserta el objeto en la base de datos).
        /// </summary>
        public void Insertar()
        {
            if (!this.PoseeAutonumerico)
            {
                this.Consultar(
                    "INSERT INTO " + Nombre + "(" + NombresInsertSeparadosPorComa + ")" +
                    " VALUES (" + ValoresInsertSeparadosPorComa + ")");
            }
            else
            {
                var id = this.Consultar(
                            "INSERT INTO " + Nombre + "(" + NombresInsertSeparadosPorComa + ")" +
                            " VALUES (" + ValoresInsertSeparadosPorComa + "); SELECT LAST_INSERT_ID();");

                this.SetValorAutonumerico(DataSetProcessor.GetValor(id));
            }
        }

        /// <summary>
        /// Modifica el valor del atributo autonumérico.
        /// </summary>
        /// <param name="valor"></param>
        private void SetValorAutonumerico(object valor)
        {
            foreach (var a in Atributos)
            {
                if (a.Autogenerado)
                {
                    a.Valor = FromString.GetFromString(a.Tipo, valor.ToString());
                    a.EscribirEnInstancia();
                    return;
                }
            }
        }

        /// <summary>
        /// Modifica el valor de un atributo.
        /// </summary>
        /// <param name="nombre">Nombre del atributo.</param>
        /// <param name="valor">Nuevo valor.</param>
        public void Modificar(string nombre, object valor)
        {
            Atributos a = this.GetAtributo(nombre);
            a.Valor = valor;

            Consultar(
            string.Format(
                "UPDATE {0} SET {1} = {2} WHERE {3}",
                this.Nombre, a.Nombre, this.ValorToBd(a), this.ValoresWhere)
            );
        }

        /// <summary>
        /// Modifica el valor de todos los atributos en la base de datos.
        /// </summary>
        public void ModificarTodo()
        {
            Consultar(
            string.Format(
                "UPDATE {0} SET {1} WHERE {2}",
                this.Nombre, this.UpdateValores, this.ValoresWhere)
            );
        }

        /// <summary>
        /// Elimina la instancia en la base de datos.
        /// </summary>
        /// <param name="o">Instancia a asociar para luego eliminar.</param>
        public void Eliminar(object o)
        {
            this.AsociarYLeer(o);
            this.Eliminar();
        }

        /// <summary>
        /// Elimina la instancia asociada de la base de datos.
        /// </summary>
        public void Eliminar()
        {
            Consultar(
                string.Format("DELETE FROM {0} WHERE {1}", Nombre, this.ValoresWhere)
                );
        }

        /// <summary>
        /// Carga todas las tuplas.
        /// </summary>
        public IList CargarInstancias()
        {
            return CargarInstancias("");
        }

        /// <summary>
        /// Obtiene una entidad de una base de datos, usando los valores de los
        /// identificadores de una "pretabla", es decir, un objeto parcialmente
        /// inicializado (solo se le han inicializado los identificadores).
        /// </summary>
        /// <param name="pretabla"></param>
        /// <returns></returns>
        public object ObtenerInstancia(object pretabla)
        {
            this.AsociarYLeer(pretabla);
            this.CargarInstancia();
            return InstanciaAsociada;
        }

        /// <summary>
        /// Carga una instancia de la base de datos, usando los id actuales.
        /// </summary>
        public void CargarInstancia()
        {
            DataSet ds = Consultar(
                string.Format("SELECT * FROM {0} WHERE {1}", Nombre, ValoresWhere)
                );

            object[] o = DataSetProcessor.GetValores(ds);

            AsignarAtributos(o);
        }

        public IList CargarInstancias(string condiciones)
        {
            DataSet ds;

            if (condiciones == null || condiciones.Equals(""))
            {
                ds = Consultar(
                    string.Format("SELECT * FROM {0}", Nombre)
                    );
            }
            else
            {
                ds = Consultar(
                    string.Format("SELECT * FROM {0} WHERE {1}", Nombre, condiciones)
                    );
            }

            IList instancias = new ArrayList();

            foreach (ArrayList objeto in DataSetProcessor.GetTotalObjetos(ds))
            {
                // Al desasociar la instancia, el armador se ve obligado a crear una nueva.
                this.InstanciaAsociada = null;
                // Asigno los atributos
                this.AsignarAtributos(objeto);
                this.CopyToInstance();
                instancias.Add(this.InstanciaAsociada);
            }

            return instancias;
        }

        /// <summary>
        /// Carga una instancia de la base de datos.
        /// </summary>
        public object CargarInstancia(string condiciones)
        {
            DataSet ds;

            if (condiciones == null || condiciones.Equals(""))
            {
                ds = Consultar(
                    string.Format("SELECT * FROM {0}", Nombre)
                    );
            }
            else
            {
                ds = Consultar(
                    string.Format("SELECT * FROM {0} WHERE {1}", Nombre, condiciones)
                    );
            }

            ArrayList objeto = DataSetProcessor.GetObjeto(ds);

            this.InstanciaAsociada = null;
            // Asigno los atributos
            this.AsignarAtributos(objeto);
            this.CopyToInstance();

            return this.InstanciaAsociada;
        }

        public int Count
        {
            get
            {
                DataSet ds = Consultar("SELECT COUNT(*) FROM " + Nombre);
                return int.Parse(DataSetProcessor.GetValor(ds).ToString());
            }
        }

        public bool Existe(string condiciones)
        {
            DataSet ds = Consultar(
                string.Format("SELECT * FROM {0} WHERE {1}", Nombre, condiciones)
            );

            return !DataSetProcessor.EstaVacio(ds);
        }

        public bool Existe()
        {
            DataSet ds = Consultar(
                string.Format("SELECT * FROM {0} WHERE {1}", Nombre, ValoresWhere)
            );

            return !DataSetProcessor.EstaVacio(ds);
        }

        /// <summary>
        /// Indica si existe el objeto asociado en la base de datos.
        /// Busca al objeto en base a su id.
        /// </summary>
        /// <returns></returns>
        public bool ExisteObjeto(object o)
        {
            this.AsociarYLeer(o);
            return this.Existe();
        }

        /// <summary>
        /// Modifica la instancia, dentro de la base de datos.
        /// </summary>
        /// <param name="tabla"></param>
        /// <returns></returns>
        public void ModificarInstancia(object tabla)
        {
            this.AsociarYLeer(tabla);
            this.ModificarTodo();
        }
        #endregion
    }
}
