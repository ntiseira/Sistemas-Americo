using System;
using PhantomDb.Entidades;
using CapaDatos.AdministradorGeneral;


namespace SueldosJornales.Empleados
{
    [Tabla("Empleados")]
    public class Empleado
    {
        private int legajo;
        [Identificador(Autogenerado = true)]
        [Columna("Legajo")]
        public int Legajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        private string tipoEmpleado; // Ej: Administrativo (linkear tipoEmpleado con Categoría de sueldo)
        [Atributo]
        [Columna(Titulo="TipoEmpleado", ValoresFijos = "Administración:Administración,Gestión:Gestión,Sistemas:Sistemas,Operario:Operario,Seguridad:Seguridad,Limpieza:Limpieza,Otros:Otros,Vendedor:Vendedor")]
        public string TipoEmpleado
        {
            get { return tipoEmpleado; }
            set { tipoEmpleado = value; }
        }

        private string apellido;
        [Atributo]
        [Columna("Apellido")]
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private string nombre;
        [Atributo]
        [Columna("Nombre")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string estadoCivil;
        [Atributo]
        [Columna(Titulo="EstadoCivil", ValoresFijos = "Soltero:Soltero,Casado:Casado,Divorciado:Divorciado,Viudo:Viudo")]
        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        private string tipoDoc;
        [Atributo]
        [Columna(Titulo = "TipoDoc", ValoresFijos = "DNI:DNI,Pasaporte:Pasaporte,LE:LE,CI:CI")]
        public string TipoDoc
        {
            get { return tipoDoc; }
            set { tipoDoc = value; }
        }

        private long nroDocumento;
        [Atributo]
        [Columna("NroDocumento")]
        public long NroDocumento
        {
            get { return nroDocumento; }
            set { nroDocumento = value; }
        }

        private string nacionalidad;
        [Atributo]
        [Columna("Nacionalidad")]
        public string Nacionalidad
        {
            get { return nacionalidad; }
            set { nacionalidad = value; }
        }

        private DateTime fechaNacimiento;
        [Atributo]
        [Columna("FechaNacimiento")]
        public DateTime FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        private string domicilio;
        [Atributo]
        [Columna("Domicilio")]
        public string Domicilio
        {
            get { return domicilio; }
            set { domicilio = value; }
        }

        private string localidad;
        [Atributo]
        [Columna("Localidad")]
        public string Localidad
        {
            get { return localidad; }
            set { localidad = value; }
        }

        private string provincia;
        [Atributo]
        [Columna("Provincia")]
        public string Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        private string pais;
        [Atributo]
        [Columna("Pais")]
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }

        private string codigoPostal;
        [Atributo]
        [Columna("CodigoPostal")]
        public string CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        private string telefono;
        [Atributo]
        [Columna("Telefono")]
        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        private string mail;
        [Atributo]
        [Columna("Mail")]
        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        private int categoria; 
        [Atributo]
        [Columna("Categoria")]
        [Relacion(Destino = typeof(CategoriaSueldo), CampoId = 0, CampoSecundario = 1)]
        public int Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        private int obraSocial;
        [Atributo]
        [Columna("ObraSocial")]
        [Relacion(Destino = typeof(ObraSocial), CampoId = 0, CampoSecundario = 1)]
        public int ObraSocial
        {
            get { return obraSocial; }
            set { obraSocial = value; }
        }

        private bool activo;
        [Atributo]
        [Columna("Activo")]
        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        private long empresa_idempresa;
        [Identificador(Modificable = false)]
        [Columna("Código de empresa", false)]
        public long Sucursal_empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }


        private long sucursal_codigoSucursal;
        [Columna("Código de Sucursal")]
        [Relacion(Destino = typeof(Entidades.Entity_sucursal), CampoId = 0, CampoSecundario = 1)]
        public long Sucursal_codigoSucursal
        {
            get { return sucursal_codigoSucursal; }
            set { sucursal_codigoSucursal = value; }
        }

        private DateTime fechaIngreso;
        [Columna(Formato = Formato.DateType)]
        public DateTime FechaIngreso
        {
            get { return fechaIngreso; }
            set { fechaIngreso = value; }
        }

        private DateTime fechaEgreso;
        [Columna(Formato = Formato.DateType)]
        public DateTime FechaEgreso
        {
            get { return fechaEgreso; }
            set { fechaEgreso = value; }
        }




    }//clase
}//namespace
