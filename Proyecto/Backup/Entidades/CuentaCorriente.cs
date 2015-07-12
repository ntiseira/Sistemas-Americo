using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace Entidades
{
    [Tabla("cuentacorriente")]
    public class CuentaCorriente
    {

        private int nroCuenta;
        [Identificador(Autogenerado = true)]
        [Columna("Nro de cuenta")]
        public int NroCuenta
        {
            get { return nroCuenta; }
            set { nroCuenta = value; }
        }

        private string claveBancaria;    
        [Columna("Clave CBU")]
        public string ClaveBancaria
        {
            get { return claveBancaria; }
            set { claveBancaria = value; }
        }

        private double debe;
        public double Debe
        {
            get { return debe; }
            set { debe = value; }
        }

        private double haber;
        public double Haber
        {
            get { return haber; }
            set { haber = value; }
        }

        private double total;
        public double Total
        {
            get { return total; }
            set { total = value; }
        }

        private int banco_idbanco;

        public int Banco_idbanco
        {
            get { return banco_idbanco; }
            set { banco_idbanco = value; }
        }

        private long banco_empresa_idempresa;

        public long Banco_empresa_idempresa
        {
            get { return banco_empresa_idempresa; }
            set { banco_empresa_idempresa = value; }
        }
        private int cliente_codCliente;

        public int Cliente_codCliente
        {
            get { return cliente_codCliente; }
            set { cliente_codCliente = value; }
        }

        private long cliente_empresa_idempresa;

        public long Cliente_empresa_idempresa
        {
            get { return cliente_empresa_idempresa; }
            set { cliente_empresa_idempresa = value; }
        }






    }//clase
}//namespace
