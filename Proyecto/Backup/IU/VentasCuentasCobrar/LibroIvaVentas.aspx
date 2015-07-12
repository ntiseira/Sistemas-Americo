<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LibroIvaVentas.aspx.cs" Inherits="IU.VentasCuentasCobrar.LibroIvaVentas" %>

<%@ Register src="../Generico/ControlReporte.ascx" tagname="ControlReporte" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      
        <uc1:ControlReporte ID="ControlReporte1" runat="server" />
      
    </div>
    </form>
</body>
</html>
