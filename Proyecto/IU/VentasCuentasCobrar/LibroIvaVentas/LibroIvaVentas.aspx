<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibroIvaVentas.aspx.cs" Inherits="IU.VentasCuentasCobrar.LibroIvaVentas.LibroIvaVentas" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="overflow:hidden">
    <form id="form1" runat="server">
    <div>
       <object data="../Reportes/ReportesGenerados/LibroIvaVentas.pdf" width="100%" height="1000"    type="application/pdf">
alt : <a href=="../Reportes/ReportesGenerados/LibroIvaVentas.pdf" >archivo.pdf</a>
</object>
    

    </div>
    </form>
</body>
</html>
