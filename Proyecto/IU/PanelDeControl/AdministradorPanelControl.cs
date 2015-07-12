using CapaDatos;

namespace IU.PanelDeControl
{
    public static class AdministradorPanelControl
    {

        public static int darEstadistica(string query) 
        {
            return Datos.Consultar(query, 1);
        }

    }
}