using System;
using System.Collections;
using PhantomDb.Armadores;

namespace PhantomDb
{
    public abstract class PDBHelperAbstract
    {
        protected abstract Armador GetArmador(Type t);

        public Armador ObtenerArmador(Type t)
        {
            return GetArmador(t);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="condiciones">Where.</param>
        /// <returns></returns>
        public object Cargar(Type t, string condiciones)
        {
            Armador arm = GetArmador(t);
            arm.CargarInstancia(condiciones);
            return arm.InstanciaAsociada;
        }

        public object Cargar(object pretabla)
        {
            return GetArmador(pretabla.GetType()).ObtenerInstancia(pretabla);
        }

        public void Modificar(object tabla)
        {
            GetArmador(tabla.GetType()).ModificarInstancia(tabla);
        }

        public void Insertar(object tabla)
        {
            GetArmador(tabla.GetType()).Insertar(tabla);
        }

        public bool Existe(object pretabla)
        {
            return GetArmador(pretabla.GetType()).ExisteObjeto(pretabla);
        }

        public IList Listar(Type t)
        {
            return GetArmador(t).CargarInstancias();
        }

        public IList Listar(Type t, string where)
        {
            return GetArmador(t).CargarInstancias(where);
        }

        public void Eliminar(object pretabla)
        {
            GetArmador(pretabla.GetType()).Eliminar(pretabla);
        }

        /// <summary>
        /// Obtiene un objeto si existe, y si no, lo crea y lo devuelve.
        /// </summary>
        /// <param name="pretabla"></param>
        /// <returns></returns>
        public object ObtenerCrear(object pretabla)
        {
            if (Existe(pretabla))
            {
                return Cargar(pretabla);
            }
            else
            {
                this.Insertar(pretabla);
                return pretabla;
            }
        }
    }
}
