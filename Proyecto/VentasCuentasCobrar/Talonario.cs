
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

#warning ver diseņo y factura
		public DiseņoComprobante m_DiseņoComprobante; 
		public Factura m_Factura;

		public Talonario(){

		}


	}//end Talonario

}//end namespace VentasCuentasCobrar