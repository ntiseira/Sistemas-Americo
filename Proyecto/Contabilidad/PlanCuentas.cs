using ModuloSoporte;
using System.Collections.Generic;
using Entidades;
using System.Collections;
using System.Text;
using System;

namespace Siscont.Contabilidad
{
    /// <summary>
    /// Plan de Cuentas.
    /// </summary>
    public class PlanCuentas
    {
        Entity_planCuentas datos;
        public Entity_planCuentas Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        IList<Entity_jerarquia> caracteresPorNivel;
        public IList<Entity_jerarquia> CaracteresPorNivel
        {
            get
            {
                if (caracteresPorNivel == null)
                {
                    this.ActualizarCaracteresPorNivel();
                }
                return caracteresPorNivel;
            }
            set { caracteresPorNivel = value; }
        }

        /// <summary>
        /// Carga los movimientos pertenecientes al asiento.
        /// </summary>
        public void ActualizarCaracteresPorNivel()
        {
            caracteresPorNivel = new List<Entity_jerarquia>();
            var entidades = CapaDatos.Datos.Phantom.Listar(typeof(Entity_jerarquia),
                string.Format("plancuentas_codplancuentas={0} AND plancuentas_ejercicio_codejercicio={1} AND plancuentas_ejercicio_empresa_idempresa={2}",
                Datos.Codplancuentas, Datos.Ejercicio_codejercicio, Datos.Ejercicio_empresa_idempresa
                ));

            foreach (Entity_jerarquia ent in entidades)
            {
                caracteresPorNivel.Add(ent);
            }
        }

        /// <summary>
        /// Genera una máscara, usando los caracteres por nivel.
        /// </summary>
        /// <returns></returns>
        public string GenerarMascara()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var nivel in this.CaracteresPorNivel)
            {
                sb.Append('0', nivel.Caracteres);
                sb.Append(".");
            }

            return sb.ToString().Remove(sb.Length - 1); // Devuelvo un string, removiéndole el . final
        }

        /// <summary>
        /// Aplica la máscara a un determinado código.
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        public string Enmascarar(long codigo)
        {
            return String.Format(DesenchularMascara(this.Datos.Mascara), codigo);
        }

        /// <summary>
        /// Quita el formato atractivo de la máscara, y la convierte en una máscara utilizable.
        /// </summary>
        /// <param name="mascara"></param>
        /// <returns></returns>
        private string DesenchularMascara(string mascara)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{0:");
            sb.Append(mascara);
            sb.Append(";Error;Error}");
            return sb.ToString();
        }
    }
}
