using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos.VentasCuentasCobrar; // ver aca


namespace AdministradorGeneral.Empresas.Empleados
{
    public class Empleado
    {
        private long codigoEmpleado;
        private string tipo;
        private string categoria;
        private string apellidoNombre;
        private string estadoCivil;
        private string tipoDoc;
        private long nroDocumento;
        private string nacionalidad;
        private DateTime fechaNacimiento;
        private string domicilio;
        private string localidad;
        private string codigoPostal;
        private Provincia provincia;
        private string telefono;
        private string mail;
        private double capitalInicial;
        private bool garantia; //ver este atributo
        private string composcicionCapital; //indica como se compone el capital (bienes, derechos, etc)
        private string cargo; //cargo que ocupa en la empresa (gerente, presidente,etc)
        private bool clienteEstudio; //indica si el miembro de la sociedad tmb es cliente del estudio como persona fisica
        private DatosFamiliares datosFamiliares;
        private Aportes aportes;


        public Empleado(long cEmp, string t, string c, string an, string ec, string tdoc, long ndoc, string nac, DateTime fechaNac, string dom, 
            string loc, string cp, Provincia pro, string tel, string m, double capI, bool g, string comCap, string car, bool cE, DatosFamiliares datosf, Aportes apor)
        {
            codigoEmpleado = cEmp;
            tipo = t;
            categoria = c;
            apellidoNombre = an;
            estadoCivil = ec;
            tipoDoc = tdoc;
            nroDocumento = ndoc;
            nacionalidad = nac;
            fechaNacimiento = fechaNac;
            domicilio = dom;
            localidad = loc;
            codigoPostal = cp;
            provincia = pro;
            telefono = tel;
            mail = m;
            capitalInicial = capI;
            garantia = g;
            composcicionCapital = comCap;
            cargo = car;
            clienteEstudio = cE;
            datosFamiliares = datosf;
            aportes = apor;
        }

        #region ABM Miembro de la empresa

        //ALTA DE MIEMBRO DE LA EMPRESA

       

       
        public bool agregarMiembro()
        {
          return Datos.agregarEmpleado(codigoEmpleado, tipo, categoria, apellidoNombre, estadoCivil, tipoDoc, nroDocumento, nacionalidad, fechaNacimiento, domicilio, localidad, codigoPostal, provincia.CodigoProvincia, telefono, mail, capitalInicial, garantia, composcicionCapital, cargo);
            
        }


        //BAJA  DE MIEMBRO DE LA EMPRESA
        public static bool eliminarMiembro(long cod)
        {
            //Primero validar el cliente y después eliminarlo

           if (Datos.verificarEmpleado(cod))
            {
                return Datos.eliminarEmpleado(cod);
            }
            else 
            {
                return false;
            }

        }

        //MODIFICACION DE MIEMBRO DE LA EMPRESA
#warning Comentado para que compile
        public bool modificarMiembro()
        {
            /*if (Datos.verificarEmpleado(cod))
            {
                return Datos.actualizarEmpleado(codigoEmpleado, tipo, categoria, apellidoNombre, estadoCivil, tipoDoc, nroDocumento, nacionalidad, fechaNacimiento, domicilio, localidad, codigoPostal, provincia.CodigoProvincia, telefono, mail, capitalInicial, garantia, composcicionCapital, cargo);
            }
            else*/
            {
                return false;
            }          
           
        }


        #endregion






    }//clase
}//namespace
