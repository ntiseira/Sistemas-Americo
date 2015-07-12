<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadisticasVentas.aspx.cs" Inherits="IU.PanelDeControl.EstadisticasVentas" %>

<%@ Register src="../Generico/Grafico.ascx" tagname="Grafico" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Estadísticas de Ventas</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:Grafico ID="Grafico1" runat="server" />
    
    </div>
    </form>
</body>
</html>
