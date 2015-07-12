using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace Entidades
{
    public class AnulacionComprobanteVenta
    {

        private int codigo;
        [Identificador]
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private DateTime fechaAnulacion;
        public DateTime FechaAnulacion
        {
            get { return fechaAnulacion; }
            set { fechaAnulacion = value; }
        }



        private long comprobantesventa_idcomprobantesventa;
        [Identificador]
        public long Comprobantesventa_idcomprobantesventa
        {
            get { return comprobantesventa_idcomprobantesventa; }
            set { comprobantesventa_idcomprobantesventa = value; }
        }



        private long comprobantesventa_empresa_idempresa;
        [Identificador]
        [Columna(false)]
        public long Comprobantesventa_empresa_idempresa
        {
            get { return comprobantesventa_empresa_idempresa; }
            set { comprobantesventa_empresa_idempresa = value; }
        }


    }
}
