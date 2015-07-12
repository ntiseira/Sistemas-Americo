using System;
using System.Collections.Generic;
using PhantomDb.Entidades;
using Entidades;
using System.Collections;

namespace Siscont.Contabilidad
{
    public class Asiento
    {
        Entity_asiento datos;
        public Entity_asiento Datos
        {
            get { return datos; }
            set { datos = value; }
        }

        public int IdAsiento
        {
            get { return Datos.Idasiento; }
        }

        public string Tipoasiento_descripcion
        {
            get { return Datos.Tipoasiento_descripcion; }
        }

        /// <summary>
        /// Fecha de creación del asiento.,
        /// </summary>
        public DateTime Fecha
        {
            get { return Datos.Fecha; }
            set { Datos.Fecha = value; }
        }

        EstadoAsiento estado;
        [IgnorarAtributo]
        public EstadoAsiento Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        IList<Movimiento> movimientos;
        [IgnorarAtributo]
        public IList<Movimiento> Movimientos
        {
            get 
            {
                if (movimientos == null)
                {
                    this.ActualizarMovimientos();
                }
                return movimientos; 
            }
            set { movimientos = value; }
        }

        /// <summary>
        /// Carga los movimientos pertenecientes al asiento.
        /// </summary>
        public void ActualizarMovimientos()
        {
            movimientos = new List<Movimiento>();
            IList entidades = CapaDatos.Datos.Phantom.Listar(typeof(Entity_movimiento),
                string.Format("asiento_idasiento={0} AND asiento_ejercicio_codejercicio={1} AND asiento_ejercicio_empresa_idempresa={2}",
                Datos.Idasiento, Datos.Ejercicio_codejercicio, Datos.Ejercicio_empresa_idempresa
                ));

            foreach (Entity_movimiento ent in entidades)
            {
                movimientos.Add(new Movimiento(ent));
            }
        }

        [IgnorarAtributo]
        public float Debe
        {
            get
            {
                float debe = 0.0f;
                foreach (Movimiento p in Movimientos)
                {
                    debe += p.Debe;
                }
                return debe;
            }
        }

        [IgnorarAtributo]
        public float Haber
        {
            get
            {
                float haber = 0.0f;
                foreach (Movimiento p in Movimientos)
                {
                    haber += p.Haber;
                }
                return haber;
            }
        }

        [IgnorarAtributo]
        public float Balance
        {
            get { return Haber - Debe; }
        }

        [IgnorarAtributo]
        public bool Balanceado
        {
            get { return Haber == Debe; }
        }

        public Asiento()
        {
            Datos = new Entity_asiento();
            Estado = EstadoAsiento.Borrador;
            Datos.Editable = true;
            Movimientos = null;
        }

        public Asiento(Entity_asiento datos)
        {
            Estado = EstadoAsiento.Borrador;
            Movimientos = null;
            Datos = datos;
            ActualizarMovimientos();
        }
    }
}
