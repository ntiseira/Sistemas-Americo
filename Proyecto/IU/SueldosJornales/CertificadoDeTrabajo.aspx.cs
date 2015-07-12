using System;
using System.Data;
using ModuloSoporte;
using SueldosJornales;

namespace IU.SueldosJornales
{
    public partial class CertificadoDeTrabajo : System.Web.UI.Page
    {
        private String certificado;
        private AdministradorSueldosJornales asj;

        protected void Page_Load(object sender, EventArgs e)
        {
            asj = new AdministradorSueldosJornales();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            DataSet ds = asj.devolverEmpleado(long.Parse(TextBox1.Text));
            EmpresaLabel.Text = Global.CodEmpresa+"";
            if (ds.Tables[0].Rows.Count > 0)
            {
                DniLabel.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                EmpleadoLabel.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString() + " " +
                ds.Tables[0].Rows[0].ItemArray[3].ToString();
                EmpresaLabel.Text = Global.NombreEmpresa;
                SucursalLabel.Text = Global.CodSucursal+"";

                certificado = "Se certifica que el empleado " +
                EmpleadoLabel.Text + ", con DNI " + DniLabel.Text +
                " se encuentra trabajando en la Sucursal "+ Global.NombreSucursal +
                " de la Empresa " + Global.NombreEmpresa + "al día de la fecha .............." +
                "             Firma Empleado:....................................." + 
                "             Firma Empleador:.....................................";
            }
            else 
            {
                Label2.Text = "*Empleado no encontrado";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
