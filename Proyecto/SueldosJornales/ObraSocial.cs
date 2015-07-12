using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhantomDb.Entidades;

namespace SueldosJornales
{

    /*Esta BasedeDatos guarda información de las Obras Sociales de los empleados de la
    empresa. Este dato se informará en el archivo con destino al SIJP.*/
    [Tabla("TiposObrasSociales")]
    public class ObraSocial
    {

        private long codigo;
        [Identificador(Autogenerado = true)]
        [Columna("Código")]
        public long Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private string descripcion;
        [Atributo]
        [Columna("Descripción")]
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        /*
        private string codigoObraSocial;
        [Identificador(Modificable = false)]
        [Columna("Código de Obra Social")]
        public string CodigoObraSocial
        {
            get { return codigoObraSocial; }
            set { codigoObraSocial = value; }
        }
        */

        private string planObraSocial;
        [Atributo]
        [Columna("Plan Obra Social")]
        public string PlanObraSocial
        {
            get { return planObraSocial; }
            set { planObraSocial = value; }
        }


        private bool habilitado;
        [Atributo]
        [Columna("Habilitado")]
        public bool Habilitado
        {
            get { return habilitado; }
            set { habilitado = value; }
        }


        private long empresa_idempresa;
        [Identificador(Modificable = false)]
        [Columna("Código de empresa", false)]
        public long Empresa_idempresa
        {
            get { return empresa_idempresa; }
            set { empresa_idempresa = value; }
        }


        public static List<string> darAtributos()
        {
            List<string> atributos = new List<string>();
            atributos.Add("codigo");
            atributos.Add("descripcion");
            atributos.Add("planObraSocial");
            atributos.Add("habilitado");

            return atributos;
        }


        /*Código según T06 RG 136/98: elegir el código de obra social que corresponde
        a la obra social seleccionada. Este dato se informará en el archivo
        que se genere para importar desde el aplicativo SIAp - SIJP.*/
    }
}
