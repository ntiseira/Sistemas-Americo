
using VentasCuentasCobrar;
namespace VentasCuentasCobrar {
	
    public class Talonario {

		private string codigo;
		private string descripcion;
		private string tipoNumeracion;
		private long desde;
		private long hasta;
		private long ultimoUtilizado;
		private long codigoAutorizacion;
		private System.DateTime fechaVencimiento;

#warning ver dise�o y factura
		public Dise�oComprobante m_Dise�oComprobante; 
		public Factura m_Factura;

		public Talonario(){

		}


	}//end Talonario

}//end namespace VentasCuentasCobrar