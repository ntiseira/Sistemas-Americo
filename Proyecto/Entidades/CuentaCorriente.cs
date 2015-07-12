using System;
using PhantomDb.Entidades;

namespace Entidades
{
    [Tabla("cuentacorriente")]
  public class CuentaCorriente
    {


        private long nroCuenta;
        [Identificador(Autogenerado = true)]
        [Columna(Titulo = "Numero")]
        public long NroCuenta
        {
            get { return nroCuenta; }
            set { nroCuenta = value; }
        }


          private double total;
       
        [Columna(Titulo = "Total")]
          public double Total
          {
              get { return total; }
              set { total = value; }
          }
       
        private string claveBancaria;
    
        [Columna(Titulo = "CBU")]
          public string ClaveBancaria
          {
              get { return claveBancaria; }
              set { claveBancaria = value; }
          }
          
        private int banco_idbanco1;
        [Relacion(Destino = typeof(Entity_banco), CampoId = 0, CampoSecundario = 1)]
          public int banco_idbanco
          {
              get { return banco_idbanco1; }
              set { banco_idbanco1 = value; }
          }
       
        private long banco_empresa_idempresa1;
        [Columna(Visible = false)]
          public long banco_empresa_idempresa
          {
              get { return banco_empresa_idempresa1; }
              set { banco_empresa_idempresa1 = value; }
          }

          private int cliente_codCliente1;
        [Columna(Visible = false)]
          public int cliente_codCliente
          {
              get { return cliente_codCliente1; }
              set { cliente_codCliente1 = value; }
          }

          private long cliente_empresa_idempresa1;
        [Columna(Visible = false)]
          public long cliente_empresa_idempresa
          {
              get { return cliente_empresa_idempresa1; }
              set { cliente_empresa_idempresa1 = value; }
          }




    }
}
