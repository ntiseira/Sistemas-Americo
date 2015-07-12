<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DarResumenDeCuenta.aspx.cs" Inherits="IU.VentasCuentasCobrar.CuentaCorrienteyCobranzas.DarResumenDeCuenta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Resumen de cuenta</title>
</head>
<body style="overflow:hidden">
    <form id="form1" runat="server">
    <div>
    <object data="../Reportes/ReportesGenerados/ResumenCuentaCorriente.pdf" width="100%" height="1000"    type="application/pdf">
alt : <a href="../Reportes/ReportesGenerados/ResumenCuentaCorriente.pdf" >archivo.pdf</a>
</object>
    
            
    </div>
    </form>
</body>
</html>
