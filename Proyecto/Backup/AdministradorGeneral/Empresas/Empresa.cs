#warning El CUIT debe ser validado.

namespace AdministradorGeneral 
{
	public class Empresa 
    {
        Entidades.Entity_empresa datos;
        public Entidades.Entity_empresa Datos
        {
            get { return datos; }
            set { datos = value; }
        }
	}
}//end namespace Empresas