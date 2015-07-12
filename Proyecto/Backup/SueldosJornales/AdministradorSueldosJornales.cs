using System.Data;
using ModuloSoporte;

namespace SueldosJornales
{
    public class AdministradorSueldosJornales
    {

        public AdministradorSueldosJornales() 
        {
        }


        public DataSet devolverEmpleado(long legajo) 
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.devolverEmpleado(legajo, Global.CodEmpresa);
        }


        public DataSet darDatosEmpleador() 
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.darDatosEmpleador(Global.CodEmpresa);
        }

        public DataSet darObrasSociales() 
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.darObrasSociales(Global.CodEmpresa);
        }

        public DataSet darCategorias()
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.darCategorias();
        }
        
        public DataSet darJornales()
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.darJornales(Global.CodEmpresa);
        }

        public DataSet darSueldos() 
        {
           return CapaDatos.SueldosyJornales.DatosSueldosJornales.darSueldos(Global.CodEmpresa);
        }

        public DataSet darLugaresPago()
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.darLugaresPago(Global.CodEmpresa);
        }

        public bool agregarCategoria(string nombreCategoria, bool habilitado)
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.insertarCategoriaSueldo(nombreCategoria, habilitado);
        }

        public DataSet darFeriados()
        {
            return CapaDatos.SueldosyJornales.DatosSueldosJornales.darFeriados(Global.CodEmpresa);
        }
    }
}
