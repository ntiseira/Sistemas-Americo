<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarEmpleado.aspx.cs" Inherits="IU.SueldosJornales.Liquidacion.BuscarEmpleado" %>

<%@ Register src="../../Generico/ControlChildAbm.ascx" tagname="ControlChildAbm" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Búsqueda de empleado para liquidación de sueldo</title>
</head>
<body>
    <form id="form1" runat="server">
    
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
    <div runat="server" style="border:solid thin black;">

        <table runat="server">
            <tr>
                <th>
                    <ext:Label ID="Label1" Text="Número de Empleado:" runat="server">
                    </ext:Label>
                </th>
                
                <th>
                    <ext:TextField ID="TextField1" runat="server">
                    </ext:TextField>
                </th></tr>
            
            <tr>
                <ext:Panel runat="server" ID="panel1">
                <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Buscar">
                </ext:Button>
                </Buttons>
                </ext:Panel>
            </tr>
        </table>
    </div>
    <br />
    <div runat="server" style="border:solid thin black;">
        <table>
            <tr>
                <th>
                    <ext:Label ID="Label2" Text="Inicio de Período:" runat="server">
                    </ext:Label>
                </th>
                
                <th>
                    <ext:DateField ID="DateField1" runat="server">
                    </ext:DateField>
                </th>
            </tr>
            
            <tr>
                <th>
                    <ext:Label ID="Label3" Text="Fin de Período:" runat="server">
                    </ext:Label>
                </th>
                
                <th>
                    <ext:DateField ID="DateField2" runat="server">
                    </ext:DateField>
                </th>
            </tr>
            
            <tr>
                <ext:Button ID="Button2" runat="server" Text="Asignar Período">
                </ext:Button>
            </tr>            
        </table>
    </div>
    <br />
    <div runat="server" style="border:solid thin black;">
    
        <uc1:ControlChildAbm ID="ControlAbm1" runat="server" />
    
    </div>
    
    <div runat="server" style="border:solid thin black;">
        <table width="100%">
            <tr>
                <th width="50%">
                    <ext:Button ID="Button3" runat="server" Text="Liquidar" />
                </th>
                
                <th width="50%">
                    <ext:Button ID="Button4" runat="server" Text="Cancelar" />
                </th>
            </tr>
        </table>
    </div>
    
    
    
    
    
    </form>
</body>
</html>
