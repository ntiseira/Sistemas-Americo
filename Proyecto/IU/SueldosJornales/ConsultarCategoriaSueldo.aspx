<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarCategoriaSueldo.aspx.cs" Inherits="IU.SueldosJornales.ConsultarCategoriaSueldo" %>

<%@ Register src="../Generico/ModuloFiltro.ascx" tagname="ModuloFiltro" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Consultar categoría de sueldo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ControlList ID="ControlList1" runat="server" />
        <uc2:ModuloFiltro ID="ModuloFiltro1" runat="server" />
    </div>

    </form>
</body>
</html>
