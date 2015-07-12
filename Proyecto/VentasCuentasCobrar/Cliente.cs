using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos.VentasCuentasCobrar;


namespace VentasCuentasCobrar
{
    public class Cliente
    {
       private long codigoCliente;
       private string razonSocial;
       private string mail;
       private string comentario;
       private string direccion;
       private string localidad;
       private int codigoPostal;
       private Provincia provincia;
       private long telefono;       
       private long fax;
       //private DatosImpositivoCliente datosImpositivos;       
        #warning VER COMO FUNCIONA EL TEMA DE LA CUENTA CORRIENTE        
        private CuentaCorriente cuentaCorriente;
        private DatosAdicionales datosAdicionaleS;
        private Contrato contratos;
        //private MiembroEmpresa miembrosEmpresa; //SE DETALLAN TODOS LOS MIEMBROS DE LA EMPRESA

        public Cliente(string razonSocial, string mail, string comentario, string direccion,
            string localidad, int cod, Provincia prov, long tel , long fax) 
        {
            //asignarCodCliente();
            this.razonSocial = razonSocial;
            this.mail = mail;
            this.comentario = comentario;
            this.direccion = direccion;
            this.localidad = localidad;
            codigoPostal = cod;
            provincia = prov;
            telefono = tel;
            this.fax = fax;
        }


        public Cliente(int codigoCliente,string razonSocial, string mail, string comentario, string direccion,
            string localidad, int cod, Provincia prov, long tel, long fax)
        {
            this.codigoCliente = codigoCliente;
            this.razonSocial = razonSocial;
            this.mail = mail;
            this.comentario = comentario;
            this.direccion = direccion;
            this.localidad = localidad;
            codigoPostal = cod;
            provincia = prov;
            telefono = tel;
            this.fax = fax;            
        }


        //OBTENGO EL CODIGO DEL CLIENTE GENERADO MEDIANTE UNA CONSULTA SQL 
        private void asignarCodCliente()
        {


            codigoCliente = Datos.getCodigoCliente();
        }


        #region ABM 

        //ALTA DE CLIENTE
        public bool agregarCliente()
        {
            
         
          return Datos.agregarCliente(codigoCliente,razonSocial, mail, comentario, direccion,localidad, codigoPostal,provincia.Descripcion, telefono ,  fax);
        
         #warning agregar que de de alta los datos impositivos al agregar un cliente
        
        }

        //BAJA DE CLIENTE
        public static bool eliminarCliente(int cod)
        {
         //Primero validar el cliente y después eliminarlo
            if (Datos.verificarCliente(cod))
            {               
                return Datos.eliminarCliente(cod);
            }
            else 
            {
                return false;
            }
            
        }
        
        //ACTUALIZAR CLIENTE
        public bool actualizarCliente()
        {           
          return Datos.actualizarCliente(codigoCliente,razonSocial, mail, comentario, direccion,localidad, codigoPostal, provincia.Descripcion, telefono , fax);
        }


        #endregion
       









    }//clase
}//namespace
