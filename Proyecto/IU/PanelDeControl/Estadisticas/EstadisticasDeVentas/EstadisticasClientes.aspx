<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasClientes.aspx.cs" Inherits="IU.PanelDeControl.Estadisticas.EstadisticasDeCompras.EstadisticasClientes" %>

<%@ Register src="../../../Generico/Grafico.ascx" tagname="Grafico" tagprefix="uc1" %>

<%@ Register src="../../../Generico/GraficoConFiltro.ascx" tagname="GraficoConFiltro" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Estadísticas de Clientes mensuales</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        
        <uc2:GraficoConFiltro ID="GraficoConFiltro1" runat="server" />
    
        
    </div>
    </form>
</body>
</html>
