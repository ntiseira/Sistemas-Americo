<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CertificadoDeTrabajo.aspx.cs" Inherits="IU.SueldosJornales.CertificadoDeTrabajo" Culture="Auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Certificado de Trabajo</title>
    <style type="text/css">
        .style1
        {
            color: #FFFFFF;
        }
    </style>
</head>
<body style="background-image:url(../images/wallpaperlogin.jpg);">
    <form id="form1" runat="server">
    <div>
    <h1 class="style1">Generación de Certificado de Trabajo Automático</h1>
    </div>
    
    <div>
        <asp:Label ID="Label2" runat="server" BorderColor="Red"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Ingrese número de Empleado:" 
            style="color: #FFFFFF"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Buscar" />
        <br />
        <br />
        <br />
    </div>
    
    <div>
    
        <span class="style1">Se certifica que el empleado
        <asp:Label ID="EmpleadoLabel" runat="server" Text="........................"></asp:Label>
&nbsp;con DNI
        <asp:Label ID="DniLabel" runat="server" Text=".........................."></asp:Label>
&nbsp;se encuentra trabajando en la sucursal n°  
        <asp:Label ID="SucursalLabel" runat="server" 
            Text="....................."></asp:Label> 
&nbsp;de la empresa       
        <asp:Label ID="EmpresaLabel" runat="server" 
            Text="....................."></asp:Label>
&nbsp;al día de la fecha
        <asp:Label ID="FechaLabel" runat="server" 
            Text="................................."></asp:Label>
        </span>.<br />
        <br />
        <span class="style1">Firma Empleado:.....................................&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        Firma Empleador:.....................................</span></div>
        
        <div>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Imprimir" 
                onclick="Button1_Click" />
        </div>
        
    </form>
</body>
</html>
