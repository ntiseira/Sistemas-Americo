using System;
using System.Collections.Generic;
using System.Text;
using PhantomDb.Entidades;
using Entidades;

namespace AdministradorGeneral.Tablas
{
    /// <summary>
    /// Combinación manual de Entidades.cheque y Entidades.chequeterceros.
    /// </summary>
    [Heredar(typeof(Entity_cheque))]
    [Tabla("chequedeterceros")]
    public class ChequeTerceros : Entidades.Entity_cheque
    {
        private int cliente_codcliente;
        [Relacion(Destino = typeof(Entity_cliente), CampoId = 0, CampoSecundario = 0)]
        public int Cliente_codcliente
        {
            get { return cliente_codcliente; }
            set { cliente_codcliente = value; }
        }
    }
}
