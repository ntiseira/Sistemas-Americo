<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasCompras.aspx.cs" Inherits="IU.PanelDeControl.EstadisticasDeCompras.EstadisticasCompras" %>

<%@ Register src="../../../Generico/Grafico.ascx" tagname="Grafico" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Estadisticas de Compras</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Grafico ID="Grafico1" runat="server" />
    
    </div>
    </form>
</body>
</html>
